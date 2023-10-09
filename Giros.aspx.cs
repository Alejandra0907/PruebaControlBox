using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loginalejandrar
{
    public partial class Giros : System.Web.UI.Page
    {
        private string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            if (!IsPostBack)
            {
                BindGridView();
                BindDropDownList();
            }
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int idGiro = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            TextBox txtReciboEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtReciboEdit");
            int idCiudad = Convert.ToInt32(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlCiudadEdit")).SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE giros SET gir_recibo = @recibo, gir_ciudad_id = @ciudad WHERE gir_giro_id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@recibo", txtReciboEdit.Text);
                    cmd.Parameters.AddWithValue("@ciudad", idCiudad);
                    cmd.Parameters.AddWithValue("@id", idGiro);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int idGiro = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM giros WHERE gir_giro_id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", idGiro);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            BindGridView();
        }

        protected void btnCrearGiro_Click(object sender, EventArgs e)
        {
            string nuevoGiro = txtNuevoGiro.Text;
            int idCiudad = Convert.ToInt32(ddlNuevaCiudad.SelectedValue);

            if (!string.IsNullOrEmpty(nuevoGiro) && idCiudad > 0)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO giros (gir_recibo, gir_ciudad_id) VALUES (@recibo, @ciudad)", con))
                    {
                        cmd.Parameters.AddWithValue("@recibo", nuevoGiro);
                        cmd.Parameters.AddWithValue("@ciudad", idCiudad);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                txtNuevoGiro.Text = "";
                ddlNuevaCiudad.SelectedIndex = 0;
                BindGridView();
            }
        }

        protected DataTable GetCiudades()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ciudades", con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                }
            }

            return dt;
        }

        protected void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT g.gir_giro_id, g.gir_recibo, c.nombre_ciudad FROM giros g INNER JOIN ciudades c ON g.gir_ciudad_id = c.id_ciudad", con))
                {
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

        protected void BindDropDownList()
        {
            ddlNuevaCiudad.DataSource = GetCiudades();
            ddlNuevaCiudad.DataTextField = "nombre_ciudad";
            ddlNuevaCiudad.DataValueField = "id_ciudad";
            ddlNuevaCiudad.DataBind();
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}