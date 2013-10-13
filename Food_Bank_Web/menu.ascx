<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="menu" %>
<div class="navbar">
    <div class="navbar-inner">
        <div class="container">
            <ul class="nav" runat="server" id="ulMenu">
                <li runat="server" id="liDonations" class="active">
                    <asp:LinkButton ID="lnkDonations" runat="server" Text="Donations" OnClick="MenuClick"></asp:LinkButton>
                </li>
                <li runat="server" id="liSettings" >
                    <asp:LinkButton ID="lnkSettings" runat="server" Text="Settings" OnClick="MenuClick"></asp:LinkButton></li>
                <li runat="server" id="liShortages" >
                    <asp:LinkButton ID="lnkShortages" runat="server" Text="Shortages" OnClick="MenuClick"></asp:LinkButton></li>
                <li runat="server" id="liLogout" >
                    <asp:LinkButton ID="lnkLogOut" runat="server" Text="LogOut" OnClick="MenuClick"></asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
</div>
