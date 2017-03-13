using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailWebApp
{
    public partial class Inbox : System.Web.UI.Page
    {
        DBDataSetTableAdapters.EmailsTableAdapter emailsadapter = new DBDataSetTableAdapters.EmailsTableAdapter();
        [WebMethod]
        public static string Delete(string[] Selected)
        {
            DBDataSetTableAdapters.EmailsTableAdapter emailstableadapter = new DBDataSetTableAdapters.EmailsTableAdapter();
            foreach (string x in Selected)
            {
                emailstableadapter.UpdateDeleted(true, Convert.ToInt32(x));
            }
            return "true";
        }

        [WebMethod]
        public static string UnDelete(string[] Selected)
        {
            DBDataSetTableAdapters.EmailsTableAdapter emailstableadapter = new DBDataSetTableAdapters.EmailsTableAdapter();
            foreach (string x in Selected)
            {
                emailstableadapter.UpdateDeleted(false, Convert.ToInt32(x));
            }


            return "true";
        }

        [WebMethod]
        public static string MarkRead(string[] Selected)
        {
            DBDataSetTableAdapters.EmailsTableAdapter emailstableadapter = new DBDataSetTableAdapters.EmailsTableAdapter();
            foreach (string x in Selected)
            {
                emailstableadapter.UpdateRead(true, Convert.ToInt32(x));
            }


            return "true";
        }

        [WebMethod]
        public static string MarkUnread(string[] Selected)
        {
            DBDataSetTableAdapters.EmailsTableAdapter emailstableadapter = new DBDataSetTableAdapters.EmailsTableAdapter();
            foreach (string x in Selected)
            {
                emailstableadapter.UpdateRead(false, Convert.ToInt32(x));
            }


            return "true";
        }



        protected List<List<String>> GetEmails()
        {

            string USER_EMAIL = Session["UserEmail"].ToString();
            DBDataSet.EmailsDataTable data = null;

            if (Request["filter"] != null)
            {
                if (Request["filter"].ToString() == "deleted")
                {
                    data = emailsadapter.UserEmailsGetData(USER_EMAIL, true);
                    InboxTitle.InnerHtml = "Deleted";
                }
                else if (Request["filter"].ToString() == "unread")
                {
                    data = emailsadapter.UserEmailsGetDataByReadDeleted(USER_EMAIL, false, false);
                    InboxTitle.InnerHtml = "Unread";
                }
                else if (Request["filter"].ToString() == "read")
                {
                    data = emailsadapter.UserEmailsGetDataByReadDeleted(USER_EMAIL, true, false);
                    InboxTitle.InnerHtml = "Read";
                }
            }

            if (data == null)
            {
                data = emailsadapter.UserEmailsGetData(USER_EMAIL, false);
            }

            List<List<String>> emailList = new List<List<string>> { };

            foreach (DBDataSet.EmailsRow email in data)
            {
                List<String> emailcontents = new List<string> { };

                emailcontents.Add(email.ID.ToString());
                emailcontents.Add(email.From);
                emailcontents.Add(email.Subject);
                emailcontents.Add(email.Text);
                emailcontents.Add(email.Date.ToString());
                emailcontents.Add(email.Read.ToString());

                emailList.Add(emailcontents);
            }

            return emailList;


        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class Email
        {
            public int ID;
            public string To, From, Subject, Text;
            public DateTime Date;
            public bool Read, Deleted;

            public Email(DBDataSet.EmailsRow email)
            {
                ID = email.ID;
                To = email.To;
                From = email.From;
                Subject = email.Subject;
                Text = email.Text;
                Date = email.Date;
                Read = email.Read;
                Deleted = email.Deleted;
            }
        }
    }
}