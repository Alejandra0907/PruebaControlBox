using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace loginalejandrar
{
    public partial class Consulta : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPaises();
            }
        }

        protected void ddlPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCiudades();
            BindGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tu código para manejar el evento SelectedIndexChanged
        }

        private void BindPaises()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Paises", con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        ddlPaises.DataSource = dr;
                        ddlPaises.DataTextField = "nombre_pais";
                        ddlPaises.DataValueField = "id_pais";
                        ddlPaises.DataBind();
                    }
                }
            }
        }

        private void BindCiudades()
        {
            int idPais = Convert.ToInt32(ddlPaises.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Ciudades WHERE id_pais = @id_pais", con))
                {
                    cmd.Parameters.AddWithValue("@id_pais", idPais);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        ddlCiudades.DataSource = dr;
                        ddlCiudades.DataTextField = "nombre_ciudad";
                        ddlCiudades.DataValueField = "id_ciudad";
                        ddlCiudades.DataBind();
                    }
                }
            }
        }

        private void BindGridView()
        {
            int idCiudad = Convert.ToInt32(ddlCiudades.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT g.gir_giro_id, g.gir_recibo, c.nombre_ciudad FROM giros g INNER JOIN ciudades c ON g.gir_ciudad_id = c.id_ciudad WHERE c.id_ciudad = @id_ciudad", con))
                {
                    cmd.Parameters.AddWithValue("@id_ciudad", idCiudad);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
}