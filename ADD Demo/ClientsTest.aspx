<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientsTest.aspx.cs" Inherits="ADD_Demo.Clients" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Search Client:
        <asp:TextBox ID="tbClientSearch" runat="server" 
            ontextchanged="tbClientSearch_TextChanged" Width="305px"></asp:TextBox>
        <br />
        <br />
        First Name:<asp:TextBox ID="tbClientFirstName" runat="server"></asp:TextBox>
&nbsp;Last Name:<asp:TextBox ID="tbClientLastName" runat="server"></asp:TextBox>
        <br />
        <br />
        Address Information<br />
        Address:<br />
        <asp:TextBox ID="tbClientAddress1" runat="server" Width="380px"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbClientAddress2" runat="server" Width="380px"></asp:TextBox>
        <br />
        City:
        <asp:TextBox ID="tbClientCity" runat="server"></asp:TextBox>
&nbsp;&nbsp; Country:
        <asp:TextBox ID="tbClientCountry" runat="server"></asp:TextBox>
        <br />
        Postal Code:<asp:TextBox ID="tbClientPostal" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Region:
        <asp:TextBox ID="tbClientRegion" runat="server"></asp:TextBox>
        <br />
        <br />
        Contact Information<br />
        Phone<br />
&nbsp;&nbsp;&nbsp; Home:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbClientPhoneHome" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp; Work:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbClientPhoneWork" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp; Fax:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbClientPhoneFax" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="SDSSearch" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
            SelectCommand="SELECT * FROM [Clients] WHERE (([ClientID] = @ClientID) OR ([FirstName] = @FirstName) OR ([AddressPostalCode] = @AddressPostalCode) OR ([LastName] = @LastName)) ORDER BY [LastName]">
            <SelectParameters>
                <asp:ControlParameter ControlID="tbClientSearch" Name="ClientID" 
                    PropertyName="Text" Type="Int16" />
                <asp:ControlParameter ControlID="tbClientSearch" Name="FirstName" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="tbClientSearch" Name="AddressPostalCode" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="tbClientSearch" Name="LastName" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
            SelectCommand="SELECT * FROM [Clients]"></asp:SqlDataSource>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
