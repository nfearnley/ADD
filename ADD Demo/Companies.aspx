<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="ADD_Demo.Companies" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblCompany" runat="server" Text="Company Information"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlCompanies" runat="server" AutoPostBack="True" 
            DataSourceID="SDSCompanies" DataTextField="BillingName" 
            DataValueField="CompanyID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SDSCompanies" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
            SelectCommand="SELECT [CompanyID], [BillingName] FROM [Companys]">
        </asp:SqlDataSource>
    
    </div>
    <asp:DetailsView ID="dvCompanyInfo" runat="server" AutoGenerateRows="False" 
        DataKeyNames="CompanyID" DataSourceID="SDSCompanyInformation" Height="50px" 
        Width="250px">
        <Fields>
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
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SDSCompanyInformation" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
        SelectCommand="SELECT * FROM [Companys] WHERE ([CompanyID] = @CompanyID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCompanies" Name="CompanyID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
