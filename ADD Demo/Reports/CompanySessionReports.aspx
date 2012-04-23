<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanySessionReports.aspx.cs" Inherits="ADD_Demo.Reports.CompanySessionReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ODSGetClientSessions" runat="server" 
        SelectMethod="GetUnpaidClientSessionsByCompanyID" 
        TypeName="ADD_Demo.Classes.ClientSession">
        <SelectParameters>
            <asp:QueryStringParameter Name="companyID" QueryStringField="CompanyID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    Client Sessions Not Paid For:<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ODSGetClientSessions">
        <Columns>
            <asp:BoundField DataField="ClientSessionID" HeaderText="ClientSessionID" 
                SortExpression="ClientSessionID" Visible="False" />
            <asp:BoundField DataField="ClientFullName" HeaderText="Client Name" 
                ReadOnly="True" SortExpression="ClientFullName" />
            <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" 
                SortExpression="CourseCode" />
            <asp:BoundField DataField="SessionDateTime" HeaderText="Session Date" 
                ReadOnly="True" SortExpression="SessionDateTime" />
            <asp:BoundField DataField="ClientSessionPrice" HeaderText="Session Price" 
                SortExpression="ClientSessionPrice" />
            <asp:BoundField DataField="StatusName" HeaderText="Status" ReadOnly="True" 
                SortExpression="StatusName" />
            <asp:BoundField DataField="ClientID" HeaderText="ClientID" 
                SortExpression="ClientID" Visible="False" />
            <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" ReadOnly="True" 
                SortExpression="CompanyID" Visible="False" />
            <asp:BoundField DataField="SessionID" HeaderText="SessionID" 
                SortExpression="SessionID" Visible="False" />
            <asp:BoundField DataField="StatusID" HeaderText="StatusID" 
                SortExpression="StatusID" Visible="False" />
        </Columns>
    </asp:GridView>
</asp:Content>
