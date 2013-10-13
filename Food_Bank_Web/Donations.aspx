<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Donations.aspx.cs" Inherits="Food_Bank_Web.Donations" MasterPageFile="~/Site.Master" %>

<asp:Content ID="donationHeader" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/Styles/donations.css") %>" rel="stylesheet" />

    <script type="text/javascript">
        function getDonations() {
            $.getJSON("api/donation",
            function (data) {
                $('#gvDonations').empty(); // Clear the table body.

                // Loop through the list of products.
                $.each(data, function (key, val) {
                    // Add a table row for the product.
                    var row = '<td>' + val.Name + '</td><td>' + val.Price + '</td>';
                    $('<tr/>', { text: row })  // Append the name.
                        .appendTo($('#products'));
                });
            });
        }

        $(document).ready(getProducts);
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
    <asp:GridView ID="gvDonations" runat="server" CssClass="donationList" AutoGenerateColumns="false"
        ShowHeader="false" RowStyle-CssClass="donationRow" AlternatingRowStyle-CssClass="donationRowAlt"
        OnRowDataBound="gvDonation_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="description">
                        <asp:Label ID="lblFoodType" runat="server" Text="<%# Bind('FoodType') %>"></asp:Label>
                        -
                        <asp:Label ID="lblFoodAmount" runat="server" Text="<%# Bind('FoodAmount') %>"></asp:Label>
                        <br />
                        <asp:Label ID="lblAddress" runat="server" Text="<%# Bind('Address') %>" CssClass="address"></asp:Label>
                    </div>
                    <div class="status">
                        <asp:Image ID="imgStatus" runat="server" ImageUrl=<%# Bind('StatusImage') %> />
                    </div>
                    <div class="distance">
                        <asp:Label ID="lblDistance" runat="server" Text="<%# Bind('Distance') %>"></asp:Label>
                        miles
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

