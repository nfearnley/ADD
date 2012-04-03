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
            <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SDSCompanyInformation" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
        SelectCommand="SELECT * FROM [Companys] WHERE ([CompanyID] = @CompanyID)" 
        DeleteCommand="DELETE FROM Companys WHERE (CompanyID = @CompanyID)" 
        InsertCommand="INSERT INTO Companys(BillingAddressCity, BillingAddressCountry, BillingAddressLine1, BillingAddressLine2, BillingAddressPostalCode, BillingAddressRegion, BillingName) VALUES (@BillingAddressCity, @BillingAddressCountry, @BillingAddressLine1, @BillingAddressLine2, @BillingAddressPostalCode, @BillingAddressRegion, @BillingName)" 
        UpdateCommand="UPDATE Companys SET BillingName = @BillingName, BillingAddressRegion = @BillingAddressRegion, BillingAddressPostalCode = @BillingAddressPostalCode, BillingAddressLine2 = @BillingAddressLine2, BillingAddressLine1 = @BillingAddressLine1, BillingAddressCountry = @BillingAddressCountry, BillingAddressCity = @BillingAddressCity WHERE CompanyID = @CompanyID">
        <DeleteParameters>
            <asp:Parameter Name="CompanyID" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="BillingAddressCity" />
            <asp:Parameter Name="BillingAddressCountry" />
            <asp:Parameter Name="BillingAddressLine1" />
            <asp:Parameter Name="BillingAddressLine2" />
            <asp:Parameter Name="BillingAddressPostalCode" />
            <asp:Parameter Name="BillingAddressRegion" />
            <asp:Parameter Name="BillingName" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCompanies" Name="CompanyID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="BillingName" />
            <asp:Parameter Name="BillingAddressRegion" />
            <asp:Parameter Name="BillingAddressPostalCode" />
            <asp:Parameter Name="BillingAddressLine2" />
            <asp:Parameter Name="BillingAddressLine1" />
            <asp:Parameter Name="BillingAddressCountry" />
            <asp:Parameter Name="BillingAddressCity" />
            <asp:Parameter Name="CompanyID" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSCompanyClientList" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
        SelectCommand="SELECT * FROM [Companys] INNER JOIN [Clients] ON Companys.CompanyID=Clients.CompanyID WHERE Companys.CompanyID=@CompanyID">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCompanies" Name="CompanyID" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="CompanyID,ClientID" DataSourceID="SDSCompanyClientList" 
        Width="250px">
        <Columns>
            <asp:BoundField DataField="BillingName" HeaderText="Company" 
                SortExpression="BillingName" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" 
                SortExpression="LastName" />
        </Columns>
    </asp:GridView>
    <br />
    </form>
</body>
</html>
