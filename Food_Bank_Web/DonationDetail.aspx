<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true"
    CodeFile="DonationDetail.aspx.cs" Inherits="DonationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/Styles/donationDetails.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="Server">
    <div class="text-center">
        <div class="food">
            <asp:Label ID="lblFoodType" runat="server"></asp:Label>
            <asp:Label ID="lblFoodAmount" runat="server"></asp:Label>
        </div>
        <div class="location">
            <asp:Label ID="lblAddress" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblDistance" runat="server"></asp:Label>
        </div>
        <div class="contact">
            <asp:Label ID="lblContactName" runat="server"></asp:Label>
            :
            <asp:Label ID="lblContact" runat="server"></asp:Label>
        </div>
        <div class="button-area">
            <asp:PlaceHolder runat="server" ID="phOpen" Visible="false">
                <asp:Button ID="btnPickup" runat="server" Text="Pick Up" CssClass="btn" OnClick="btnPickup_Click" />
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phInProcess" Visible="false">
                <!-- only show this if they are the one picking it up -->
                <div class="btn-group">
                    <asp:Button ID="btnDone" runat="server" Text="Picked Up" CssClass="btn" OnClick="btnDone_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click" />
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phClose" Visible="false">
                <!-- only show this if they are the one picking it up -->
                <asp:Button ID="btnUndo" runat="server" Text="Undo Picked Up" CssClass="btn" OnClick="btnUndo_Click" />
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
