/// <summary>
/// En esta clase se genera para contener la informacion que pasa atravez de los proyectos
/// </summary>
namespace MercadoLibre_MYSQL.Model
{
    public class Stats
    {
        /// Cantidd de Mutantes Confirmados
        public int count_mutant_dna { get; set; }
        /// Cantidd de Humanos Confirmados
        public int count_human_dna { get; set; }
        public float ratio { get; set; }
    }
}
