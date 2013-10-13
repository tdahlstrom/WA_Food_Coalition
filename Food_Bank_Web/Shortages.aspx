<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shortages.aspx.cs" Inherits="Food_Bank_Web.Shortages" MasterPageFile="~/Site.Master" %>
<asp:Content ID="shortageHeader" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/Styles/shortages.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="shortageContent" ContentPlaceHolderID="pageContent" runat="Server">
    <asp:GridView ID="gvShortages" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="FoodBank" HeaderText ="Food Bank" ItemStyle-CssClass="bank" />
            <asp:BoundField DataField="FoodType" HeaderText = "Food Needed" ItemStyle-CssClass="type" />
        </Columns>
    </asp:GridView>
</asp:Content>
