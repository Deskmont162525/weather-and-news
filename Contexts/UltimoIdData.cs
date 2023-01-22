using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class UltimoIdData
    {
      
        public static UltimoId ObtenerUId()
        {
            UltimoId oUltimoId = new UltimoId();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener_ultimo_id_insert_u", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oUltimoId = new UltimoId()
                            {
                                UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                            };
                        }

                    }
                    return oUltimoId;
                }
                catch (Exception ex)
                {
                    return oUltimoId;
                }
            }
        }
    }
}
