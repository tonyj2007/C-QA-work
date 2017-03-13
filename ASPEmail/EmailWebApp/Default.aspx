<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmailWebApp.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home - Email Web</title>
    <style>
        .col-centered {
            float: none;
            margin: 0 auto;
        }

        .btn {
            margin: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="label-primary text-center">
        <h1>Welcome</h1>
    </span>

    <div class="row">
        <div class="container container-fluid">
            <form runat="server">
                <div class="col-lg-3 col-centered">
                    <asp:Button ID="colorbtn_red" CssClass="btn btn-danger" Text="Red" runat="server" OnClick="ColorBtn_Click" Width="75px" />
                    <asp:Button ID="colorbtn_green" CssClass="btn btn-success" Text="Green" runat="server" OnClick="ColorBtn_Click" Width="75px" />
                    <asp:Button ID="colorbtn_blue" CssClass="btn btn-primary" Text="Blue" runat="server" OnClick="ColorBtn_Click" Width="75px" />
                </div>
                <div class="col-lg-3 col-centered">
                    <asp:Button ID="colorbtn_default" CssClass="btn btn-default" Text="Default" runat="server" OnClick="ColorBtn_Click" Width="240px" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
