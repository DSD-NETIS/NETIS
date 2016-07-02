using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_frm_Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbListado_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_ListaSoat.aspx");
    }
    protected void lbSolicitar_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_SolicitarSoat.aspx");
    }
}