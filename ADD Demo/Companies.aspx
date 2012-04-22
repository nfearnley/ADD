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
        <asp:ObjectDataSource ID="GetClientsByCompany" runat="server" 
            SelectMethod="GetClientsByCompanyID" TypeName="ADD_Demo.Classes.Client">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCompanies" Name="companyID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
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
        </Fields>
    </asp:DetailsView>
    <br />
    Clients Registered with This Company:<asp:GridView ID="GridView1" 
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
    <br />
</asp:Content>
