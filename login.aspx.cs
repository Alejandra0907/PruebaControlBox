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
    public partial class login : System.Web.UI.Page
    {
        string patron = "alejandrar";

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlconectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("sp_validarusuario", sqlconectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@pnombre", SqlDbType.VarChar, 50).Value = tbUsuario.Text;
            cmd.Parameters.Add("@passw", SqlDbType.VarChar, 50).Value = tbPassword.Text;
            cmd.Parameters.Add("@patron", SqlDbType.VarChar, 50).Value = patron;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["usuariologueado"] = tbUsuario.Text;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblError.Text = "Error de usuario o Contraseña";

            }
            cmd.Connection.Close();
        }
    }
}