namespace MercadoLibre_MYSQL.Data
{

    ///Clase encargada de realizar la configuracion de conexion a base de datos
    public class MySqlConfiguracion
    {
        public MySqlConfiguracion(string vparConexion)
        {
            this.Conexion = vparConexion;
        }
        public string Conexion { get; set; }

    }
}
