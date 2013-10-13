<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true"
    CodeFile="Settings.aspx.cs" Inherits="Settings" %>

<asp:Content ID="settingPage" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/Styles/settings.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="settingContent" ContentPlaceHolderID="pageContent" runat="Server">
    <div class="text-center">
        <asp:Label ID="lblEmail" Text="Email:" runat="server"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="SingleLine"></asp:TextBox>
        <div>
            <asp:Label ID="lblNotify" CssClass="help-block" runat="server">
Notify me when a donation is available within:
            </asp:Label>
            <asp:TextBox ID="txtRadius" runat="server" CssClass="input-mini text-center" Text="0" />
            miles
        </div>
    <div class="btn-group">
        <asp:Button ID="btnSave" runat="server" class="btn" Text="Save" />
        <asp:Button ID="btnCance" runat="server" class="btn" Text="Cancel" />
    </div>
    </div>
</asp:Content>
