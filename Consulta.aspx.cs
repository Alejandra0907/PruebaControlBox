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
            int giroId = Convert.ToInt32(GridView1.SelectedDataKey.Value);
        }

        private void BindPaises()
        {
            try
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
            catch (Exception ex)
            {
                lblResultados.Text = "Error al cargar los países: " + ex.Message;
            }
        }

        private void BindCiudades()
        {
            try
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
            catch (Exception ex)
            {
                lblResultados.Text = "Error al cargar las ciudades: " + ex.Message;
            }
        }

        private void BindGridView()
        {
            try
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
                        else
                        {
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResultados.Text = "Error al cargar la tabla: " + ex.Message;
            }
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

    }
}




