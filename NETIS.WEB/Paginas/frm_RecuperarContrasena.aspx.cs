using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_frm_RecuperarContrasena : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnEnviar_Click(object sender, EventArgs e)
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