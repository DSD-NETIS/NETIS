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

    }
}
