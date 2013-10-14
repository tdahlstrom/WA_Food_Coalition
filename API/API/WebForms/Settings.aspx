<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" MasterPageFile="Site.Master" %>

<asp:Content ID="settingPage" ContentPlaceHolderID="pageHead" runat="Server">
    <link href="<%= Page.ResolveClientUrl("~/WebForms/Styles/settings.css") %>" rel="stylesheet" />
    <script type="text/javascript">
        function loadSettings() {
            var APIurl = "/api/Foodbank?id=" + glb_FoodbankID
            $.getJSON(APIurl,
                    function (data) {
                        glb_Foodbank = data;
                        $('#txtEmail').val(data.Email);
                        $('#txtRadius').val(data.rangeInMeters);
                    });
        }

        function updateSettings() {
            var foodbank = glb_Foodbank;
            var validForm = true;
            foodbank.Email = $("#txtEmail").val();
            foodbank.rangeInMeters = $("#txtRadius").val();
            $("#errorMessage").text("");
            $("#updateStatus").text("");
            if (foodbank.Email.length == 0) {
                validForm = false;
                $("#errorMessage").text("Please enter a valid email.");
            }

            if (foodbank.rangeInMeters.length == 0 || isNaN(foodbank.rangeInMeters)) {
                validForm = false;
                $("#errorMessage").text("Please enter a numeric value for the radius.");
            }
            if (validForm) {

                var APIurl = "/api/Foodbank?id=" + glb_FoodbankID;
                $.ajax({
                    type: "PUT",
                    url: APIurl,
                    data: foodbank,
                    success: function () {
                        $("#updateStatus").text("Settings has been updated successfuly.");
                    }
                });
            }

        }

        $(document).ready(loadSettings);
    </script>
</asp:Content>
<asp:Content ID="settingContent" ContentPlaceHolderID="pageContent" runat="Server">
    <div class="text-center">
        <span id="errorMessage" class="text-error"></span>
        <span id="updateStatus" class="text-success"></span>
        <div>
            Email:
            <input type="text" id="txtEmail" />
            <br />
            <span class="help-block">Notify me when a donation is available within:</span>
            <input type="text" id="txtRadius" class="input-mini text-center" />
            miles
        </div>
        <div class="btn-group">
            <input type="button" class="btn" value="Save" id="btnSave" onclick="updateSettings()"/>
            <input type="button" class="btn" value="Cancel" id="btnCancel" onclick="loadSettings()" />
        </div>
    </div>
</asp:Content>
