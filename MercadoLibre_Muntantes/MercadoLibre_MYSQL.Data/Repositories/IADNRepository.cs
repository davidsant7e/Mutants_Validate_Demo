/// <summary>
/// Interface encargada de realizar las consultas y registros  bsae de datos
/// </summary>
namespace MercadoLibre_MYSQL.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MercadoLibre_MYSQL.Model;

    public interface IADNRepository
    {
        /// <summary>
        /// Todas las Cadenas de ADN que han sido validads y sus resultados
        /// </summary>
        /// <returns>Retorna todos las caadenas de adn</returns>
        Task<IEnumerable<ADN>> GetAllADN();
        /// <summary>
        /// realiza el registro de base de datos de la cdena de ADN
        /// </summary>
        /// <param name="vparCanedaADN">Informacion de cadena de base ADN</param>
        /// <returns>Retorna si el registor se hizo correctamente</returns>
        bool AlmacenarADN(ADN vparCanedaADN);

    }
}
