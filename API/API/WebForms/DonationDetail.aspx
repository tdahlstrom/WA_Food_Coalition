<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DonationDetail.aspx.cs" Inherits="Food_Bank_Web.DonationDetail" MasterPageFile="Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/WebForms/Styles/donationDetails.css") %>" rel="stylesheet" /> 
    
    <script type="text/javascript">
        function getParameterByName(name) {
            var name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)");
            var results = regex.exec(location.search);
            return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }
        function getDonationDetail() {
            var id = getParameterByName("donationId");
            hideAllActions();
            if (id != null) {
                $.getJSON("/api/donation?ID=" + id,
                    function(data) {
                        $('#FoodDescription').text(data.Description);
                        $('#Address').text(data.Address);
                        $('#Name').text(data.Name);
                        $('#Phone').text(data.Phone);
                        $('#Email').text(data.Email);
                        $('#donationStatus').text(data.Status);
                        toggleAction(data.Status);
                    });
            }
        }

        function updateDonationStatus(status) {
            var id = getParameterByName("donationId");
            var foodbankId = 1;
            var APIurl = "/api/Donation/Status/" + id + "?status=" + status + "&foodbankid=" + foodbankId;
            
            $.ajax({
                type: "PUT",
                url: APIurl,
                async: false,
                success: function () {                }
            });
            return false;
        }

        function hideAllActions() {
            $('#OpenActions').hide();
            $('#InProcessActions').hide();
            $('#CloseActions').hide();
        }

        function toggleAction(status) {
            switch (status.toLowerCase()) {
                case "open":
                case "new":
                    $('#OpenActions').show();
                    break;
                case "inprocess":
                    $('#InProcessActions').show();
                    break;
                case "close":
                    $("#CloseActions").show();
                    break;
                default:
                    break;
            }

        }
        $(document).ready(getDonationDetail);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="Server">
    <div id="Test"></div>
    <div class="text-center">
        <div class="food">
             <span id="FoodDescription"></span>
        </div>
        <div class="status"><span id="donationStatus"></span></div>
        <div class="location">
            <span id="Address"></span>
        </div>
        <div class="contact">
            Contact Name: <span id="Name"></span>
            <br />
             Phone: <span id="Phone"></span>
            <br />
             Email: <span id="Email"></span>
        </div>
        <div class="button-area">
            <div id="OpenActions">
                <input type="button" id="btnPickup" value="Pick Up" class="btn" onclick="updateDonationStatus('inprocess')"/>
            </div>
            <div id="InProcessActions">
                <input type="button" id="btnDone" value="Picked Up" class="btn" onclick="updateDonationStatus('close')"/>
                <input type="button" id="btnCancel" value="Cancel Pick Up" class="btn" onclick="updateDonationStatus('open')"/>
            </div>
            <div id="CloseActions">
                <input type="button" id="btnUndo" value="Undo Picked Up" class="btn" onclick="updateDonationStatus('open')"/>
            </div>

        </div>
    </div>
</asp:Content>
