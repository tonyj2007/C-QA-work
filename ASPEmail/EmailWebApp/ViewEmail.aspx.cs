using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailWebApp
{
    public partial class ViewEmail : System.Web.UI.Page
    {
        protected string title = "Error!";
        protected string body = "Error!";
        protected string footer = "Error!";
        protected string from = null;

        protected void GetEmail()
        {
            DBDataSetTableAdapters.EmailsTableAdapter emailtableadapter = new DBDataSetTableAdapters.EmailsTableAdapter();
            DBDataSet.EmailsDataTable data = emailtableadapter.GetEmailById(Convert.ToInt32(Request["emailid"]));

            if(data[0] != null)
            {
                title = data[0].Subject;
                body = data[0].Text;
                footer = data[0].Date.ToString();
                from = data[0].From;
                emailtableadapter.UpdateRead(true, Convert.ToInt32(Request["emailid"]));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}