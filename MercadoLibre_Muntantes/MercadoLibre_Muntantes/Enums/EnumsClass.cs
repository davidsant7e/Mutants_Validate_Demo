namespace MercadoLibre_Muntantes.Enums
{
    /// <summary>
    /// Enum con el listado de las reglas que se debe de cumplir para confirmar una cadena de ADN Mutante
    /// </summary>
    public enum EnumReglas
    {
        /// Cumple con todas las validaciones necesarias
        CumpleTodasLasReglas = 0,
        //Regla 1, Solo se permite los caracteres ATCG
        CaracterNoValido = 1,
        //Regla 2, indica que la caneda no encontro la cantidad de secuencias necesarias
        NoSeEncontroSecuenciasNecesarias = 2,
        //Regla 3, Indica que la Cadena de ADN no es NxN
        LaCadenaNoEsNXN = 3,
        //Regla 4, indica que una las filas o String no tiene todos los Caracteres de necesarios de la matriz (N)
        UnStringNoCumpleConLaCantidadRequerida = 4
    }

}
