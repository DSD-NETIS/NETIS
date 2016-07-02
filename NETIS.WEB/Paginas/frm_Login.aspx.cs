using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_frm_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        if (txtLogin.Value.Equals("admin@netis.com"))
        {
            if (txtPassword.Value.Equals("12345"))
            {
                Response.Redirect("frm_Menu.aspx");
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La Contraseña es Incorrecto')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El Usuario es Incorrecto')", true);
        }
    }
   
}