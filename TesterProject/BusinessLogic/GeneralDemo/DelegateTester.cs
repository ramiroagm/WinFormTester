﻿using TesterProject.BusinessLogic.Interfaces.DelegateTester;

namespace TesterProject.BusinessLogic.GeneralDemo
{
    public class DelegateTester : IDelegateTester
    {
        public delegate int OperacionMatematica(int a, int b);

        public int Suma(int a, int b)
        {
            return a + b;
        }

        public int Resta(int a, int b)
        {
            return a - b;
        }
    }
}