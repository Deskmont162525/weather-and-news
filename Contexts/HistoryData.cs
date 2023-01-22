using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class HistoryData
    {
        public static List<History> ListarHistory()
        {
            List<History> oListaHistory = new List<History>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar_history", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaHistory.Add(new History()
                            {
                                HistoryId = Convert.ToInt32(dr["HistoryId"]),
                                UsuarioIdFk = dr["UsuarioIdFk"].ToString(),
                                City = dr["City"].ToString(),
                                Info = dr["Info"].ToString(),
                                FechaVista = Convert.ToDateTime(dr["FechaVista"].ToString()),
                            });
                        }

                    }
                    return oListaHistory;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return oListaHistory;
                }
            }
        }

        public static List<History> RegistroHistory(History oHistory)
        {
            List<History> oListaHistory = new List<History>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar_history", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioIdFk", oHistory.UsuarioIdFk);
                cmd.Parameters.AddWithValue("@City", oHistory.City);
                cmd.Parameters.AddWithValue("@Info", oHistory.Info);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaHistory.Add(new History()
                            {
                                UsuarioIdFk = dr["UsuarioIdFk"].ToString(),
                                City = dr["City"].ToString(),
                                Info = dr["Info"].ToString(),
                            });
                        }

                    }
                    return oListaHistory;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return oListaHistory;
                }
            }
        }
        
        public static History ObtenerHistory(int idHistory)
        {
            History oHistory = new History();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener_history", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HistoryId", idHistory);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oHistory = new History()
                            {
                                HistoryId = Convert.ToInt32(dr["HistoryId"]),
                                UsuarioIdFk = dr["UsuarioIdFk"].ToString(),
                                City = dr["City"].ToString(),
                                Info = dr["Info"].ToString(),
                                FechaVista = Convert.ToDateTime(dr["FechaVista"].ToString()),
                            };
                        }

                    }
                    return oHistory;
                }
                catch (Exception ex)
                {
                    return oHistory;
                }
            }
        }

        public static bool EliminarHistory(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar_history", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HistoryId", id);
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
