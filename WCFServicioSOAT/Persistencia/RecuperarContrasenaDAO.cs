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
                return "La Contraseña cambiada" ;
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

        public UsuarioDominio CrearUsuario(UsuarioDominio usuarioCrear)
        {
            UsuarioDominio usuarioEncontrar = null;
            string sql = "INSERT INTO Usuario (IdPerfil,Nombre,Apellido,Dni, Correo,Contraseña) VALUES (@IdPerfil,@Nombre,@Apellido,@Dni,@Correo,@Contraseña)";
            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("@IdPerfil", usuarioCrear.IdPerfil));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", usuarioCrear.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", usuarioCrear.Apellido));
                    cmd.Parameters.Add(new SqlParameter("@Dni", usuarioCrear.Dni));
                    cmd.Parameters.Add(new SqlParameter("@Correo", usuarioCrear.Correo));
                    cmd.Parameters.Add(new SqlParameter("@Contraseña", usuarioCrear.Contraseña));
                    cmd.ExecuteNonQuery();
                }
            }
            usuarioEncontrar = Obtener(usuarioCrear.Correo);
            return usuarioEncontrar;
        }

        public UsuarioDominio Obtener(string stCorreo)
        {
            UsuarioDominio usuarioEncontrado = null;
            string sql = "SELECT * FROM Usuario WHERE correo ='" + stCorreo + "'";
            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuarioEncontrado = new UsuarioDominio()
                            {
                                IdPerfil = (int)reader["IdPerfil"],
                                Dni = (string)reader["Dni"],
                                Nombre = (string)reader["Nombre"],
                                Apellido = (string)reader["Apellido"],
                                Correo = (string)reader["Correo"],
                                Contraseña = (string)reader["Contraseña"]
                            };
                        }
                    }
                }
            }
            return usuarioEncontrado;
        }
         
    }
}