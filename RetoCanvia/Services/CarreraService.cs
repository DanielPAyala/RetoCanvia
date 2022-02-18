using RetoCanvia.Datos;
using RetoCanvia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RetoCanvia.Services
{
    public class CarreraService : Conexion
    {
        /// <summary>
        /// Obtiene lista de carreras
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CarreraModel> Consultar()
        {
            Conectar();
            List<CarreraModel> lista = new List<CarreraModel>();
            try
            {
                SqlCommand comando = new SqlCommand("sp_consultar_carrera", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    CarreraModel obj = new CarreraModel()
                    {
                        CarreraId = int.Parse(dr[0].ToString()),
                        Nombre = dr[1].ToString()
                    };
                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return lista;
        }

        /// <summary>
        /// Guardar carrera
        /// </summary>
        /// <param name="obj"></param>
        public void Guardar(CarreraModel obj)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_guardar_carrera", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@carreraid", obj.CarreraId);
                comando.Parameters.AddWithValue("@nombre", obj.Nombre);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Buscar carrera por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CarreraModel BuscarPorId(int id)
        {
            Conectar();
            CarreraModel obj = new CarreraModel();
            try
            {
                SqlCommand comando = new SqlCommand("sp_consultar_carrera_id", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    obj.CarreraId = int.Parse(dr[0].ToString());
                    obj.Nombre = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return obj;
        }

        /// <summary>
        /// Actualizar carrera
        /// </summary>
        /// <param name="obj"></param>
        public void Actualizar(CarreraModel obj)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_editar_carrera", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@carreraid", obj.CarreraId);
                comando.Parameters.AddWithValue("@nombre", obj.Nombre);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Eliminar Carrera
        /// </summary>
        /// <param name="id"></param>
        public void Eliminar(int id)
        {
            SqlCommand comando = new SqlCommand("sp_eliminar_carrera", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
        }
    }
}
