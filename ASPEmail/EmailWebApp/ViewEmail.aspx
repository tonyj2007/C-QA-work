<%@ Page Title="" Language="C#" MasterPageFile="~/Auth.master" AutoEventWireup="true" CodeBehind="ViewEmail.aspx.cs" Inherits="EmailWebApp.ViewEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="authhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AuthContentPlaceHolder1" runat="server">
    <% GetEmail(); %>
    <div class="container">
        <a href="Compose.aspx?email=<%=from %>" class="btn btn-default"><span class="glyphicon glyphicon-inbox"></span>Reply</a>
    </div>
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4><%=title %></h4>
        </div>
        <div class="panel-body"><%=body %></div>
        <div class="panel-footer"><%=footer %></div>
    </div>

</asp:Content>
