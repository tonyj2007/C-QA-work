<%@ Page Title="" Language="C#" MasterPageFile="~/Auth.master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="EmailWebApp.Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="authhead" runat="server">
    <style>
        .btn-separator:after {
            content: ' ';
            display: block;
            float: left;
            background: #ADADAD;
            margin: 0 10px;
            height: 34px;
            width: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AuthContentPlaceHolder1" runat="server">
    <script>
        var Selected = [];
        function OnItemClick(X) {

            if (X.selected == "0" || X.selected == null) {
                X.style = "background:lightgrey;";
                X.selected = "1";
                Selected.push(X.id);
            }
            else {
                X.style = "background:white";
                X.selected = "0";
                var index = Selected.indexOf(X.id);
                if (index > -1) {
                    Selected.splice(index, 1);
                }
            }
            if (Selected.length > 0) {
                document.getElementById("selectedbuttongroup").style = "visibility: visible";
            }
            else {
                document.getElementById("selectedbuttongroup").style = "visibility: hidden";
            }
        }

        function OnDeleteClick() {
            $.ajax({
                type: "POST",
                url: "/Inbox.aspx/Delete",
                data: JSON.stringify({ Selected: Selected }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    //Successfully gone to the server and returned with the string result of the server side function do what you want with the result  
                    location.reload();
                }
                  , error(er) {
                      //Faild to go to the server alert(er.responseText)
                  }
            });
        }
        function OnUnDeleteClick() {
            $.ajax({
                type: "POST",
                url: "/Inbox.aspx/UnDelete",
                data: JSON.stringify({ Selected: Selected }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    //Successfully gone to the server and returned with the string result of the server side function do what you want with the result  
                    location.reload();
                }
                  , error(er) {
                      //Faild to go to the server alert(er.responseText)
                  }
            });
        }
        function OnReadClick() {
            $.ajax({
                type: "POST",
                url: "/Inbox.aspx/MarkRead",
                data: JSON.stringify({ Selected: Selected }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    //Successfully gone to the server and returned with the string result of the server side function do what you want with the result  
                    location.reload();
                }
                  , error(er) {
                      //Faild to go to the server alert(er.responseText)
                  }
            });
        }
        function OnUnreadClick() {
            $.ajax({
                type: "POST",
                url: "/Inbox.aspx/MarkUnread",
                data: JSON.stringify({ Selected: Selected }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    //Successfully gone to the server and returned with the string result of the server side function do what you want with the result  
                    location.reload();
                }
                  , error(er) {
                      //Faild to go to the server alert(er.responseText)
                  }
            });
        }

    </script>

    <h4 runat="server" id="InboxTitle"></h4>
    <div class="well well-sm">
        <a class="btn btn-sm btn-default" href="/Inbox.aspx">Inbox</a>
        <a class="btn btn-sm btn-default" href="/Inbox.aspx?filter=unread">Unread</a>
        <a class="btn btn-sm btn-default" href="/Inbox.aspx?filter=read">Read</a>
        <a class="btn btn-sm btn-default" href="/Inbox.aspx?filter=deleted">Deleted</a>
        <span id="selectedbuttongroup" style="visibility: hidden">
            <%
                if (Request["filter"] != null)
                {
                    if (Request["filter"].ToString() == "deleted")
                    { %>
                        <button class="btn btn-sm btn-success" id="undeletebtn" onclick="OnUnDeleteClick()">Revert</button>
                    <% }
                }
                else
                { %>
                   <button class="btn btn-sm btn-danger" id="deletebtn" onclick="OnDeleteClick()">Delete</button>
             <% }
            %>
            <button class="btn btn-sm btn-info" id="readbtn" onclick="OnReadClick()">Mark Read</button>
            <button class="btn btn-sm btn-info" id="unreadbtn" onclick="OnUnreadClick()">Mark Unread</button>

        </span>
    </div>

    <div class="list-group" id="inboxdiv">
        <% foreach (List<string> email in GetEmails())
            { %>
        <div class="list-group-item" id="<%=email[0]%>" selected="0" onclick="OnItemClick(this)">
            <% 
                if (email[5] == "True")
                { %>
            <h4 class="list-group-item-heading">From: <%=email[1]%> Subject: <%=email[2]%></h4>
            <%}
                else
                { %>
            <h4 class="list-group-item-heading"><b>From: <%=email[1]%> Subject: <%=email[2]%></b></h4>
            <%}; %>
            <a href="ViewEmail.aspx?emailid=<%=email[0] %>" class="btn btn-sm btn-default">View</a>
            <div class="list-group-item-text"><%=email[4]%></div>
        </div>
        <% }; %>
    </div>



</asp:Content>
