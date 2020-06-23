using System;
using System.Configuration;
using System.Data.SqlClient;
using WebAppForms.Models;

namespace WebAppForms
{
    public partial class Persons : System.Web.UI.Page
    {
        SqlConnection Connection = null;
        DalPerson DalPerson = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection Connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionBaseDatabase"].ConnectionString);
            Connection.Open();
            DalPerson = new DalPerson(Connection);
            LoadDataGridView(null);
        }
        protected void LoadDataGridView(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                GridViewPerson.DataSource = DalPerson.GetPerson();
            } 
            else
            {
                GridViewPerson.DataSource = DalPerson.GetPerson(name);
            }
            GridViewPerson.DataBind();
        }
        protected void Page_Unload(object sender, EventArgs e)
        { 
            if (Connection != null)
            {
                if (Connection.State == System.Data.ConnectionState.Open) 
                {                    
                    Connection.Close(); 
                }
                Connection.Dispose();
                Connection = null;
            }            
        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadDataGridView(TxtName.Text);
        }        
    }
}