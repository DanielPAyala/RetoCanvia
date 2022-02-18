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
    public class EstudianteService : Conexion
    {
        /// <summary>
        /// Obtiene lista de estudiantes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EstudianteModel> Consultar()
        {
            Conectar();
            List<EstudianteModel> lista = new List<EstudianteModel>();
            try
            {
                SqlCommand comando = new SqlCommand("sp_consultar_estudiante", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    EstudianteModel obj = new EstudianteModel()
                    {
                        EstudianteId = int.Parse(dr[0].ToString()),
                        Nombre = dr[1].ToString(),
                        Apellidos = dr[2].ToString(),
                        CarreraId = int.Parse(dr[3].ToString())
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
        /// Guardar estudiante
        /// </summary>
        /// <param name="obj"></param>
        public void Guardar(EstudianteModel obj)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_guardar_estudiante", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", obj.Nombre);
                comando.Parameters.AddWithValue("@apellido", obj.Apellidos);
                comando.Parameters.AddWithValue("@carreraid", obj.CarreraId);
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
        /// Buscar estudiante por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EstudianteModel BuscarPorId(int id)
        {
            Conectar();
            EstudianteModel obj = new EstudianteModel();
            try
            {
                SqlCommand comando = new SqlCommand("sp_consultar_estudiante_id", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    obj.EstudianteId = int.Parse(dr[0].ToString());
                    obj.Nombre = dr[1].ToString();
                    obj.Apellidos = dr[2].ToString();
                    obj.CarreraId = int.Parse(dr[3].ToString());
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
        /// Actualizar estudiante
        /// </summary>
        /// <param name="obj"></param>
        public void Actualizar(EstudianteModel obj)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_editar_estudiante", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", obj.Nombre);
                comando.Parameters.AddWithValue("@apellido", obj.Apellidos);
                comando.Parameters.AddWithValue("@carreraid", obj.CarreraId);
                comando.Parameters.AddWithValue("@id", obj.EstudianteId);
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
        /// Eliminar estudiante
        /// </summary>
        /// <param name="id"></param>
        public void Eliminar(int id)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_eliminar_estudiante", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
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
    }
}
