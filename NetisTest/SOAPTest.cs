using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace NetisTest
{
    [TestClass]
    public class SOAPTest
    {
        [TestMethod]
        public void TestGenerarContrasena()
        {
            SWRecuperarContrasena.RecuperarContrasenaClient proxy = new SWRecuperarContrasena.RecuperarContrasenaClient();
            string stRespuesta = proxy.RecuperarContrasenaUsuario("jperez@gmail.com");
            Assert.AreEqual("La Contraseña fue enviada al Correo : jperez@gmail.com", stRespuesta);
        }

        [TestMethod]
        public void TestCrearUsuario()
        {
            SWSoap.SWSoapClient proxy = new SWSoap.SWSoapClient();
            try
            {
                SWSoap.UsuarioDominio usuarioCreado = proxy.CrearUsuario(new SWSoap.UsuarioDominio()
                {
                    IdPerfil = 2,
                    Nombre = "Eder",
                    Apellido = "Chuan",
                    Dni = "46109186",
                    Correo = "Ederchhm22@gmail.com",
                    Contraseña = "12345"
                });
            }
            catch (FaultException<SWSoap.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar la creación.", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El Usuario ya existe");
            }
        }

        [TestMethod]
        public void TestCrearSoat()
        {
            SWSoap.SWSoapClient proxy = new SWSoap.SWSoapClient();
            
            SWSoap.SoatDominio soatCreado = proxy.CrearSoat(new SWSoap.SoatDominio()
            {
                Placa = "DRF-623",
                Marca = "Toyota",
                Categoria = "Auto",
                FechaInicio = "2016-10-10",
                Contratante = "Juan",
                Año = 2012,
                Documento = "41859176",
                Modelo = "WSR-OLO",
                NroAsientos = 5,
                Direccion = "Las Flores",
                UsoDiario = "Diario",
                NroSerie = "74845156"
            });

            Assert.AreEqual("DRF-623", soatCreado.Placa);
            Assert.AreEqual("Toyota", soatCreado.Marca);
            Assert.AreEqual("41859176", soatCreado.Documento);
        }

    }
}
