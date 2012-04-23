<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SessionReports.aspx.cs" Inherits="ADD_Demo.Reports.SessionReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ODSGetCourse" runat="server" SelectMethod="GetCourse" 
        TypeName="ADD_Demo.Classes.Course">
        <SelectParameters>
            <asp:QueryStringParameter Name="courseID" QueryStringField="CourseID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSGetSessionsByCourse" runat="server" 
        SelectMethod="GetSessionsByCourseID" TypeName="ADD_Demo.Classes.Session">
        <SelectParameters>
            <asp:QueryStringParameter Name="courseID" QueryStringField="CourseID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataSourceID="ODSGetCourse" Height="50px" Width="500px">
        <Fields>
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" 
                SortExpression="CourseID" Visible="False" />
            <asp:BoundField DataField="CourseCode" HeaderText="Course Code" 
                SortExpression="CourseCode" />
            <asp:BoundField DataField="CourseDescription" HeaderText="Course Description" 
                SortExpression="CourseDescription" />
            <asp:BoundField DataField="CourseOutline" HeaderText="Course Outline" 
                SortExpression="CourseOutline" />
            <asp:BoundField DataField="CoursePrice" HeaderText="Course Price" 
                SortExpression="CoursePrice" />
        </Fields>
    </asp:DetailsView>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ODSGetSessionsByCourse">
        <Columns>
            <asp:BoundField DataField="SessionID" HeaderText="SessionID" 
                SortExpression="SessionID" Visible="False" />
            <asp:BoundField DataField="SessionDateTime" HeaderText="Session Date" 
                SortExpression="SessionDateTime" />
            <asp:BoundField DataField="SessionLength" HeaderText="Session Length" 
                SortExpression="SessionLength" />
            <asp:BoundField DataField="SessionEnrolled" HeaderText="Session Enrolled" 
                SortExpression="SessionEnrolled" />
            <asp:BoundField DataField="SessionAvailableSeats" 
                HeaderText="Session Available Seats" SortExpression="SessionAvailableSeats" />
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" 
                SortExpression="CourseID" Visible="False" />
            <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" 
                SortExpression="InstructorID" Visible="False" />
            <asp:BoundField DataField="InstructorFullName" HeaderText="InstructorFullName" 
                ReadOnly="True" SortExpression="InstructorFullName" />
            <asp:BoundField DataField="RoomID" HeaderText="RoomID" SortExpression="RoomID" 
                Visible="False" />
            <asp:BoundField DataField="RoomName" HeaderText="Room Name" ReadOnly="True" 
                SortExpression="RoomName" />
        </Columns>
    </asp:GridView>
</asp:Content>
