using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServicioSOAT.Dominio;

namespace WCFServicioSOAT.Persistencia
{
    public class RecuperarContrasenaDAO
    {
        public string cadenaConexion = Conexion.cadenaConexion;
        
        public string RecuperarContrasena(string stCorreo)
        {
            RecuperarContrasenaDominio recuperarContrasenaDominio = new RecuperarContrasenaDominio();
            recuperarContrasenaDominio = ObtenerPorCorreo(stCorreo);
            int result = 0;
            if (recuperarContrasenaDominio != null)
            {
                string stContrasena = GenerarContrasena();
                string sql = "UPDATE Usuario SET Contraseña = '" + stContrasena + "' WHERE IdUsuario =@IdUsuario";
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdUsuario", recuperarContrasenaDominio.IdUsuario));
                        result = comando.ExecuteNonQuery();
                    }
                }
            }
            if (result > 0)
                return "La Contraseña fue enviada al Correo : " + stCorreo;
            else
                return "Correo es incorrecto";

        }

        public RecuperarContrasenaDominio ObtenerPorCorreo(string stCorreo)
        {
            
            RecuperarContrasenaDominio clienteEncontrado = null;
            string sql = "SELECT IdUsuario,Correo FROM Usuario WHERE Correo='" + stCorreo + "'";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new RecuperarContrasenaDominio()
                            {
                                IdUsuario = (int)resultado[0],
                                Correo = resultado[1].ToString()
                            };
                        }
                    }
                }
            }
            return clienteEncontrado;
        }

        public string GenerarContrasena()
        {
            string contrasenaNueva = "";
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random rdm = new Random();
            int longitud = posibles.Length;
            char letra;
            for (int i = 0; i < 10; i++)
            {
                letra = posibles[rdm.Next(longitud)];
                contrasenaNueva += letra.ToString();
            }

            return contrasenaNueva;
        }
          
    }
}