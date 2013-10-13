<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true"
    CodeFile="Signin.aspx.cs" Inherits="Signin" %>

<asp:Content ID="signinHeader" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/Styles/signin.css") %>" rel="stylesheet" />
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
    <asp:Button ID="btnSignin" CssClass="btn btn-large btn-primary" runat="server" Text="Sign in" />
    </div>
</asp:Content>
