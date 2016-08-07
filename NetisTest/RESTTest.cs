using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace NetisTest
{
    [TestClass]
    public class RESTTest
    {
        [TestMethod]
        public void TestObtener()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5830/Usuario.svc/Usuario/jperez@gmail.com");
            HttpWebResponse res = null;
            req.ContentType = "application/json";
            res = (HttpWebResponse)req.GetResponse();
            res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Usuario usuario = js.Deserialize<Usuario>(clienteJson);
            Assert.AreEqual(1, usuario.IdPerfil);
        }

        [TestMethod]
        public void TestAccesoPerfil()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5830/Usuario.svc/Usuario/IdPerfil=1");
            HttpWebResponse res = null;
            req.ContentType = "application/json";
            res = (HttpWebResponse)req.GetResponse();
            res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            AccesoPerfil accesoPerfil = js.Deserialize<AccesoPerfil>(clienteJson);

            Assert.AreEqual(1, accesoPerfil.IdPerfil);
        }

        [TestMethod]
        public void TestCompararContrasena()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5830/Usuario.svc/Usuario/Contrasena=A12338");
            HttpWebResponse res = null;
            req.ContentType = "application/json";
            res = (HttpWebResponse)req.GetResponse();
            res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            Assert.AreEqual("true", clienteJson);
        }



        public class AccesoPerfil
        {
            public int IdPerfil { get; set; }

            public string HoraInicio { get; set; }

            public string HoraFin { get; set; }
        }

        public class Usuario
        {
            public int IdPerfil { get; set; }

            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public string Dni { get; set; }

            public string Correo { get; set; }

            public string Contraseña { get; set; }
        }
           
    }
}
