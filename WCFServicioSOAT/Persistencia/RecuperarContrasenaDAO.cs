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

        public SoatDominio CrearSoat(SoatDominio crearSoat)
        {
            SoatDominio soatEncontrar = null;
            string sql = "INSERT INTO SOAT ([Placa],[Marca],[Categoria],[FechaInicio],[Contratante],[Año],[Documento],[Modelo],[NroAsientos],[Direccion],[UsoDiario],[NroSerie]) VALUES(@Placa,@Marca,@Categoria,@FechaInicio,@Contratante,@Año,@Documento,@Modelo,@NroAsientos,@Direccion,@UsoDiario,@NroSerie)";
            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Placa", crearSoat.Placa));
                    cmd.Parameters.Add(new SqlParameter("@Marca", crearSoat.Marca));
                    cmd.Parameters.Add(new SqlParameter("@Categoria", crearSoat.Categoria));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", crearSoat.FechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@Contratante", crearSoat.Contratante));
                    cmd.Parameters.Add(new SqlParameter("@Año", crearSoat.Año));
                    cmd.Parameters.Add(new SqlParameter("@Documento", crearSoat.Documento));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", crearSoat.Modelo));
                    cmd.Parameters.Add(new SqlParameter("@NroAsientos", crearSoat.NroAsientos));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", crearSoat.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@UsoDiario", crearSoat.UsoDiario));
                    cmd.Parameters.Add(new SqlParameter("@NroSerie", crearSoat.NroSerie));
                    cmd.ExecuteNonQuery();
                }
            }
            soatEncontrar = ObtenerSoat(crearSoat.Placa);
            return soatEncontrar;
        }

        public SoatDominio ObtenerSoat(string stPlaca)
        {
            SoatDominio soatEncontrado = null;
            string sql = "SELECT * FROM Soat WHERE placa ='" + stPlaca+ "'";
            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            soatEncontrado = new SoatDominio()
                            {
                                Placa = (string)reader["Placa"],
                                Marca = (string)reader["Marca"],
                                Categoria = (string)reader["Categoria"],
                                FechaInicio = (string)reader["FechaInicio"],
                                Contratante = (string)reader["Contratante"],
                                Año = (int)reader["Año"],
                                Documento = (string)reader["Documento"],
                                Modelo = (string)reader["Modelo"],
                                NroAsientos = (int)reader["NroAsientos"],
                                Direccion = (string)reader["Direccion"],
                                UsoDiario = (string)reader["UsoDiario"],
                                NroSerie = (string)reader["NroSerie"],

                            };
                        }
                    }
                }
            }
            return soatEncontrado;
        }

        public SoatDominio SoatActivo(string Placa,string FechaInicio)
        {
            SoatDominio soatEncontrado = null;
            string sql = "declare @l_fechaInicio datetime = (select convert(datetime,FechaInicio) from soat where placa = 'D2F-896' ) " +
                          "declare @l_FechaFin datetime = DateAdd(year,1,@l_fechaInicio) " +
                          "select * from soat where placa = 'D2F-896' " +
                          "and CONVERT(DATETIME,FechaInicio) between @l_fechaInicio AND @l_FechaFin";
            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            soatEncontrado = new SoatDominio()
                            {
                                Placa = (string)reader["Placa"],
                                Marca = (string)reader["Marca"],
                                Categoria = (string)reader["Categoria"],
                                FechaInicio = (string)reader["FechaInicio"],
                                Contratante = (string)reader["Contratante"],
                                Año = (int)reader["Año"],
                                Documento = (string)reader["Documento"],
                                Modelo = (string)reader["Modelo"],
                                NroAsientos = (int)reader["NroAsientos"],
                                Direccion = (string)reader["Direccion"],
                                UsoDiario = (string)reader["UsoDiario"],
                                NroSerie = (string)reader["NroSerie"],

                            };
                        }
                    }
                }
            }
            return soatEncontrado;
        }
         
    }
}