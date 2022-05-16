/// <summary>
/// clase encargada de realizar la consultal de status de las cadenas de ADN validadas
/// </summary>
namespace MercadoLibre_MYSQL.Data.Repositories
{
    using System.Threading.Tasks;
    using MercadoLibre_MYSQL.Model;

    public interface IStatsRepository
    {
        /// <summary>
        /// se realiza la consulta del stats de los procesos de validacion de cadenas de ADN
        /// </summary>
        /// <returns>listato de solucion de </returns>
        Task<Stats> GetStats();
    }
}