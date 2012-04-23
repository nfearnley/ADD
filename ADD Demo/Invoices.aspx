<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="ADD_Demo.Invoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:ObjectDataSource ID="ODSInvoiceInfo" runat="server" 
        SelectMethod="GetInvoice" TypeName="ADD_Demo.Classes.Invoice">
        <SelectParameters>
            <asp:QueryStringParameter Name="invoiceID" QueryStringField="InvoiceID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataSourceID="ODSInvoiceInfo" Height="50px" Width="500px">
        <Fields>
            <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" 
                SortExpression="InvoiceID" Visible="False" />
            <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" 
                SortExpression="InvoiceDate" />
            <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" 
                SortExpression="CompanyID" Visible="False" />
            <asp:BoundField DataField="CompanyBillingName" HeaderText="Company Name" 
                ReadOnly="True" SortExpression="CompanyBillingName" />
            <asp:BoundField DataField="CompanyBillingAddressCity" HeaderText="Company City" 
                ReadOnly="True" SortExpression="CompanyBillingAddressCity" />
            <asp:BoundField DataField="CompanyBillingAddressCountry" 
                HeaderText="Company Country" ReadOnly="True" 
                SortExpression="CompanyBillingAddressCountry" />
            <asp:BoundField DataField="CompanyBillingAddressLine1" 
                HeaderText="Company Billing Address Line 1" ReadOnly="True" 
                SortExpression="CompanyBillingAddressLine1" />
            <asp:BoundField DataField="CompanyBillingAddressLine2" 
                HeaderText="Company Billing Address Line 2" ReadOnly="True" 
                SortExpression="CompanyBillingAddressLine2" />
            <asp:BoundField DataField="CompanyBillingAddressPostalCode" 
                HeaderText="Company Billing Address Postal Code" ReadOnly="True" 
                SortExpression="CompanyBillingAddressPostalCode" />
            <asp:BoundField DataField="CompanyBillingAddressRegion" 
                HeaderText="Company Billing Address Region" ReadOnly="True" 
                SortExpression="CompanyBillingAddressRegion" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ODSInvoiceItem" runat="server" 
        SelectMethod="GetInvoiceItemsByInvoiceID" 
        TypeName="ADD_Demo.Classes.InvoiceItem">
        <SelectParameters>
            <asp:QueryStringParameter Name="invoiceID" QueryStringField="InvoiceID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ODSInvoiceItem" Width="500px">
        <Columns>
            <asp:BoundField DataField="ClientSessionID" HeaderText="ClientSessionID" 
                SortExpression="ClientSessionID" Visible="False" />
            <asp:CheckBoxField DataField="ClientSessionPaid" HeaderText="ClientSessionPaid" 
                ReadOnly="True" SortExpression="ClientSessionPaid" Visible="False" />
            <asp:BoundField DataField="ClientSessionPrice" HeaderText="Price" 
                ReadOnly="True" SortExpression="ClientSessionPrice" />
            <asp:BoundField DataField="ClientID" HeaderText="ClientID" ReadOnly="True" 
                SortExpression="ClientID" Visible="False" />
            <asp:BoundField DataField="ClientFullName" HeaderText="ClientFullName" 
                ReadOnly="True" SortExpression="ClientFullName" />
            <asp:BoundField DataField="SessionID" HeaderText="SessionID" ReadOnly="True" 
                SortExpression="SessionID" Visible="False" />
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" ReadOnly="True" 
                SortExpression="CourseID" Visible="False" />
            <asp:BoundField DataField="CourseCode" HeaderText="Course Code" ReadOnly="True" 
                SortExpression="CourseCode" />
            <asp:BoundField DataField="StatusID" HeaderText="StatusID" ReadOnly="True" 
                SortExpression="StatusID" Visible="False" />
            <asp:BoundField DataField="StatusName" HeaderText="Status" ReadOnly="True" 
                SortExpression="StatusName" />
            <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" 
                SortExpression="InvoiceID" Visible="False" />
            <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" 
                ReadOnly="True" SortExpression="InvoiceDate" />
            <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" ReadOnly="True" 
                SortExpression="CompanyID" Visible="False" />
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>
