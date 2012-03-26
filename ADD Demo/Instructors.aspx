<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instructors.aspx.cs" Inherits="ADD_Demo.Instructors" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="InstructorList" runat="server" 
            DataSourceID="InstructorsDataSource" DataTextField="FullName" 
            DataValueField="InstructorID" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="InstructorsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
            
            SelectCommand="SELECT [InstructorID], [FirstName], [LastName], FirstName + ' ' + LastName as FullName FROM [Instructors] ORDER BY [LastName], [FirstName]">
        </asp:SqlDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="394px" 
            AutoGenerateRows="False" DataKeyNames="InstructorID" 
            DataSourceID="InstructorDetailsDataSource">
            <Fields>
                <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="InstructorID" 
                    Visible="False" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" 
                    SortExpression="LastName" />
                <asp:BoundField DataField="HomePhone" HeaderText="Home Phone" 
                    SortExpression="HomePhone" />
                <asp:BoundField DataField="AltPhone" HeaderText="Alternate Phone" 
                    SortExpression="AltPhone" />
                <asp:BoundField DataField="AddressLine1" HeaderText="Address Line 1" 
                    SortExpression="AddressLine1" />
                <asp:BoundField DataField="AddressLine2" HeaderText="Address Line 2" 
                    SortExpression="AddressLine2" />
                <asp:BoundField DataField="AddressCity" HeaderText="City" 
                    SortExpression="AddressCity" />
                <asp:BoundField DataField="AddressRegion" HeaderText="Region" 
                    SortExpression="AddressRegion" />
                <asp:BoundField DataField="AddressCountry" HeaderText="Country" 
                    SortExpression="AddressCountry" />
                <asp:BoundField DataField="AddressPostalCode" HeaderText="Postal Code" 
                    SortExpression="AddressPostalCode" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="InstructorDetailsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
            
            SelectCommand="SELECT * FROM [Instructors] WHERE ([InstructorID] = @InstructorID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="InstructorList" Name="InstructorID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
