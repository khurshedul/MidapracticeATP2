using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mid_practice
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SBC"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT * FROM users";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
           // ds.Tables["users"].PrimaryKey = new DataColumn[] { ds.Tables["Users"].Columns["id"] };
            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;
            GridView1.DataSource = ds.Tables["users"];
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataSet ds = (DataSet)Cache["DATASET"];
            //Response.Write( ds.Tables["Users"].Columns["Userid"].ToString());
            //GridView1.DataSource = ds.Tables["Users"];
        }
    }
}