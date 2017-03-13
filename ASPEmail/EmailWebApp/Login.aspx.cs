using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailWebApp
{
    public partial class Login : System.Web.UI.Page
    {

        private void UpdateSession(DBDataSet.UsersRow user, string logged_in = "1")
        {
            Session["LoggedIn"] = logged_in;
            Session["UserName"] = user.Name.ToString();
            Session["UserEmail"] = user.EmailAddress.ToString();
        }

        protected void SignIn_Click(object sender, EventArgs e)
        {
            //Step 1: Get field strings
            string inputemail = emailtextbox.Value.ToString();
            string inputpass = passwordtextbox.Value.ToString();

            //Step 2: Check if credentials exist
            DBDataSetTableAdapters.UsersTableAdapter useradapter = new DBDataSetTableAdapters.UsersTableAdapter();

            DBDataSet.UsersDataTable data = useradapter.GetDataByEmailPassword(inputemail, inputpass);


            if (data != null)
            {
                //Step 3: Login correct, do redirect
                UpdateSession(data[0]);
                if (Request["redirect"] != null)
                {
                    string doredirect = Request["redirect"].ToString();
                    UpdateSession(data[0]);

                    if (doredirect == "1") //Redirect, return to previous path if possible
                    { 
                        if (Session["PrevPath"] != null) Response.Redirect(Session["PrevPath"].ToString());
                        else Response.Redirect("/");
                        return;
                    }

                }
                else
                {
                    //No redirect to previous, return to homepage
                    Response.Redirect("/");
                }
            }
            //Step 3.1: If not found, redirect to the error page
            string path = "/Login.aspx?alert=2";
            if (Request["redirect"] != null) { path += "&redirect=" + Request["redirect"].ToString(); }
            Response.Redirect(path);
        }


        protected void Alert_Composer()
        {
            //Check if alert needed
            if (Request["alert"] != null)
            {
                string alerttype = Request["alert"].ToString(); //get alert string

                switch (alerttype)
                {
                    case "1": //Log in to continue
                        alertcomponent.Attributes["class"] += " alert-block";
                        alertheader.InnerHtml = "Sign in to continue";
                        alertbody.InnerHtml = "This page requires you to sign in before proceeding.";
                        break;
                    case "2": //Login invalid
                        alertcomponent.Attributes["class"] += " alert-error";
                        alertheader.InnerHtml = "Login Unsuccessful!";
                        alertbody.InnerHtml = "Username and password combination could not be verified. Please try again.";
                        break;
                    case "3": //Signed out
                        alertcomponent.Attributes["class"] += " alert-info";
                        alertheader.InnerHtml = "Logged out!";
                        alertbody.InnerHtml = "User logged out successfully.";
                        break;
                    default:
                        return;
                }
                alertcomponent.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Alert_Composer();
        }
    }
}