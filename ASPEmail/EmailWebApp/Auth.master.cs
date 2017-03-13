using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * AUTHENTICATED PAGES NESTED MASTER PAGE
 *      Child of Default.master, extends functionality to control access to pages that require a login.
 */

namespace EmailWebApp
{
    public partial class Auth : System.Web.UI.MasterPage
    {
        
        protected override void OnInit(EventArgs e)
        {
            /* On Page Init (pre-load fun times)
             *      Triggered when the page is initially called, before it actually loads.
             *      Checks for auth, redirects to login page if needed.
             */
            base.OnInit(e);

            if(Session["LoggedIn"]!= null)
            {
                if (Session["loggedIn"].ToString() == "1") return;
            }
            Response.Redirect("/Login.aspx?alert=1&redirect=1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}