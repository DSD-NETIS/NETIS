using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServicioREST.Dominio;

namespace WCFServicioREST.Persistencia
{
    public class UsuarioDAO
    {
        public UsuarioDominio Crear(UsuarioDominio usuarioCrear)
        {
            UsuarioDominio usuarioCreado = null;
            string sql = "INSERT INTO Usuario (Nombre,Apellido,Dni,Correo,Contraseña) VALUES  (@Nombre, @Apellido,@Dni,@Correo,@Contraseña)";
            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    //cmd.Parameters.Add(new SqlParameter("@IdPerfil", usuarioCrear.IdPerfil));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", usuarioCrear.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", usuarioCrear.Apellido));
                    cmd.Parameters.Add(new SqlParameter("@Dni", usuarioCrear.Dni));
                    cmd.Parameters.Add(new SqlParameter("@Correo", usuarioCrear.Correo));
                    cmd.Parameters.Add(new SqlParameter("@Contraseña", usuarioCrear.Contraseña));
                    cmd.ExecuteNonQuery();
                }
            }
            usuarioCreado = Obtener(usuarioCreado.Correo);
            return usuarioCreado;
        }

        public UsuarioDominio Obtener(string Correo)
        {
            UsuarioDominio usuarioEncontrado = null;
            string sql = "SELECT * FROM Usuario WHERE Correo ='" + Correo + "'";
            using (SqlConnection cn = new SqlConnection((Conexion.cadenaConexion)))
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
                                Nombre = (string)reader["Nombre"],
                                Apellido = (string)reader["Apellido"],
                                Correo = (string)reader["Correo"]
                            };
                        }
                    }
                }
            }
            return usuarioEncontrado;
        }

        //OBTENER ACCESO AL SISTEMA
        public AccesoPerfilDominio ObtenerAcceso(string IdPerfil)
        {
            AccesoPerfilDominio accesoEncontrado = null;
            string sql = "SELECT * FROM AccesoDisponible WHERE IdPerfil=" + IdPerfil;
            using (SqlConnection cn = new SqlConnection((Conexion.cadenaConexion)))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            accesoEncontrado = new AccesoPerfilDominio()
                            {
                                IdPerfil = (int)reader["IdPerfil"],
                                HoraInicio = (string)reader["HoraInicio"],
                                HoraFin = (string)reader["HoraFin"]
                            };
                        }
                    }
                }
            }
            return accesoEncontrado;
        }

        public SoatDominio SoatActivo(string Placa, string FechaInicio)
        {
            SoatDominio soatEncontrado = null;
            string sql = "declare @l_fechaInicio datetime = (select convert(datetime,FechaInicio) from soat where placa = '" + Placa + "')" +
                          "declare @l_FechaFin datetime = DateAdd(year,1,@l_fechaInicio) " +
                          "select * from soat where placa = '" + Placa + "' " +
                          "and CONVERT(DATETIME,'" + FechaInicio + "') between @l_fechaInicio AND @l_FechaFin";
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