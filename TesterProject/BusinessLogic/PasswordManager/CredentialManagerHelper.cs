using System.Runtime.InteropServices;
using System.Text;

namespace TesterProject.BusinessLogic.PasswordManager
{
    public class CredentialManagerHelper
    {
        private const int CRED_TYPE_GENERIC = 1;

        private const int CRED_ENUM_ALL = 1;
        private const int CRED_FLAGS_USERNAME_TARGET_SAME_AS_TARGET = 4;

        // Structure for CREDENTIAL (defined in wincred.h)
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CREDENTIAL
        {
            public int Flags;
            public int Type;
            public string TargetName;
            public string Comment;
            public long LastWritten;
            public int CredBlobSize;
            public IntPtr CredBlob;
            public int Persist;
            public int AttributeCount;
            public IntPtr Attributes;
            public string UserName;
        }

        [DllImport("Advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool CredReadW(
            string TargetName,
            int Type,
            int Flags,
            out IntPtr CredentialPtr
        );

        [DllImport("Advapi32.dll", SetLastError = true)]
        private static extern void CredFree(IntPtr CredentialPtr);

        public static string? ReadSecret(string targetName)
        {
            IntPtr credPtr = IntPtr.Zero;
            try
            {
                if (CredReadW(targetName, CRED_TYPE_GENERIC, 0, out credPtr))
                {
                    CREDENTIAL cred = Marshal.PtrToStructure<CREDENTIAL>(credPtr);

                    if (cred.CredBlob != IntPtr.Zero && cred.CredBlobSize > 0)
                    {
                        byte[] credBytes = new byte[cred.CredBlobSize];
                        Marshal.Copy(cred.CredBlob, credBytes, 0, cred.CredBlobSize);
                        string secret = Encoding.Unicode.GetString(credBytes);
                        int nullIndex = secret.IndexOf('\0');
                        if (nullIndex >= 0)
                        {
                            secret = secret[..nullIndex];
                        }
                        return secret;
                    }
                }
                else
                {
                    int error = Marshal.GetLastWin32Error();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                if (credPtr != IntPtr.Zero)
                {
                    CredFree(credPtr);
                }
            }
            return null;
        }
    }
}
