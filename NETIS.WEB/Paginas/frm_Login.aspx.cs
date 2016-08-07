using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;


public partial class Paginas_frm_Login : System.Web.UI.Page
{

    public static string cadenaConexion = "Data Source=(local); Initial Catalog=BD_Netis; Integrated Security=SSPI;";

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5830/Usuario.svc/Usuario/" + txtLogin.Value );
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
                string stCorreo = txtLogin.Value;
                string stPassword = txtPassword.Value;
                bool validado = ValidarUsuario(stCorreo, stPassword);

                if (validado)
                {
                    Response.Redirect("frm_Menu.aspx");
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La Contraseña es Incorrecto')", true);
            }
        }
        
        

    }

    public bool ValidarUsuario(string correo, string contrasena)
    {
        bool validado = false;
        string sql = "SELECT 1 FROM Usuario WHERE Correo='" + correo + "' AND Contraseña='" + contrasena + "'";
        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                using (SqlDataReader resultado = comando.ExecuteReader())
                {
                    if (resultado.Read())
                        validado = true;
                }
            }
        }
        return validado;

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