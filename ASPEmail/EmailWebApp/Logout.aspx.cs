using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailWebApp
{
    public partial class Logout : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Abandon session, redirect to login page with confimation message
            Session.Abandon();
            Response.Redirect("/Login.aspx?alert=3");
            //TODO: Check if user logged in before showing message
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}