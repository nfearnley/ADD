<%@ Page Title="Courses" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Courses.aspx.cs" Inherits="ADD_Demo.Courses" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"><div>
    
        Choose a Course:<br />
        <asp:DropDownList ID="ddlCourses" runat="server" 
            DataSourceID="ODSGetCourses" DataTextField="CourseCode" 
            DataValueField="CourseID" AutoPostBack="True" 
            onselectedindexchanged="ddlCourses_SelectedIndexChanged">
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
                <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" 
                    SortExpression="CourseCode" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
                <asp:BoundField DataField="Outline" HeaderText="Outline" 
                    SortExpression="Outline" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
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
        <asp:ObjectDataSource ID="ODSSessionsByCourse" runat="server" 
            DataObjectTypeName="ADD_Demo.Classes.Session" InsertMethod="AddSession" 
            SelectMethod="GetSessionsByCourseID" TypeName="ADD_Demo.Classes.Session">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCourses" Name="courseID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="gvSessions" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ODSSessionsByCourse">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Length" HeaderText="Length" 
                    SortExpression="Length" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="SessionID" HeaderText="SessionID" 
                    SortExpression="SessionID" Visible="False" />
                <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" 
                    SortExpression="InstructorID" Visible="False" />
                <asp:BoundField DataField="FirstName + LastName" HeaderText="Instructor" 
                    SortExpression="InstructorID" />
                <asp:BoundField DataField="RoomID" HeaderText="RoomID" SortExpression="RoomID" 
                    Visible="False" />
                <asp:BoundField DataField="RoomName" HeaderText="Room" 
                    SortExpression="RoomID" />
            </Columns>
        </asp:GridView>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
            DataSourceID="ODSSessionsByCourse">
            <EditItemTemplate>
                SessionID:
                <asp:TextBox ID="SessionIDTextBox" runat="server" 
                    Text='<%# Bind("SessionID") %>' />
                <br />
                InstructorID:
                <asp:TextBox ID="InstructorIDTextBox" runat="server" 
                    Text='<%# Bind("InstructorID") %>' />
                <br />
                RoomID:
                <asp:TextBox ID="RoomIDTextBox" runat="server" Text='<%# Bind("RoomID") %>' />
                <br />
                Length:
                <asp:TextBox ID="LengthTextBox" runat="server" Text='<%# Bind("Length") %>' />
                <br />
                Date:
                <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Instructor:
                <asp:TextBox ID="InstructorIDTextBox" runat="server" 
                    Text='<%# Bind("InstructorID") %>' />
                <br />
                RoomID:
                <asp:TextBox ID="RoomIDTextBox" runat="server" Text='<%# Bind("RoomID") %>' />
                <br />
                Length:
                <asp:TextBox ID="LengthTextBox" runat="server" Text='<%# Bind("Length") %>' />
                <br />
                Date:
                <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                <br />
                <asp:ObjectDataSource ID="ODSGetInstructors" runat="server" 
                    SelectMethod="GetInstructor" TypeName="ADD_Demo.Classes.Instructor">
                    <SelectParameters>
                        <asp:FormParameter FormField="InstructorID" Name="instructorID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" />
&nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" 
                    CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                SessionID:
                <asp:Label ID="SessionIDLabel" runat="server" Text='<%# Bind("SessionID") %>' />
                <br />
                InstructorID:
                <asp:Label ID="InstructorIDLabel" runat="server" 
                    Text='<%# Bind("InstructorID") %>' />
                <br />
                RoomID:
                <asp:Label ID="RoomIDLabel" runat="server" Text='<%# Bind("RoomID") %>' />
                <br />
                Length:
                <asp:Label ID="LengthLabel" runat="server" Text='<%# Bind("Length") %>' />
                <br />
                Date:
                <asp:Label ID="DateLabel" runat="server" Text='<%# Bind("Date") %>' />
                <br />
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New" />
            </ItemTemplate>
        </asp:FormView>
        <br />
        Register Client by Company:<br />
        <asp:DropDownList ID="ddlCompanies" runat="server" AutoPostBack="True" 
            DataSourceID="ODSGetCompanies" DataTextField="BillingName" 
            DataValueField="CompanyID">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ODSGetCompanies" runat="server" 
            SelectMethod="GetCompanies" TypeName="ADD_Demo.Classes.Company">
        </asp:ObjectDataSource>
        <asp:GridView ID="gvClientsByCompany" runat="server" 
            AutoGenerateColumns="False" DataSourceID="ODSGetClientsByCompany" Width="250px">
            <Columns>
                <asp:BoundField DataField="ClientID" HeaderText="ClientID" 
                    SortExpression="ClientID" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" 
                    SortExpression="LastName" />
                <asp:CommandField ButtonType="Button" SelectText="Enroll" 
                    ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
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
