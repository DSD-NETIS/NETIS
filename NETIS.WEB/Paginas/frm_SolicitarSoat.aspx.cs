using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_frm_SolicitarSoat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:5830/Usuario.svc/Usuario/" + txtPlaca.Value + "/" + dtFechaInicio.Value.ToString());
        HttpWebResponse res = null;
        req.ContentType = "application/json";
        res = (HttpWebResponse)req.GetResponse();
        res = req.GetResponse() as HttpWebResponse;
        StreamReader reader = new StreamReader(res.GetResponseStream());
        string clienteJson = reader.ReadToEnd();
        JavaScriptSerializer js = new JavaScriptSerializer();
        SoatDominio soatDominio = js.Deserialize<SoatDominio>(clienteJson);
        if (soatDominio == null)
        {
            SWSoap.SWSoapClient proxy = new SWSoap.SWSoapClient();
            SWSoap.SoatDominio soat = new SWSoap.SoatDominio();

            soat.Placa = txtPlaca.Value;
            soat.Marca = ddlMarca.SelectedValue;
            soat.FechaInicio = dtFechaInicio.Value.ToString();
            soat.Categoria = txtCategoria.Value;
            soat.Contratante = txtContratante.Value;
            soat.Año = int.Parse(ddlAño.SelectedValue.ToString());
            soat.Documento = txtDocumento.Value;
            soat.Modelo = ddlModelo.SelectedValue.ToString();
            soat.NroAsientos = txtNroAsientos.Value.ToString();
            soat.Direccion = txtDireccion.Value;
            soat.UsoDiario = ddlUso.SelectedValue.ToString();
            soat.NroSerie = txtNroSerie.Value;
            proxy.CrearSoat(soat);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SOAT registrado.')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ya tiene un SOAT Activo.')", true);
        }
            
    }

    public class SoatDominio
    {
        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Categoria { get; set; }

        public string FechaInicio { get; set; }

        public string Contratante { get; set; }

        public int Año { get; set; }

        public string Documento { get; set; }

        public string Modelo { get; set; }

        public int NroAsientos { get; set; }

        public string Direccion { get; set; }

        public string UsoDiario { get; set; }

        public string NroSerie { get; set; }
    }
}