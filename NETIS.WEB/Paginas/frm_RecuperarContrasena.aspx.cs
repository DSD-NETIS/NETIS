using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_frm_RecuperarContrasena : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5830/Usuario.svc/Usuario/" + txtEmail.Value);
        HttpWebResponse res = null;
        req.ContentType = "application/json";
        res = (HttpWebResponse)req.GetResponse();
        res = req.GetResponse() as HttpWebResponse;
        StreamReader reader = new StreamReader(res.GetResponseStream());
        string clienteJson = reader.ReadToEnd();
        JavaScriptSerializer js = new JavaScriptSerializer();
        Usuario usuario = js.Deserialize<Usuario>(clienteJson);
        if (usuario == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El Correo ingresado no se encuentra registrado.')", true);
        }
        else
        {
            req = (HttpWebRequest)WebRequest.Create("http://localhost:5830/Usuario.svc/Usuario/IdPerfil=" + usuario.IdPerfil);
            res = null;
            req.ContentType = "application/json";
            res = (HttpWebResponse)req.GetResponse();
            res = req.GetResponse() as HttpWebResponse;
            reader = new StreamReader(res.GetResponseStream());
            clienteJson = reader.ReadToEnd();
            js = new JavaScriptSerializer();
            AccesoPerfil accesoPerfil = js.Deserialize<AccesoPerfil>(clienteJson);
            int inHoraActual = DateTime.Now.Hour;
            string[] stHoraInicio = accesoPerfil.HoraInicio.Split(':');
            string[] stHoraFin = accesoPerfil.HoraFin.Split(':');
            if (!(inHoraActual >= int.Parse(stHoraInicio[0]) && inHoraActual <= int.Parse(stHoraFin[0])))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El Horario de Acceso está restringido.')", true);
            }
            else
            {
                string stCorreo = txtEmail.Value;
                SWRecuperarContrasena.RecuperarContrasenaClient proxy = new SWRecuperarContrasena.RecuperarContrasenaClient();
                string stRespuesta = proxy.RecuperarContrasenaUsuario(stCorreo);
                if (!stRespuesta.Equals("Correo no existe"))
                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", " alert('" + stRespuesta + "'); window.close();", true);
                else
                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", " alert('" + stRespuesta + "');", true);
            }
        }
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

    public class AccesoPerfil
    {
        public int IdPerfil { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFin { get; set; }
    }
}