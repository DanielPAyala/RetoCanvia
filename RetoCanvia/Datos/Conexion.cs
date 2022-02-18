using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace RetoCanvia.Datos
{
    public class Conexion
    {
        protected SqlConnection cnn;

        /// <summary>
        /// Conecta la aplicacion a la base de datos
        /// </summary>
        protected void Conectar()
        {
            try
            {
                cnn = new SqlConnection(@"Data Source=DESKTOP-FG0PN4T;Initial Catalog=RetoCanvia;Integrated Security=True;");
                cnn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Desconec
        /// </summary>
        protected void Desconectar()
        {
            try
            {
                cnn = new SqlConnection(@"Data Source=DESKTOP-FG0PN4T;Initial Catalog=RetoCanvia;Integrated Security=True;");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
