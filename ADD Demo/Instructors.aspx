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
                <asp:BoundField DataField="AddressCity" HeaderText="AddressCity" 
                    SortExpression="AddressCity" />
                <asp:BoundField DataField="AddressCountry" HeaderText="AddressCountry" 
                    SortExpression="AddressCountry" />
                <asp:BoundField DataField="AddressLine1" HeaderText="AddressLine1" 
                    SortExpression="AddressLine1" />
                <asp:BoundField DataField="AddressLine2" HeaderText="AddressLine2" 
                    SortExpression="AddressLine2" />
                <asp:BoundField DataField="AddressRegion" HeaderText="AddressRegion" 
                    SortExpression="AddressRegion" />
                <asp:BoundField DataField="AddressPostalCode" HeaderText="AddressPostalCode" 
                    SortExpression="AddressPostalCode" />
                <asp:BoundField DataField="AltPhone" HeaderText="AltPhone" 
                    SortExpression="AltPhone" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" 
                    SortExpression="HomePhone" />
                <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="InstructorID" 
                    Visible="False" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" 
                    SortExpression="LastName" />
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
