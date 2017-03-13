<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EmailWebApp.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="AlertBox" class="alert alert-warning alert-dismissable" visible="false" runat="server">
        <a href="#" class="close" data-dismiss="alert" aria-label="close"><b>X</b></a>
        <strong>Warning Email Address already in use, Please use a different one!</strong> This alert box could indicate a warning that might need attention.
    </div>
    <form id="registerForm" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <div class="input-group">
                        <asp:TextBox ID="Name" runat="server" placeholder="Name" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="container">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Text="First pet" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Birth town" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Favorite football team" Value="3"></asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <div class="input-group">
                        <asp:TextBox ID="EmailAddress" runat="server" placeholder="Email Address" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <textarea id="Answer" runat="server" placeholder="Enter secret answer here" style="resize: none;" spellcheck="True" required="required"></textarea>
                    <div>
                        <div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <div class="input-group">
                        <asp:TextBox ID="Address" runat="server" placeholder="Address" required="required"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <div class="input-group">
                        <asp:TextBox ID="Password" runat="server" placeholder="Password" required="required"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <div class="input-group">
                        <asp:TextBox ID="ConfirmPassword" runat="server" placeholder="Confirm Password" required="required"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Button ID="registerBTN" CssClass="btn btn-success" runat="server" Text="Register" OnClick="registerBTN_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
