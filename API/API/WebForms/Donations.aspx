<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Donations.aspx.cs" Inherits="Food_Bank_Web.Donations" MasterPageFile="Site.Master" %>

<asp:Content ID="donationHeader" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/WebForms/Styles/donations.css") %>" rel="stylesheet" />

    <script type="text/javascript">
        function getDonations() {
            $.getJSON("/api/donation",
            function (data) {
                $('#donations').empty(); // Clear the table body.
                // Loop through the list of products.
                $.each(data, function (key, val) {
                    // Add a table row for the product.
                    var row = '<td class="food"><div class="description" onclick="viewDonation(' + val.ID+ ')">' + val.Description + '</div>' + val.Address + '</td>';
                    row = row + '<td class="distance"><div onclick="viewDonation(' + val.ID + ')">';
                    row = row + '<img src="';
                    if (val.Status.toLowerCase() == "new") {
                        row = row + '<%= Page.ResolveClientUrl("~/WebForms/img/truck.png") %>';
                    } else {
                        row = row + '<%= Page.ResolveClientUrl("~/WebForms/img/space.png") %>';
                    }
                    row = row + '"></div></td>';
                    
                    $('<tr/>', { html: row})  // Append the donations.
                        .appendTo($('#donations'));
                    
                });
            });
        }

        function viewDonation(id) {
            window.open("DonationDetail.aspx?donationId=" + id);
        }

        $(document).ready(getDonations);
</script>
</asp:Content>
<asp:Content ID="donationContent" ContentPlaceHolderID="pageContent" runat="Server">
    <div class="btn-group">
        <asp:Button ID="btnPending" runat="server" CssClass="btn btn-third btn-primary disabled"
            Text="Not Picked Up" />
        <asp:Button ID="btnInProcess" runat="server" CssClass="btn btn-third" Text="I'm Picking Up" />
        <asp:Button ID="btnPickedUp" runat="server" CssClass="btn btn-third" Text="Picked Up" />
    </div>
    <asp:ListView ID="lstDonations" runat="server">
        <ItemTemplate>
            <asp:Label ID="lblFood" runat="server"></asp:Label>
            <asp:Label ID="lblAddress" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:ListView>

    <table id="donations" class="donationList"></table>
    

</asp:Content>

