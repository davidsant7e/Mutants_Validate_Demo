/// <summary>
/// En esta clase se genera para contener la informacion que pasa atravez de los proyectos
/// </summary>
namespace MercadoLibre_MYSQL.Model
{
    public class ADN
    {
        /// primary key o llave principal de la informacion de ADN
        public int Id { get; set; }
        /// Contiene la cadena de AND de la informacion
        public string CadenaADN { get; set; }
        /// Contiene el resultado de la validaacion si es o no mutante 
        public bool EsMutante { get; set; }
        /// Se contiene la descripcion del resultado por el cual no cumple con ser mutante
        public string Descripcion_Not_Mutante { get; set; }
    }
}
