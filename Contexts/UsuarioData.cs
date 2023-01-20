using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

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
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
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
    }
}
