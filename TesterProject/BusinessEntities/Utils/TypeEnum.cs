namespace TesterProject.BusinessEntities.Utils
{
    // Enumeración de tipos de respuesta
    public enum TypeEnum
    {
        CORRECT_RESPONSE,
        INCORRECT_RESPONSE,
        ERROR,
        EXCEPTION
    }

    // Tipo de pedido de mensaje
    public enum RequestMediaType
    {
        TEXT,
        IMAGE,
        VIDEO,
        AUDIO,
        DOCUMENT,
        STICKER,
        LOCATION,
        CONTACT
    }

    // Tipo de relación
    public enum TipoRelacion
    {
        Ninguno = 0,
        Amigos,
        Compañeros,
        Familia,
        Novios
    }
}