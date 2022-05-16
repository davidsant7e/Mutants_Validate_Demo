namespace MercadoLibre_MYSQL.Data.Repositories
{
    /// <summary>
    /// Interfas encargada de realizar la consultal de status de las cadenas de ADN validadas
    /// </summary>
    using System.Threading.Tasks;
    using MercadoLibre_MYSQL.Model;
    using MySql.Data.MySqlClient;
    using Dapper;

    public class StatsRepository : IStatsRepository
    {
        /// <summary>
        /// variable de configuracion
        /// </summary>
        private MySqlConfiguracion _ConfiguracionString;

        /// <summary>
        /// se configura la conexion de base de datos
        /// </summary>
        /// <param name="vparConfiguracion">variable de configuracion de base de datos</param>
        public StatsRepository(MySqlConfiguracion vparConfiguracion)
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
        /// se realiza la consulta del stats de los procesos de validacion de cadenas de ADN
        /// </summary>
        /// <returns>listato de solucion de </returns>
        public async Task<Stats> GetStats()
        {
            var vlocdb = Conexiondb();
            string vlocSql = @"select count_mutant_dna,count_human_dna,RATIO from vw_stats";

            return await vlocdb.QueryFirstOrDefaultAsync<Stats>(vlocSql, new { });
        }
    }
}
