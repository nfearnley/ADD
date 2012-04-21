<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sessions.aspx.cs" Inherits="ADD_Demo.Sessions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Sessions</p>
    <p>
        <asp:DropDownList ID="ddlSessions" runat="server" AutoPostBack="True" 
            DataSourceID="ODSGetSessions" DataTextField="Date" DataValueField="SessionID" 
            Visible="False">
        </asp:DropDownList>
    </p>
    <p>
        <asp:ObjectDataSource ID="ODSGetSessions" runat="server" 
            SelectMethod="GetSessions" TypeName="ADD_Demo.Classes.Session">
        </asp:ObjectDataSource>
    </p>
    <p>
        Course Code:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbCourseCode" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        <asp:DropDownList ID="ddlCourseCode" runat="server" DataSourceID="ODSCourse" 
            DataTextField="CourseCode" DataValueField="CourseID" Visible="False">
        </asp:DropDownList>
    </p>
    <p>
        Room Name:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbRoomName" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:DropDownList ID="ddlRoomName" runat="server" DataSourceID="ODSRoom" 
            DataTextField="RoomName" DataValueField="RoomID" Visible="False">
        </asp:DropDownList>
    </p>
    <p>
        Instructor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbInstructor" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:DropDownList ID="ddlInstructor" runat="server" 
            DataSourceID="ODSInstructor" DataTextField="FullName" 
            DataValueField="InstructorID" Visible="False">
        </asp:DropDownList>
    </p>
    <p>
        Length:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbLength" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p>
        Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbDate" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:Calendar ID="calDate" runat="server" Visible="False"></asp:Calendar>
    </p>
    <p>
        <asp:Button ID="btnEdit" runat="server" onclick="btnEdit_Click" Text="Edit" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
        <asp:ObjectDataSource ID="ODSSessionInfoEdit" runat="server" 
            DataObjectTypeName="ADD_Demo.Classes.Session" DeleteMethod="RemoveSession" 
            InsertMethod="AddSession" SelectMethod="GetSession" 
            TypeName="ADD_Demo.Classes.Session" UpdateMethod="UpdateSession">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlSessions" Name="sessionID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="session" Type="Object" />
                <asp:Parameter Name="oldSession" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSCourse" runat="server" SelectMethod="GetCourses" 
            TypeName="ADD_Demo.Classes.Course"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSRoom" runat="server" SelectMethod="GetRooms" 
            TypeName="ADD_Demo.Classes.Room"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSInstructor" runat="server" 
            SelectMethod="GetInstructorsByCourseID" TypeName="ADD_Demo.Classes.Instructor">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCourseCode" Name="courseID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>
