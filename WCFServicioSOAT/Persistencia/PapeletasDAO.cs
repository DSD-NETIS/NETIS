using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServicioSOAT.Dominio;

namespace WCFServicioSOAT.Persistencia
{
    public class PapeletasDAO
    {
        public string cadenaConexion = Conexion.cadenaConexion;

        public List<Papeletas> ValidarPapeleta(string placa)
        {
            List<Papeletas> papeletasEncontradas = new List<Papeletas>();
            Papeletas papeletaEncontrada = null;
            string sql = "SELECT * FROM SAT WHERE Placa = @placa AND Tipo = 'Papeleta'";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@placa", placa));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            papeletaEncontrada = new Papeletas()
                            {
                                IdSAT = (int)resultado["IdSAT"],
                                Placa = (string)resultado["Placa"],
                                Tipo = (string)resultado["Tipo"],
                                Monto = (decimal)resultado["Monto"]
                            };
                            papeletasEncontradas.Add(papeletaEncontrada);
                        }
                    }
                }
            }

            return papeletasEncontradas;
        }

        public Papeletas Obtener(int id)
        {
            Papeletas papeletaEncontrada = null;
            string sql = "SELECT * FROM SAT WHERE IdSAT = @codigo";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigo", id));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            papeletaEncontrada = new Papeletas()
                            {
                                IdSAT = (int)resultado["IdSAT"],
                                Placa = (string)resultado["Placa"],
                                Tipo = (string)resultado["Tipo"],
                                Monto = (decimal)resultado["Monto"]
                            };
                        }
                    }
                }
            }
            return papeletaEncontrada;
        }
    }
}