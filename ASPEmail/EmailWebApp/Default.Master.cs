using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailWebApp
{
    public partial class Default : System.Web.UI.MasterPage
    {

        protected string GetTheme(string cookie_name = "theme")
        {
            if(Response.Cookies[cookie_name].Value != null)
            {
                return Response.Cookies[cookie_name].Value.ToString();
            }
            return null;
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //Keeps track of previous page
            if (Session["PrevPath"] != null)
            {
                Session["PrevPath"] = Session["CurrPath"];
            }
            Session["CurrPath"] = HttpContext.Current.Request.Url.AbsolutePath;

            //Set login items
            if(Session["LoggedIn"]!=null)
            {
                if(Session["LoggedIn"].ToString()=="1")
                {
                    loginlogoutAnchor.HRef = "/Logout.aspx";
                    loginlogoutlabel.Text = "Logout";
                    userlabel.Text = Session["UserName"].ToString();
                }
            }
            

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}