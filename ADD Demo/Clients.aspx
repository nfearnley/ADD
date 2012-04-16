<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="ADD_Demo.Clients1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SDSClient" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
            SelectCommand="SELECT [FirstName], [LastName], [LastName]+', '+[FirstName] AS 'FullName',[ClientID] FROM [Clients] ORDER BY [LastName]">
        </asp:SqlDataSource>
        <asp:ObjectDataSource ID="ODSGetClients" runat="server" 
            SelectMethod="GetClients" TypeName="ADD_Demo.Classes.Client">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSGetClient" runat="server" 
            DataObjectTypeName="ADD_Demo.Classes.Client" DeleteMethod="RemoveClient" 
            InsertMethod="AddClient" SelectMethod="GetClient" 
            TypeName="ADD_Demo.Classes.Client" UpdateMethod="UpdateClient">
            <DeleteParameters>
                <asp:Parameter Name="clientID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlClientSearch" Name="clientID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSGetCompany" runat="server" 
            SelectMethod="GetCompany" TypeName="ADD_Demo.Classes.Company">
            <SelectParameters>
                <asp:ControlParameter ControlID="dvClientDetails" Direction="Output" 
                    Name="companyID" PropertyName="Rows" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="lblClientSearch" runat="server" Text="Search for a Client"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlClientSearch" runat="server" AutoPostBack="True" 
            DataSourceID="ODSGetClients" DataTextField="LastName" 
            DataValueField="ClientID">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblClientInfo" runat="server" Text="Client Information"></asp:Label>
        <asp:DetailsView ID="dvClientDetails" runat="server" AutoGenerateRows="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataSourceID="ODSGetClient" 
            GridLines="Vertical" Height="50px" Width="250px">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="ClientID" HeaderText="ClientID" 
                    SortExpression="ClientID" Visible="False" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" 
                    SortExpression="LastName" />
                <asp:BoundField DataField="HomePhone" HeaderText="Home Phone" 
                    SortExpression="HomePhone" />
                <asp:BoundField DataField="WorkPhone" HeaderText="Work Phone" 
                    SortExpression="WorkPhone" />
                <asp:BoundField DataField="FaxPhone" HeaderText="Fax Phone" 
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
                <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" 
                    SortExpression="CompanyID" Visible="False" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowInsertButton="True" />
            </Fields>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SDSClientDetails" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
            InsertCommand="INSERT INTO Clients(AddressCity, AddressCountry, AddressLine1, AddressLine2, AddressPostalCode, AddressRegion, FaxPhone, FirstName, HomePhone, LastName, WorkPhone) VALUES (@AddressCity,@AddressCountry,@AddressLine1,@AddressLine2,@AddressPostalCode,@AddressRegion,@FaxPhone,@FirstName,@HomePhone,@LastName,@WorkPhone)" 
            SelectCommand="SELECT * FROM [Clients] WHERE ([ClientID] = @ClientID)" 
            UpdateCommand="UPDATE Clients SET AddressCity = @AddressCity, AddressCountry = @AddressCountry, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, AddressPostalCode = @AddressPostalCode, AddressRegion = @AddressRegion, FaxPhone = @FaxPhone, FirstName = @FirstName, HomePhone = @HomePhone, LastName = @LastName, WorkPhone = @WorkPhone">
            <InsertParameters>
                <asp:Parameter Name="AddressCity" />
                <asp:Parameter Name="AddressCountry" />
                <asp:Parameter Name="AddressLine1" />
                <asp:Parameter Name="AddressLine2" />
                <asp:Parameter Name="AddressPostalCode" />
                <asp:Parameter Name="AddressRegion" />
                <asp:Parameter Name="FaxPhone" />
                <asp:Parameter Name="FirstName" />
                <asp:Parameter Name="HomePhone" />
                <asp:Parameter Name="LastName" />
                <asp:Parameter Name="WorkPhone" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlClientSearch" Name="ClientID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="AddressCity" />
                <asp:Parameter Name="AddressCountry" />
                <asp:Parameter Name="AddressLine1" />
                <asp:Parameter Name="AddressLine2" />
                <asp:Parameter Name="AddressPostalCode" />
                <asp:Parameter Name="AddressRegion" />
                <asp:Parameter Name="FaxPhone" />
                <asp:Parameter Name="FirstName" />
                <asp:Parameter Name="HomePhone" />
                <asp:Parameter Name="LastName" />
                <asp:Parameter Name="WorkPhone" />
            </UpdateParameters>
        </asp:SqlDataSource>
        Company Information<br />
        <asp:DetailsView ID="dvClientCompany" runat="server" AutoGenerateRows="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" 
            DataSourceID="ODSGetCompany" GridLines="Vertical" Height="50px" 
            Width="250px" Enabled="False">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" 
                    SortExpression="CompanyID" />
                <asp:BoundField DataField="BillingAddressCity" HeaderText="BillingAddressCity" 
                    SortExpression="BillingAddressCity" />
                <asp:BoundField DataField="BillingAddressCountry" 
                    HeaderText="BillingAddressCountry" SortExpression="BillingAddressCountry" />
                <asp:BoundField DataField="BillingAddressLine1" 
                    HeaderText="BillingAddressLine1" SortExpression="BillingAddressLine1" />
                <asp:BoundField DataField="BillingAddressLine2" 
                    HeaderText="BillingAddressLine2" SortExpression="BillingAddressLine2" />
                <asp:BoundField DataField="BillingAddressPostalCode" 
                    HeaderText="BillingAddressPostalCode" 
                    SortExpression="BillingAddressPostalCode" />
                <asp:BoundField DataField="BillingAddressRegion" 
                    HeaderText="BillingAddressRegion" SortExpression="BillingAddressRegion" />
                <asp:BoundField DataField="BillingName" HeaderText="BillingName" 
                    SortExpression="BillingName" />
            </Fields>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        </asp:DetailsView>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
