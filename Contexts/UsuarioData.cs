using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using WebApplication1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication1.Contexts
{
    public class UsuarioData
    {
        public static List<Usuario> Listar()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Usuario()
                            {
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                                Nombres = dr["Nombres"].ToString(),                                
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                                Estado = dr["estado"].ToString(),
                            });
                        }

                    }                    
                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return oListaUsuario;
                }
            }
        }

        public static bool Registrar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombres", oUsuario.Nombres);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static Usuario Obtener(int idusuario)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuarioid", idusuario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oUsuario = new Usuario()
                            {
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                                Nombres = dr["Nombres"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                                Estado = dr["Estado"].ToString(),
                            };
                        }

                    }
                    return oUsuario;
                }
                catch (Exception ex)
                {
                    return oUsuario;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuarioid", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}
