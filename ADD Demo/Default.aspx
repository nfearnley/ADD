<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ADD_Demo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p style="font-size:larger;font-weight:bold">
        Computer Training Registration Web Application</p>
    <p>
        To register a new company click
        <asp:HyperLink ID="HLCompany" runat="server" NavigateUrl="~/Companies.aspx">here</asp:HyperLink>
        .</p>
    <p>
        To register a new client click
        <asp:HyperLink ID="HLClient" runat="server" NavigateUrl="~/Clients.aspx">here</asp:HyperLink>
        .</p>
    <p>
        Use the above navigation to modify other aspects..</p>
</asp:Content>
