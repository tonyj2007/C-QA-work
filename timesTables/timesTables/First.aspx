<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="First.aspx.cs" Inherits="timesTables.First" %>
<%-- ASP.NET porject to display hyper links of numbers from 1-300 when you click a number it will redirect to another page and display the
    times tables of that number from 1 to 10 --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%-- Loop that creates numbers 1-300 as hyper links with 20 per line. the number pressed value is sent through the url by setting 
                a variable called T (for times tables) and setting the value of it to the number the user clicks --%>
            <%
                Response.Write("<table align='center' boarder = '1' cellspacing ='5' cellpadding = '5'><tr>");
                for (int a = 1; a <= 300; a++)
                {
                    Response.Write("<td><A href = 'Second.aspx?T=" + a + "'>" + a + "</A></td>");
                    if (a % 20 == 0)
                    {
                        Response.Write("</tr></tr>");
                    }
                }
                Response.Write("</tr></table>");
            %>
        </div>
    </form>
</body>
</html>
