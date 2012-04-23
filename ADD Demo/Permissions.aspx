<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Permissions.aspx.cs" Inherits="ADD_Demo.Permissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="UserAccess" runat="server" Text="UserAccess: "></asp:Label>
    <br />
    <asp:Label ID="Add" runat="server" Text="Add: "></asp:Label>
    <br />
    <asp:Label ID="Edit" runat="server" Text="Edit: "></asp:Label>
    <br />
    <asp:Label ID="Delete" runat="server" Text="Delete: "></asp:Label>
    <br />
    <asp:Label ID="Display" runat="server" Text="Display: "></asp:Label>
    <br />
    <asp:Label ID="Report" runat="server" Text="Report: "></asp:Label>
</asp:Content>
