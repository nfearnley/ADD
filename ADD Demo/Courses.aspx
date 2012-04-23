<%@ Page Title="Courses" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Courses.aspx.cs" Inherits="ADD_Demo.Courses" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"><div>
    
        Choose a Course:<br />
        <asp:DropDownList ID="ddlCourses" runat="server" 
            DataSourceID="ODSGetCourses" DataTextField="CourseCode" 
            DataValueField="CourseID" AutoPostBack="True" 
            onselectedindexchanged="ddlCourses_SelectedIndexChanged" 
            ondatabound="ddlCourses_DataBound">
        </asp:DropDownList>
        <br />
    
        <asp:ObjectDataSource ID="ODSGetCourses" runat="server" 
            SelectMethod="GetCourses" TypeName="ADD_Demo.Classes.Course">
        </asp:ObjectDataSource>
        <asp:DetailsView ID="dvCourseInfo" runat="server" AutoGenerateRows="False" 
            DataSourceID="ODSGetCourse" Height="50px" Width="250px">
            <Fields>
                <asp:BoundField DataField="CourseID" HeaderText="CourseID" 
                    SortExpression="CourseID" Visible="False" />
                <asp:BoundField DataField="CourseCode" HeaderText="Course Code" 
                    SortExpression="CourseCode" />
                <asp:BoundField DataField="CourseDescription" HeaderText="Description" 
                    SortExpression="Description" />
                <asp:BoundField DataField="CourseOutline" HeaderText="Outline" 
                    SortExpression="Outline" />
                <asp:BoundField DataField="CoursePrice" HeaderText="Price" 
                    SortExpression="Price" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ODSGetCourse" runat="server" 
            DataObjectTypeName="ADD_Demo.Classes.Course" DeleteMethod="RemoveCourse" 
            InsertMethod="AddCourse" SelectMethod="GetCourse" 
            TypeName="ADD_Demo.Classes.Course" UpdateMethod="UpdateCourse">
            <DeleteParameters>
                <asp:Parameter Name="courseID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCourses" Name="courseID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        Sessions<br />
        Create new session:<br />
        <asp:Calendar ID="calNewSessionDate" runat="server"></asp:Calendar>
        Length of Session in Hours:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNewSessionLength" runat="server"></asp:TextBox>
        <br />
        Instructor:&nbsp;&nbsp;<asp:DropDownList ID="ddlNewSessionInstructors" 
            runat="server" DataSourceID="ODSSessionInstructors" 
            DataTextField="InstructorFullName" DataValueField="InstructorID">
        </asp:DropDownList>
&nbsp;<asp:ObjectDataSource ID="ODSSessionInstructors" runat="server" 
            SelectMethod="GetInstructorsByCourseID" TypeName="ADD_Demo.Classes.Instructor">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCourses" Name="courseID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSSessionRooms" runat="server" 
            SelectMethod="GetRooms" TypeName="ADD_Demo.Classes.Room">
        </asp:ObjectDataSource>
        <br />
        Room:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlNewSessionRooms" runat="server" 
            DataSourceID="ODSSessionRooms" DataTextField="RoomName" DataValueField="RoomID" 
            ondatabound="ddlNewSessionRooms_DataBound">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnNewSession" runat="server" onclick="btnNewSession_Click" 
            Text="Create New Session" />
        <asp:ObjectDataSource ID="ODSSessionsByCourse" runat="server" 
            DataObjectTypeName="ADD_Demo.Classes.Session" InsertMethod="AddSession" 
            SelectMethod="GetSessionsByCourseID" TypeName="ADD_Demo.Classes.Session">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCourses" Name="courseID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:GridView ID="gvSessions2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ODSGetSessions">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="SessionID" HeaderText="SessionID" 
                    SortExpression="SessionID" Visible="False" />
                <asp:BoundField DataField="SessionDateTime" HeaderText="Date" 
                    SortExpression="SessionDateTime" />
                <asp:BoundField DataField="SessionLength" HeaderText="Length" 
                    SortExpression="SessionLength" />
                <asp:BoundField DataField="SessionEnrolled" HeaderText="Enrolled" 
                    SortExpression="SessionEnrolled" />
                <asp:BoundField DataField="SessionAvailableSeats" HeaderText="Available Seats" 
                    SortExpression="SessionAvailableSeats" />
                <asp:BoundField DataField="InstructorFullName" HeaderText="Full Name" 
                    ReadOnly="True" SortExpression="InstructorFullName" />
                <asp:BoundField DataField="RoomName" HeaderText="Room" ReadOnly="True" 
                    SortExpression="RoomName" />
                <asp:HyperLinkField DataNavigateUrlFields="SessionID" 
                    DataNavigateUrlFormatString="Sessions.aspx?SessionID={0}" Text="link" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSGetSessions" runat="server" 
            SelectMethod="GetSessionsByCourseID" TypeName="ADD_Demo.Classes.Session">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCourses" Name="courseID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        Register Client by Company:<br />
        <asp:DropDownList ID="ddlCompanies" runat="server" AutoPostBack="True" 
            DataSourceID="ODSGetCompanies" DataTextField="CompanyBillingName" 
            DataValueField="CompanyID">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ODSGetCompanies" runat="server" 
            SelectMethod="GetCompanies" TypeName="ADD_Demo.Classes.Company">
        </asp:ObjectDataSource>
        <asp:GridView ID="gvClientsByCompany" runat="server" 
            AutoGenerateColumns="False" DataSourceID="ODSGetClientsByCompany" Width="250px">
            <Columns>
                <asp:CommandField 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="ClientID" HeaderText="ClientID" 
                    SortExpression="ClientID" Visible="False" />
                <asp:BoundField DataField="ClientFirstName" HeaderText="First Name" 
                    SortExpression="ClientFirstName" />
                <asp:BoundField DataField="ClientLastName" HeaderText="Last Name" 
                    SortExpression="ClientLastName" />
                <asp:HyperLinkField DataNavigateUrlFields="ClientID" 
                    DataNavigateUrlFormatString="Clients.aspx?ClientID={0}" Text="link" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
            Text="Register" />
        <asp:ObjectDataSource ID="ODSGetClientsByCompany" runat="server" 
            SelectMethod="GetClientsByCompanyID" TypeName="ADD_Demo.Classes.Client">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCompanies" Name="companyID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    
    </div>
</asp:Content>
