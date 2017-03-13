using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailWebApp
{
    public partial class Register : System.Web.UI.Page
    {

        //   DBDataSetTableAdapters.UsersTableAdapter useradapter = new DBDataSetTableAdapters.UsersTableAdapter();
        //   DBDataSet.UsersDataTable data = useradapter.GetDataByEmailPassword(inputemail, inputpass);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBTN_Click(object sender, EventArgs e)
        {
            DBDataSetTableAdapters.UsersTableAdapter registerAdapter = new DBDataSetTableAdapters.UsersTableAdapter();
            DBDataSet.UsersDataTable dataSet = registerAdapter.GetDataByEmailAddress(EmailAddress.Text);

            if (dataSet.Count != 0)
            {
                AlertBox.Visible = true;
            }
            else
            {
                registerAdapter.registerUser(EmailAddress.Text, Name.Text, Address.Text, DropDownList1.Text, Answer.Value, Password.Text);
            }
        }
    }
}