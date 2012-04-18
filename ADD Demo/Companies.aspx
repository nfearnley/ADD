<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="ADD_Demo.Companies" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Select a Company<br />
        <asp:DropDownList ID="ddlCompanies" runat="server" AutoPostBack="True" 
            DataSourceID="GetCompanies" DataTextField="BillingName" 
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
            <asp:BoundField DataField="BillingName" HeaderText="Name" 
                SortExpression="BillingName" />
            <asp:BoundField DataField="BillingAddressCity" HeaderText="City" 
                SortExpression="BillingAddressCity" />
            <asp:BoundField DataField="BillingAddressCountry" HeaderText="Country" 
                SortExpression="BillingAddressCountry" />
            <asp:BoundField DataField="BillingAddressLine1" HeaderText="Address Line 1" 
                SortExpression="BillingAddressLine1" />
            <asp:BoundField DataField="BillingAddressLine2" HeaderText="Address Line 2" 
                SortExpression="BillingAddressLine2" />
            <asp:BoundField DataField="BillingAddressPostalCode" HeaderText="Postal Code" 
                SortExpression="BillingAddressPostalCode" />
            <asp:BoundField DataField="BillingAddressRegion" HeaderText="Region" 
                SortExpression="BillingAddressRegion" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <br />
    Clients Registered with This Company:<asp:GridView ID="GridView1" 
        runat="server" AutoGenerateColumns="False" DataSourceID="GetClientsByCompany" 
        Width="750px">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" 
                SortExpression="LastName" />
            <asp:BoundField DataField="HomePhone" HeaderText="Home Phone" 
                SortExpression="HomePhone" />
            <asp:BoundField DataField="WorkPhone" HeaderText="Work Phone" 
                SortExpression="WorkPhone" />
            <asp:BoundField DataField="FaxPhone" HeaderText="Fax" 
                SortExpression="FaxPhone" />
            <asp:BoundField DataField="AddressCity" HeaderText="City" 
                SortExpression="AddressCity" />
            <asp:BoundField DataField="AddressCountry" HeaderText="Country" 
                SortExpression="AddressCountry" />
            <asp:BoundField DataField="AddressRegion" HeaderText="Region" 
                SortExpression="AddressRegion" />
            <asp:BoundField DataField="AddressLine1" HeaderText="Address Line 1" 
                SortExpression="AddressLine1" />
            <asp:BoundField DataField="AddressLine2" HeaderText="Address Line 2" 
                SortExpression="AddressLine2" />
            <asp:BoundField DataField="AddressPostalCode" HeaderText="Postal Code" 
                SortExpression="AddressPostalCode" />
        </Columns>
    </asp:GridView>
    <br />
    </form>
</body>
</html>
