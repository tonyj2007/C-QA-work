using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailWebApp
{
    public partial class Compose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["email"] != null)
            {
                string emailToText = Request["email"].ToString();
                emailTo.Value = emailToText;
            }
        }

        protected void sendEmail_Click(object sender, EventArgs e)
        {
            DBDataSetTableAdapters.EmailsTableAdapter composeEmailAdapter = new DBDataSetTableAdapters.EmailsTableAdapter();
            composeEmailAdapter.insertEmail(Session["UserEmail"].ToString(), emailTo.Value, subjectText.Value, emailText.Value);
            string ccIsEmpty = CCtext.Value.Trim();
            if (CCtext.Value != "")
            {
                composeEmailAdapter.insertEmail(Session["UserEmail"].ToString(), CCtext.Value, subjectText.Value, emailText.Value);
            }
            Response.Redirect("/Inbox.aspx");
        }
    }
}