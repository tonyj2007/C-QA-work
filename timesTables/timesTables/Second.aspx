<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Second.aspx.cs" Inherits="timesTables.Second" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%-- receives the T value (the number the user clicked on the first page ) then works out the times tables from 1 - 10 and prints them to the screen --%>
            <%
                try
                {
                    int timesTableNumber = Convert.ToInt32(Request["t"]);
                    Response.Write("<h1><center> Times Table of " + timesTableNumber + "</center></h1>");
                    Response.Write("<table align='center'>");
                    for (int i = 1; i <=10; i++)
                    {
                        Response.Write("<tr><td>"+timesTableNumber+"</td><td>"+" *"+"</td><td>" + i + "</td><td> = </td><td>"+ (timesTableNumber*i+"</td></tr>"));
                    }
                    Response.Write("</table>");
                }
                catch (Exception) { Response.Write("<center>Expecting numeric value</center>"); }
            %>
        </div>
    </form>
</body>
</html>
