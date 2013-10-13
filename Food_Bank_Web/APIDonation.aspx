<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APIDonation.aspx.cs" Inherits="Food_Bank_Web.APIDonation" %>

<asp:Content ID="pageHead" runat="server" ContentPlaceHolderID="HeadContent">
<script type="text/javascript">
    function getProducts() {
        $.getJSON("api/donation",
            function (data) {
                $('#products').empty(); // Clear the table body.

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

<asp:Content ID="pageContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Products</h2>
    <table>
    <thead>
        <tr><th>Name</th><th>Price</th></tr>
    </thead>
    <tbody id="products">
    </tbody>
    </table>
</asp:Content>