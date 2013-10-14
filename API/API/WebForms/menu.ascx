<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="Food_Bank_Web.menu" %>
<script type="text/javascript">
    function removeCookie() {
        $.removeCookie("FOODBANKID");
    }
</script>
<div class="navbar">
    <div class="navbar-inner">
        <div class="container">
            <ul class="nav" runat="server" id="ulMenu">
                <li runat="server" id="liDonations" class="active">
                    <asp:LinkButton ID="lnkDonations" runat="server" Text="Donations" OnClick="MenuClick"></asp:LinkButton>
                </li>
                <li runat="server" id="liSettings" >
                    <asp:LinkButton ID="lnkSettings" runat="server" Text="Settings" OnClick="MenuClick"></asp:LinkButton></li>
                <li runat="server" id="liMap">
                    <asp:LinkButton ID="lnkMap" runat="server" Text="Map" OnClick="MenuClick"></asp:LinkButton></li>
                <li runat="server" id="liLogout" >
                    <asp:LinkButton ID="lnkLogOut" runat="server" Text="LogOut" OnClick="MenuClick" OnClientClick="removeCookie()"></asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
</div>
