<%@ Page Title="Companies" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Companies.aspx.cs" Inherits="ADD_Demo.Companies" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div>
    
        Select a Company<br />
        <asp:DropDownList ID="ddlCompanies" runat="server" AutoPostBack="True" 
            DataSourceID="GetCompanies" DataTextField="CompanyBillingName" 
            DataValueField="CompanyID">
        </asp:DropDownList>
    
        <asp:ObjectDataSource ID="GetCompanies" runat="server" 
            SelectMethod="GetCompanies" TypeName="ADD_Demo.Classes.Company">
        </asp:ObjectDataSource>
    
        Generate Invoice:<br />
        <asp:Button ID="btnInvoice" runat="server" onclick="btnInvoice_Click" 
            Text="Generate Invoice" />
        <br />
    
        <br />
        Company Information</div>
    <asp:DetailsView ID="dvCompanyInfo" runat="server" AutoGenerateRows="False" 
        DataSourceID="GetCompany" Height="50px" 
        Width="250px">
        <Fields>
            <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" 
                SortExpression="CompanyID" Visible="False" />
            <asp:BoundField DataField="CompanyBillingName" HeaderText="Name" 
                SortExpression="CompanyBillingName" />
            <asp:BoundField DataField="CompanyBillingAddressCity" HeaderText="City" 
                SortExpression="CompanyBillingAddressCity" />
            <asp:BoundField DataField="CompanyBillingAddressCountry" HeaderText="Country" 
                SortExpression="CompanyBillingAddressCountry" />
            <asp:BoundField DataField="CompanyBillingAddressLine1" HeaderText="Address Line 1" 
                SortExpression="CompanyBillingAddressLine1" />
            <asp:BoundField DataField="CompanyBillingAddressLine2" HeaderText="Address Line 2" 
                SortExpression="CompanyBillingAddressLine2" />
            <asp:BoundField DataField="CompanyBillingAddressPostalCode" HeaderText="Postal Code" 
                SortExpression="CompanyBillingAddressPostalCode" />
            <asp:BoundField DataField="CompanyBillingAddressRegion" HeaderText="Region" 
                SortExpression="CompanyBillingAddressRegion" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowInsertButton="True" />
            <asp:HyperLinkField DataNavigateUrlFields="CompanyID" 
                DataNavigateUrlFormatString="Reports/CompanySessionReports.aspx?CompanyID={0}" 
                InsertVisible="False" Text="Build Session Report" />
        </Fields>
    </asp:DetailsView>
        <asp:ObjectDataSource ID="GetCompany" runat="server" 
            DataObjectTypeName="ADD_Demo.Classes.Company" DeleteMethod="RemoveCompany" 
            InsertMethod="AddCompany" SelectMethod="GetCompany" 
            TypeName="ADD_Demo.Classes.Company" UpdateMethod="UpdateCompany">
            <DeleteParameters>
                <asp:Parameter Name="companyID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCompanies" Name="companyID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <br />
    Clients Registered with This Company:<asp:GridView ID="ClientsGridView" 
        runat="server" AutoGenerateColumns="False" DataSourceID="GetClientsByCompany" 
        Width="750px">
        <Columns>
            <asp:BoundField DataField="ClientFirstName" HeaderText="First Name" 
                SortExpression="ClientFirstName" />
            <asp:BoundField DataField="ClientLastName" HeaderText="Last Name" 
                SortExpression="ClientLastName" />
            <asp:BoundField DataField="ClientHomePhone" HeaderText="Home Phone" 
                SortExpression="ClientHomePhone" />
            <asp:BoundField DataField="ClientWorkPhone" HeaderText="Work Phone" 
                SortExpression="ClientWorkPhone" />
            <asp:BoundField DataField="ClientFaxPhone" HeaderText="Fax" 
                SortExpression="ClientFaxPhone" />
            <asp:BoundField DataField="ClientAddressCity" HeaderText="City" 
                SortExpression="ClientAddressCity" />
            <asp:BoundField DataField="ClientAddressCountry" HeaderText="Country" 
                SortExpression="ClientAddressCountry" />
            <asp:BoundField DataField="ClientAddressRegion" HeaderText="Region" 
                SortExpression="ClientAddressRegion" />
            <asp:BoundField DataField="ClientAddressLine1" HeaderText="Address Line 1" 
                SortExpression="ClientAddressLine1" />
            <asp:BoundField DataField="ClientAddressLine2" HeaderText="Address Line 2" 
                SortExpression="ClientAddressLine2" />
            <asp:BoundField DataField="ClientAddressPostalCode" HeaderText="Postal Code" 
                SortExpression="ClientAddressPostalCode" />
            <asp:HyperLinkField DataNavigateUrlFields="ClientID" 
                DataNavigateUrlFormatString="Clients.aspx?ClientID={0}" Text="link" />
        </Columns>
    </asp:GridView>
        <asp:ObjectDataSource ID="GetClientsByCompany" runat="server" 
            SelectMethod="GetClientsByCompanyID" TypeName="ADD_Demo.Classes.Client">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCompanies" Name="companyID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
        <br />
    Invoices:<asp:GridView ID="InvoicesGridView" runat="server" 
        AutoGenerateColumns="False" DataSourceID="GetInvoicesByCompany" 
        DataKeyNames="InvoiceID">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" 
                SortExpression="InvoiceID" Visible="False" />
            <asp:BoundField DataField="InvoiceDate" HeaderText="InvoiceDate" 
                SortExpression="InvoiceDate" />
            <asp:HyperLinkField DataNavigateUrlFields="InvoiceID" 
                DataNavigateUrlFormatString="Invoices.aspx?InvoiceID={0}" Text="Report" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="GetInvoicesByCompany" runat="server" 
        SelectMethod="GetInvoicesByCompanyID" TypeName="ADD_Demo.Classes.Invoice">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCompanies" Name="companyID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="InvoiceItemsGridView" runat="server" 
        AutoGenerateColumns="False" DataSourceID="GetInvoiceItemsByInvoice">
        <Columns>
            <asp:BoundField DataField="ClientSessionID" HeaderText="ClientSessionID" 
                SortExpression="ClientSessionID" Visible="False" />
            <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" 
                SortExpression="InvoiceID" Visible="False" />
            <asp:CheckBoxField DataField="ClientSessionPaid" HeaderText="ClientSessionPaid" 
                ReadOnly="True" SortExpression="ClientSessionPaid" />
            <asp:BoundField DataField="ClientSessionPrice" HeaderText="ClientSessionPrice" 
                ReadOnly="True" SortExpression="ClientSessionPrice" />
            <asp:BoundField DataField="ClientFullName" HeaderText="ClientFullName" 
                ReadOnly="True" SortExpression="ClientFullName" />
            <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" ReadOnly="True" 
                SortExpression="CourseCode" />
            <asp:BoundField DataField="CourseDescription" HeaderText="CourseDescription" 
                ReadOnly="True" SortExpression="CourseDescription" />
            <asp:BoundField DataField="StatusName" HeaderText="StatusName" ReadOnly="True" 
                SortExpression="StatusName" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="GetInvoiceItemsByInvoice" runat="server" 
        SelectMethod="GetInvoiceItemsByInvoiceID" 
        TypeName="ADD_Demo.Classes.InvoiceItem">
        <SelectParameters>
            <asp:ControlParameter ControlID="InvoicesGridView" Name="invoiceID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
</asp:Content>
