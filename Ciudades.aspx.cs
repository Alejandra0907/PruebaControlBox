using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace loginalejandrar
{
    public partial class Ciudades : System.Web.UI.Page
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
 
        private void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT c.id_ciudad, c.nombre_ciudad, p.nombre_pais FROM Ciudades c INNER JOIN Paises p ON c.id_pais = p.id_pais", con))
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
        ///DropDownList de Paises
        private void BindDropDownList()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Paises", con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        ddlNuevoPais.DataSource = dr;
                        ddlNuevoPais.DataTextField = "nombre_pais";
                        ddlNuevoPais.DataValueField = "id_pais";
                        ddlNuevoPais.DataBind();
                    }
                }
            }
        }
        ///Metodo para la creación de ciudad nueva
        protected void btnCrearCiudad_Click(object sender, EventArgs e)
        {
            string nuevaCiudad = txtNuevaCiudad.Text;
            int idPais = Convert.ToInt32(ddlNuevoPais.SelectedValue);

            if (!string.IsNullOrEmpty(nuevaCiudad) && idPais > 0)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Ciudades (nombre_ciudad, id_pais) VALUES (@nombre_ciudad, @id_pais)", con))
                    {
                        cmd.Parameters.AddWithValue("@nombre_ciudad", nuevaCiudad);
                        cmd.Parameters.AddWithValue("@id_pais", idPais);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                txtNuevaCiudad.Text = "";
                ddlNuevoPais.SelectedIndex = 0;
                BindGridView();
            }
        }
        ///Metodo para la edición de ciudad 
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
        ///Metodo para la edición de ciudad
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int idCiudad = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            TextBox txtNombreCiudad = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNombreCiudadEdit");
            string nuevoNombreCiudad = txtNombreCiudad.Text;

            DropDownList ddlPais = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlPaisEdit");
            int idPais = Convert.ToInt32(ddlPais.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Ciudades SET nombre_ciudad = @nombre_ciudad, id_pais = @id_pais WHERE id_ciudad = @id_ciudad", con))
                {
                    cmd.Parameters.AddWithValue("@nombre_ciudad", nuevoNombreCiudad);
                    cmd.Parameters.AddWithValue("@id_pais", idPais);
                    cmd.Parameters.AddWithValue("@id_ciudad", idCiudad);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            GridView1.EditIndex = -1;
            BindGridView();
        }
        ///Metodo para la eliminación de ciudad
        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int idCiudad = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Ciudades WHERE id_ciudad = @id_ciudad", con))
                    {
                        cmd.Parameters.AddWithValue("@id_ciudad", idCiudad);

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
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puede eliminar la ciudad porque está relacionado con un giro.');", true);
                }
                else
                {
                    throw;
                }
            }
        }
        ///Metodo para ver data
        protected DataTable GetPaises()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Paises", con))
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
        ///Botón para volver a home
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

    }
}
