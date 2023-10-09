using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loginalejandrar
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ///Botón para ingresar a la tabla y crud de Paises
        protected void BtnPaises_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("Paises.aspx");
        }
        ///Botón para ingresar a la tabla y crud de Ciudades
        protected void BtnCiudades_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("Ciudades.aspx");
        }
        ///Botón para ingresar a la tabla y crud de Giros
        protected void BtnGiros_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("Giros.aspx");
        }
        ///Botón para ingresar a la tablade Consulta
        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("Consulta.aspx");
        }
    }
}