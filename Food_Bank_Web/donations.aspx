<%@ Page Title="" Language="C#" MasterPageFile="~/foodbank_master.master" AutoEventWireup="true"
    CodeFile="donations.aspx.cs" Inherits="donations" %>

<asp:Content ID="donationHeader" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/Styles/donations.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="donationContent" ContentPlaceHolderID="pageContent" runat="Server">
    <div class="btn-group">
        <asp:Button ID="btnPending" runat="server" CssClass="btn btn-third btn-primary disabled"
            Text="Not Picked Up" />
        <asp:Button ID="btnInProcess" runat="server" CssClass="btn btn-third" Text="I'm Picking Up" />
        <asp:Button ID="btnPickedUp" runat="server" CssClass="btn btn-third" Text="Picked Up" />
    </div>
</asp:Content>
