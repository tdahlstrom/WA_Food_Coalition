<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="menu" %>
<div class="navbar">
    <div class="navbar-inner">
        <div class="container">
            <ul class="nav">
                <li class="active">
                    <asp:LinkButton ID="lnkDonations" runat="server" Text="Donations"></asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="lnkSettings" runat="server" Text="Settings"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnkShortages" runat="server" Text="Shortages"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnkLogOut" runat="server" Text="LogOut"></asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
</div>
