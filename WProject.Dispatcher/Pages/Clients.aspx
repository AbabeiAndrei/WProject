<%@ Page Title="" Language="C#" MasterPageFile="~/WProject.Dispatcher.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="WProject.Dispatcher.Pages.Clients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Connections</h2><br />
    <asp:TextBox ID="txtConnections" runat="server" Height="165px" ReadOnly="True" TextMode="MultiLine" Width="1148px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblConections" runat="server" Text="Number of active connections : 0"></asp:Label>
    <br />
    <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh" />
    <br />
    <br />
    <asp:Button ID="btnClean" runat="server" OnClick="btnClean_Click" Text="Clean" />
    <br />
</asp:Content>
