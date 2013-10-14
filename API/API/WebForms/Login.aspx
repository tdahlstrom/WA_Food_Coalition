<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Food_Bank_Web.Login" MasterPageFile="Site.Master" %>

<asp:Content ID="signinHeader" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/WebForms/Styles/signin.css") %>" rel="stylesheet" />
    <script type="text/javascript">
        function SaveFoodBankID() {
            var foodbankID = $("#txtFoodBankID").val();

            if (foodbankID.length == 0 || isNaN(foodbankID)) {
                $("#errorMessage").text("Please enter a numeric value for food bank ID.");
                $.removeCookie("FOODBANKID");
            } else {
                var APIurl = "/api/Foodbank?id=" + foodbankID;
                $.ajax({
                    type: "GET",
                    url: APIurl,
                    success: function() {
                        $("#errorMessage").text("");
                        $.cookie("FOODBANKID", foodbankID);
                        window.location = "donations.aspx";
                    },
                    error: function() {
                        $("#errorMessage").text("Error retrieving food bank information. Please verify you have entered the correct food bank ID.");
                    }
                });
            }

            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="signinContent" ContentPlaceHolderID="pageContent" runat="Server">
    <div class="form-signin">
    <h2 class="form-signin-heading">
        Please enter your food bank ID</h2>
        <div id="errorMessage" class="text-error"></div>
        <input type="text" id="txtFoodBankID"/>
        <input type="button" id="btnSave" class="btn btn-large btn-primary" value="Proceed" onclick ="SaveFoodBankID()"/>
    </div>
</asp:Content>
