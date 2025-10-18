using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLProcedure
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string ConnectionString = "Data Source=Talha-ZBook\\SQLEXPRESS;Initial Catalog=UserInputDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                LoadGridViewAndDDL();
            }

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUser";
            cmd.Parameters.AddWithValue("@Id", DDLUsers.SelectedValue.ToString());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if(dt.Rows.Count > 0)
            {
                TxtName.Text = dt.Rows[0]["Name"].ToString();
                TxtEmail.Text = dt.Rows[0]["Email"].ToString();
                TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertUser";
            cmd.Parameters.AddWithValue("@Name", TxtName.Text);
            cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                //Load Grid view and DDL
                LoadGridViewAndDDL();
            }
            else
            {
                LabResult.Text = "Erro: Data not saved!";
            }
            con.Close();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateUser";
            cmd.Parameters.AddWithValue("@Id", DDLUsers.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Name", TxtName.Text);
            cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                //Load Grid view and DDL
                LoadGridViewAndDDL();
            }
            else
            {
                LabResult.Text = "Erro: Data not Updated!";
            }
            con.Close();

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteUser";
            cmd.Parameters.AddWithValue("@Id", DDLUsers.SelectedValue.ToString());
            if (cmd.ExecuteNonQuery() > 0)
            {
                //Load Grid view and DDL
                LoadGridViewAndDDL();
            }
            else
            {
                LabResult.Text = "Erro: Data not Deleted!";
            }
            con.Close();

        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            TxtName.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtAddress.Text = string.Empty;
            if (DDLUsers.Items.Count > 0)
            {
                DDLUsers.ClearSelection();
            }
            LabResult.Text = string.Empty;
            TxtName.Focus();

        }

        private void LoadGridViewAndDDL()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUsers";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            GVUsers.DataSource = dt;
            GVUsers.DataBind();
            DDLUsers.DataSource = dt;
            DDLUsers.DataTextField = "Name";
            DDLUsers.DataValueField = "Id";
            DDLUsers.DataBind();
        }
    }
}