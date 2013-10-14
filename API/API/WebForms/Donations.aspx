<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Donations.aspx.cs" Inherits="Food_Bank_Web.Donations" MasterPageFile="Site.Master" %>

<asp:Content ID="donationHeader" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/WebForms/Styles/donations.css") %>" rel="stylesheet" />

    <script type="text/javascript">
        function getDonations(status) {
            var APIUrl = "/api/donation";
            $('#btnAll').removeClass("btn-primary").removeClass("disabled");
            $('#btnInProcess').removeClass("btn-primary").removeClass("disabled");
            $('#btnClose').removeClass("btn-primary").removeClass("disabled");
            switch(status.toString().toLowerCase()) {
                case "inprocess":
                    APIUrl = APIUrl + "?foodbankid=" + glb_FoodbankID + "&status=" + status;
                    $('#btnInProcess').addClass("btn-primary").addClass("disabled");
                    break;
                case "close":
                    APIUrl = APIUrl + "?foodbankid=" + glb_FoodbankID + "&status=" + status;
                    $('#btnClose').addClass("btn-primary").addClass("disabled");
                    break;
                default:
                    APIUrl = APIUrl + "?foodbankid=" + glb_FoodbankID;
                    $('#btnAll').addClass("btn-primary").addClass("disabled");
                    break;
            }
            $.getJSON(APIUrl,
            function (data) {
                $('#donations').empty(); // Clear the table body.
                // Loop through the list of products.
                $.each(data, function (key, val) {
                    // Add a table row for the product.
                    var rowStyle = "";
                    var statusImg = "";
                    switch(val.Status.toLowerCase()) {
                        case "inprocess":
                            rowStyle = "";
                            statusImg = '<%= Page.ResolveClientUrl("~/WebForms/img/truck.png") %>';
                            break;
                        case "close":
                            rowStyle = "closed";
                            statusImg = '<%= Page.ResolveClientUrl("~/WebForms/img/space.png") %>';
                            break;
                        default:
                            rowStyle = "";
                            statusImg = '<%= Page.ResolveClientUrl("~/WebForms/img/space.png") %>';
                            break;
                    }


                    var row = '<td class="food ' + rowStyle + '"><div class="description" onclick="viewDonation(' + val.ID+ ')">' + val.Description + '</div>' + val.Address + '</td>';
                    row = row + '<td class="distance ' + rowStyle + '"><div onclick="viewDonation(' + val.ID + ')">';
                    row = row + '<img src="' + statusImg + '"></div></td>';
                    
                    $('<tr/>', { html: row})  // Append the donations.
                        .appendTo($('#donations'));
                    
                });
            });
        }

        function viewDonation(id) {
            window.location = "DonationDetail.aspx?donationId=" + id;
        }

        $(document).ready(getDonations);
</script>
</asp:Content>
<asp:Content ID="donationContent" ContentPlaceHolderID="pageContent" runat="Server">
    <div class="btn-group">
        <input type="button" id="btnAll" Class="btn btn-third btn-primary disabled" value="All Donations" onclick="getDonations('All')"/>
        <input type="button" id="btnInProcess" Class="btn btn-third " value="I'm Picking Up" onclick="getDonations('InProcess')"/>
        <input type="button" id="btnClose" Class="btn btn-third " value="Picked Up" onclick="getDonations('Close')"/>
    </div>
    <table id="donations" class="donationList"></table>
    

</asp:Content>

