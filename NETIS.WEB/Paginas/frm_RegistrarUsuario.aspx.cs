using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class Paginas_frm_RegistrarUsuario : System.Web.UI.Page
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
            UsuarioDominio usuarioDominio = js.Deserialize<UsuarioDominio>(clienteJson);
            if (usuarioDominio == null)
            {
                req = (HttpWebRequest)WebRequest.Create("http://localhost:5830/Usuario.svc/Usuario/Contrasena=" + txtContrasea.Value);
                res = null;
                res = (HttpWebResponse)req.GetResponse();
                res = req.GetResponse() as HttpWebResponse;
                reader = new StreamReader(res.GetResponseStream());
                clienteJson = reader.ReadToEnd();
                if (clienteJson == "false")
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El primer caracter de la contraseña debe ser mayúsculas.')", true);
                else
                {
                    SWSoap.SWSoapClient proxy = new SWSoap.SWSoapClient();
                    SWSoap.UsuarioDominio usuario = new SWSoap.UsuarioDominio();

                    usuario.IdPerfil = 2;
                    usuario.Nombre = txtNombre.Value;
                    usuario.Apellido = txtApellido.Value;
                    usuario.Correo = txtEmail.Value;
                    usuario.Dni = txtDni.Value;
                    usuario.Contraseña = txtContrasea.Value;
                    proxy.CrearUsuario(usuario);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario registrado.')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El correo ingresado ya se encuentra asociado a otro usuario.')", true);
            }

        }
    }

    public class UsuarioDominio
    {
        public string IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }

