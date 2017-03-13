using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailWebApp
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ColorBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.ID)
            {
                case "colorbtn_red":
                    Response.Cookies["theme"].Value = "red";
                    break;
                case "colorbtn_green":
                    Response.Cookies["theme"].Value = "green";
                    break;
                case "colorbtn_blue":
                    Response.Cookies["theme"].Value = "blue";
                    break;
                case "colorbtn_default":
                    Response.Cookies["theme"].Value = null;
                    break;
            }


        }
    }
}