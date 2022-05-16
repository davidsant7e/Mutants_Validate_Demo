namespace MercadoLibre_MYSQL.Data.Repositories
{

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MercadoLibre_MYSQL.Model;
    using MySql.Data.MySqlClient;
    using Dapper;
    public class ADNRepository : IADNRepository
    {
        /// <summary>
        /// variable de configuracion
        /// </summary>
        private MySqlConfiguracion _ConfiguracionString;

        /// <summary>
        /// se configura la conexion de base de datos
        /// </summary>
        /// <param name="vparConfiguracion">variable de configuracion de base de datos</param>
        public ADNRepository(MySqlConfiguracion vparConfiguracion)
        {
            _ConfiguracionString = vparConfiguracion;
        }

        /// <summary>
        /// se retorna la conexion de base de datos
        /// </summary>
        /// <returns></returns>
        protected MySqlConnection Conexiondb()
        {
            return new MySqlConnection(_ConfiguracionString.Conexion);
        }

        /// <summary>
        /// Todas las Cadenas de ADN que han sido validads y sus resultados
        /// </summary>
        /// <returns>Retorna todos las caadenas de adn</returns>
        public async Task<IEnumerable<ADN>> GetAllADN()
        {
            var vlocdb = Conexiondb();
            string vlocSql = @"select id, ADN,IsMutant from tb_ADN ";

            return await vlocdb.QueryAsync<ADN>(vlocSql, new { });
        }

        /// <summary>
        /// realiza el registro de base de datos de la cdena de ADN
        /// </summary>
        /// <param name="vparCanedaADN">Informacion de cadena de base ADN</param>
        /// <returns>Retorna si el registor se hizo correctamente</returns>
        public bool AlmacenarADN(ADN vparCanedaADN)
        {
            var vlocdb = Conexiondb();
            string vlocSql = @"insert into tb_ADN (CadenaADN,EsMutante,Descripcion_Not_Mutante) 
                            values (@CadenaADN,@EsMutante,@Descripcion_Not_Mutante)";

            var vlocResultado = vlocdb.ExecuteAsync(vlocSql, new { vparCanedaADN.CadenaADN,vparCanedaADN.EsMutante , vparCanedaADN.Descripcion_Not_Mutante });
            if (vlocResultado.Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
