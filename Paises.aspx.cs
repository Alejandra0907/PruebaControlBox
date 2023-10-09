using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loginalejandrar
{
    public partial class Paises : System.Web.UI.Page
    {
        private string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        private void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Paises", con))
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
        ///Metodo para la creación de pais nuevo
        protected void btnCrearPais_Click(object sender, EventArgs e)
        {
            string nuevoPais = txtNuevoPais.Text;
            if (!string.IsNullOrEmpty(nuevoPais))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Paises (nombre_pais) VALUES (@nombre)", con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nuevoPais);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                BindGridView();
            }
        }
        ///Metodo para la edición de pais
        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }
        ///Botón para cancelar edición
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }
        ///Metodo para la edición de pais 
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["id_pais"]);
            string nuevoNombre = e.NewValues["nombre_pais"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Paises SET nombre_pais = @nombre WHERE id_pais = @id", con))
                {
                    cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            GridView1.EditIndex = -1;
            BindGridView();
        }
        ///Metodo para la eliminación de pais
        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["id_pais"]);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Paises WHERE id_pais = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                BindGridView();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) 
                {
                   
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puede eliminar el país porque está relacionado con una ciudad.');", true);
                }
                else
                {
   
                    throw;
                }
            }
        }
        ///Botón para volver a home
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx"); // Reemplaza "Home.aspx" con la ruta correcta de tu página principal
        }

    }


}
