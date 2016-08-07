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

        
    }
}
