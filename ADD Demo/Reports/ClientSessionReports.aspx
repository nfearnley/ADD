<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientSessionReports.aspx.cs" Inherits="ADD_Demo.Reports.ClientSessionReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ODSGetClientInfo" runat="server" 
        SelectMethod="GetClient" TypeName="ADD_Demo.Classes.Client">
        <SelectParameters>
            <asp:QueryStringParameter Name="clientID" QueryStringField="ClientID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSGetClientSessions" runat="server" 
        SelectMethod="GetClientSessionsByClientID" 
        TypeName="ADD_Demo.Classes.ClientSession">
        <SelectParameters>
            <asp:QueryStringParameter Name="clientID" QueryStringField="ClientID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataSourceID="ODSGetClientInfo" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="ClientID" HeaderText="ClientID" 
                SortExpression="ClientID" Visible="False" />
            <asp:BoundField DataField="ClientFullName" HeaderText="Full Name" 
                ReadOnly="True" SortExpression="ClientFullName" />
            <asp:BoundField DataField="ClientAddressRegion" HeaderText="Region" 
                SortExpression="ClientAddressRegion" />
            <asp:BoundField DataField="ClientAddressPostalCode" HeaderText="Postal Code" 
                SortExpression="ClientAddressPostalCode" />
            <asp:BoundField DataField="ClientHomePhone" HeaderText="Home Phone" 
                SortExpression="ClientHomePhone" />
            <asp:BoundField DataField="ClientWorkPhone" HeaderText="Work Phone" 
                SortExpression="ClientWorkPhone" />
            <asp:BoundField DataField="ClientFaxPhone" HeaderText="Fax" 
                SortExpression="ClientFaxPhone" />
            <asp:BoundField DataField="ClientAddressLine1" HeaderText="Address Line 1" 
                SortExpression="ClientAddressLine1" />
            <asp:BoundField DataField="ClientAddressLine2" HeaderText="Address Line 2" 
                SortExpression="ClientAddressLine2" />
            <asp:BoundField DataField="ClientAddressCity" HeaderText="City" 
                SortExpression="ClientAddressCity" />
            <asp:BoundField DataField="ClientAddressCountry" HeaderText="Country" 
                SortExpression="ClientAddressCountry" />
            <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" 
                SortExpression="CompanyID" Visible="False" />
            <asp:BoundField DataField="CompanyBillingName" HeaderText="Current Company" 
                ReadOnly="True" SortExpression="CompanyBillingName" />
        </Fields>
    </asp:DetailsView>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ODSGetClientSessions">
        <Columns>
            <asp:BoundField DataField="CourseCode" HeaderText="Course Enrolled" 
                ReadOnly="True" SortExpression="CourseCode" />
            <asp:BoundField DataField="CompanyBillingName" 
                HeaderText="Registered Company Name" ReadOnly="True" 
                SortExpression="CompanyBillingName" />
            <asp:BoundField DataField="StatusName" HeaderText="Status" ReadOnly="True" 
                SortExpression="StatusName" />
            <asp:CheckBoxField DataField="ClientSessionPaid" HeaderText="Paid" 
                SortExpression="ClientSessionPaid" />
            <asp:BoundField DataField="ClientSessionPrice" 
                HeaderText="Price Paid for Session" SortExpression="ClientSessionPrice" />
            <asp:BoundField DataField="SessionDateTime" HeaderText="Session Date" 
                ReadOnly="True" SortExpression="SessionDateTime" />
            <asp:BoundField DataField="ClientSessionID" HeaderText="ClientSessionID" 
                SortExpression="ClientSessionID" Visible="False" />
            <asp:BoundField DataField="ClientID" HeaderText="ClientID" 
                SortExpression="ClientID" Visible="False" />
            <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" ReadOnly="True" 
                SortExpression="CompanyID" Visible="False" />
            <asp:BoundField DataField="SessionID" HeaderText="SessionID" 
                SortExpression="SessionID" Visible="False" />
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" ReadOnly="True" 
                SortExpression="CourseID" Visible="False" />
            <asp:BoundField DataField="StatusID" HeaderText="StatusID" 
                SortExpression="StatusID" Visible="False" />
        </Columns>
    </asp:GridView>
</asp:Content>
