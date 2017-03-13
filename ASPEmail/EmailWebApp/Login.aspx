<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmailWebApp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="alertcomponent" class="alert" runat="server" visible="false">
        <button type="button" class="close" data-dismiss="alert">&times;</button>
        <h4><span id="alertheader" runat="server">Alert Header</span></h4>
        <span id="alertbody" runat="server">Alert Body</span>
    </div>

    <form runat="server">
        <div class="input-group">
            <input type="text" class="form-control" placeholder="Email" runat="server" id="emailtextbox" />
        </div>
        <br />
        <div class="input-group">
            <input type="password" class="form-control" placeholder="Password" runat="server" id="passwordtextbox" />
        </div>
        <br />
        <div class="input-group">
            <asp:Button CssClass="btn btn-primary" type="button" runat="server" Text="Sign In" OnClick="SignIn_Click" />
            <a href="/Register.aspx" class="btn btn-link">Register</a>
        </div>
    </form>

</asp:Content>
