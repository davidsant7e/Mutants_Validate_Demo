/// <summary>
/// clase encargada de contener la informacion y posicion de cada caracter de la cadena
/// </summary>
namespace MercadoLibre_Muntantes.Dto
{
    public class dtoADN
    {
        /// <summary>
        /// Caracter de la cadena
        /// </summary>
        public string Caracter { get; set; }
        /// <summary>
        /// indica en que posicion esta en la matriz, en la posicion X
        /// </summary>
        public int Posicion_X { get; set; }
        /// <summary>
        /// indica en que posicion esta en la matriz, en la posicion Y
        /// </summary>
        public int Posicion_Y { get; set; }
        /// <summary>
        /// indica si el caracter es permitido bajo la regla de negocio #1
        /// </summary>
        public bool CaracterPermitido
        {
            get
            {
                if (CaracteresPermitidos.Contains(Caracter))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
        /// <summary>
        /// Caracteres Validos 
        /// </summary>
        public string CaracteresPermitidos = "ATCG";
    }
}
