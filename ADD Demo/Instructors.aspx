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
            DataValueField="InstructorID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="InstructorsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ADD Database %>" 
            SelectCommand="SELECT [InstructorID], [FirstName], [LastName], FirstName + ' ' + LastName as FullName FROM [Instructors] ORDER BY [LastName], [FirstName]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="InstructorDetailsDataSource" runat="server">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
