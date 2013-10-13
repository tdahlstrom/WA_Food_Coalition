<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true"
    CodeFile="DonationDetail.aspx.cs" Inherits="DonationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageHead" runat="Server">
<link href="<%= Page.ResolveClientUrl("~/Styles/donationDetails.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="Server">


      <div class="text-center">
        <h2>Amount/Type of Food</h2>

        <h3>Contact Information</h3>

        <div class="button-area">
          <div id="open">
            <asp:Button ID="btnPickup" runat="server" Text="Pick Up" CssClass="btn" />
          </div>
          <div id="being-picked-up">
            <h3>Being Picked Up</h3>
            <!-- only show this if they are the one picking it up -->
            <div class="btn-group">
             <asp:Button ID="btnDone" runat="server" Text="Picked Up" CssClass ="btn" />
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" />
            </div>
          </div>
          <div id="picked-up">
            <h3>Picked Up</h3>
            <!-- only show this if they are the one picking it up -->
            <asp:Button ID="btnUndo" runat="server" Text="Undo Picked Up" CssClass="btn" />
          </div>
        </div>
      </div>


</asp:Content>
