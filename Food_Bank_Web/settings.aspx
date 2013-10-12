<%@ Page Title="" Language="C#" MasterPageFile="~/foodbank_master.master" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="settings" %>

<asp:Content ID="settingPage" ContentPlaceHolderID="pageHead" Runat="Server">
<link href="<%= Page.ResolveClientUrl("~/Styles/settings.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="settingContent" ContentPlaceHolderID="pageContent" Runat="Server">
<div class="text-center">
   <label>Email:
          <input type="text" value="placeholder">
        </label>
        <span class="help-block">Notify me when a donation is available within:</span>
        <label class="checkbox">
          <input class="input-mini text-center" value="0"> miles
        </label>
        <div class="btn-group">
          <button type="submit" class="btn">Save</button>
          <button class="btn">Cancel</button>
        </div>
        </div>
</asp:Content>

