using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_SAT_Impuesto_Vehicular.Dominio;
using System.Data.SqlClient;

namespace WCF_SAT_Impuesto_Vehicular.Persistencia
{
    public class SatDAO
    {
        private string CadenaConexion = "Data Source=(local);Initial Catalog=BD_Netis;Integrated Security=SSPI;User ID=sa;Password=luis8763;";

        public Sat ConsultaImpuesto(string placa)
        {
            Sat impuestoConsultado = null;
            string sql = "SELECT IdSAT, Placa, Monto FROM SAT WHERE PLACA=@placa";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@placa", placa));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            impuestoConsultado = new Sat()
                            {
                                idSAT = (int)resultado["IdSAT"],
                                placa = (string)resultado["Placa"],
                                monto = (decimal)resultado["Monto"]
                            };
                        }
                    }
                }
            }
            return impuestoConsultado;
        }
    }
}