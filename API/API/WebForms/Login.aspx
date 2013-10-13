<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Food_Bank_Web.Login" MasterPageFile="~/Site.Master" %>

<asp:Content ID="signinHeader" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/WebForms/Styles/signin.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="signinContent" ContentPlaceHolderID="pageContent" runat="Server">
    <div class="form-signin">
    <h2 class="form-signin-heading">
        Please sign in</h2>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="input-block-level" TextMode="SingleLine"
        placeholder="Email address">
    </asp:TextBox>
    <asp:TextBox ID="txtPassword" runat="server" CssClass="input-block-level" TextMode="Password"
        placeholder="Password">
    </asp:TextBox>
    <asp:CheckBox ID="ckRememberMe" runat="server" Text="Remember me" CssClass="rememberme" />
    <asp:Button ID="btnLogin" CssClass="btn btn-large btn-primary" runat="server" Text="Sign in" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
