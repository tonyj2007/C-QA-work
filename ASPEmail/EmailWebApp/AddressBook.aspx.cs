using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailWebApp
{
    public partial class AddressBook : System.Web.UI.Page
    {
        public DBDataSetTableAdapters.UsersTableAdapter addressBookAdapter;
        public DBDataSet.UsersDataTable data;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAddressBook();
        }
        protected void loadAddressBook()
        {
            addressBookAdapter = new DBDataSetTableAdapters.UsersTableAdapter();
            data = addressBookAdapter.GetData();
            if (data != null)
            {
                //< table >< tr >< td ></ td ></ tr ></ table >
                Response.Write("<table align='center'><tr><td style='width: 200px'>Contact name</td><td style='width: 200px'>Contact email</td></tr>");
                foreach (DataRow myRow in data.Rows)
                {
                    Response.Write("<tr><td style = 'width: 200px' >"+ myRow["name"]+ "</td>");
                    Response.Write("<td style='width:200px'><a href = 'Compose.aspx?email="+myRow["EmailAddress"].ToString()+"'>" + myRow["EmailAddress"]+ "</a></tr>");
                }
                Response.Write("<td></tr></table>");
            }
        }
    }
}