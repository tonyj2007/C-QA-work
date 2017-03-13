<%@ Page Title="" Language="C#" MasterPageFile="~/Auth.Master" AutoEventWireup="true" CodeBehind="Compose.aspx.cs" Inherits="EmailWebApp.Compose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="authhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AuthContentPlaceHolder1" runat="server">
    <form class="form-horizontal" runat="server">
        <fieldset>
            <legend align="center">Compose Email</legend>

            <div class="form-group">
                <label class="col-md-4 control-label" for="emailTo" required="required">To</label>
                <div class="col-md-4">
                    <input id="emailTo" name="emailTo" type="text" placeholder="Enter recipient email address" required="required" class="form-control input-md" runat="server" />

                </div>
            </div>

            <div class="form-group">
                <label class="col-md-4 control-label" for="CCtext">CC</label>
                <div class="col-md-4">
                    <input id="CCtext" name="CCtext" type="text" placeholder="Enter cc email address" class="form-control input-md" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label class="col-md-4 control-label" for="subjectText">Subject</label>
                <div class="col-md-4">
                    <input id="subjectText" name="subjectText" type="text" placeholder="Enter subject" required="required" class="form-control input-md" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <label class="col-md-4 control-label" for="emailText">Email text</label>
                <div class="col-md-4">
                    <textarea style="resize: none; height: 300px;" class="form-control" id="emailText" name="emailText" required="required" runat="server"></textarea>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-4 control-label" for="sendEmail"></label>
                <div class="col-md-4">
                    <asp:Button ID="sendEmail" runat="server" name="sendEmail" Text="Send" class="btn btn-primary" OnClick="sendEmail_Click" />
                </div>
            </div>
        </fieldset>
    </form>
</asp:Content>
