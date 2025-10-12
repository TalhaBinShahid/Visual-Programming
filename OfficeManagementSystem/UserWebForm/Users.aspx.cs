using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppProps;
using BusinessLogicLayer;

namespace UserWebForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        UserBLL BLL = new UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            User U = new User()
            {
                Name = TxtName.Text,
                Email = TxtEmail.Text,
                Address = TxtAddress.Text
            };

            if (BLL.InsertUserBLL(U))
            {
                LoadData();
                ClearFields();
                LabResult.Text = "Data saved successfully";
            }
            else
            {
                LabResult.Text = "Error: data not saved";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DDLUsers.SelectedValue))
            {
                User U = new User()
                {
                    Id = int.Parse(DDLUsers.SelectedValue),
                    Name = TxtName.Text,
                    Email = TxtEmail.Text,
                    Address = TxtAddress.Text
                };

                if (BLL.UpdateUserBLL(U))
                {
                    LoadData();
                    ClearFields();
                    LabResult.Text = "Data updated successfully";
                }
                else
                {
                    LabResult.Text = "Error: data not updated";
                }
            }
            else
            {
                LabResult.Text = "Please select a user to update record";
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DDLUsers.SelectedValue))
            {
                User U = new User()
                {
                    Id = int.Parse(DDLUsers.SelectedValue)
                };

                if (BLL.DeleteUserBLL(U))
                {
                    LoadData();
                    ClearFields();
                    LabResult.Text = "Data deleted successfully";
                }
                else
                {
                    LabResult.Text = "Error: data not deleted";
                }
            }
            else
            {
                LabResult.Text = "Please select a user to delete the record";
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DDLUsers.SelectedValue))
            {
                User U = new User()
                {
                    Id = int.Parse(DDLUsers.SelectedValue)
                };

                DataTable Dt = BLL.UserSearchBLL(U);

                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    TxtName.Text = row["Name"].ToString();
                    TxtEmail.Text = row["Email"].ToString();
                    TxtAddress.Text = row["Address"].ToString();
                    LabResult.Text = "User found and loaded for editing";
                }
                else
                {
                    LabResult.Text = "User not found";
                    ClearFields();
                }
            }
            else
            {
                LabResult.Text = "Please select a user to search";
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            TxtName.Text = "";
            TxtEmail.Text = "";
            TxtAddress.Text = "";
            LabResult.Text = "";
            DDLUsers.ClearSelection();
        }

        private void LoadData()
        {
            DataTable Dt = BLL.GetUsersBLL();
            CRUDGrid.DataSource = Dt;
            CRUDGrid.DataBind();

            DDLUsers.DataSource = Dt;
            DDLUsers.DataTextField = "Name";
            DDLUsers.DataValueField = "Id";
            DDLUsers.DataBind();
            DDLUsers.Items.Insert(0, new ListItem("-- Select User --", ""));
        }
    }
}