<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sessions.aspx.cs" Inherits="ADD_Demo.Sessions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Sessions</p>
    <p>
        <asp:DropDownList ID="ddlSessions" runat="server" AutoPostBack="True" 
            DataSourceID="ODSGetSessions" DataTextField="SessionDateTime" DataValueField="SessionID" 
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
            DataSourceID="ODSInstructor" DataTextField="InstructorFullName" 
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
    <p>
        Registered Clients:</p>
    <p>
        <asp:ObjectDataSource ID="ODSGetClientSessions" runat="server" 
            SelectMethod="GetClientSessionsBySessionID" TypeName="ADD_Demo.Classes.ClientSession" 
            UpdateMethod="UpdateClientSession">
            <SelectParameters>
                <asp:querystringparameter name="SessionID" querystringfield="SessionID" Type="Int32"/>
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="clientSession" Type="Object" />
                <asp:Parameter Name="oldClientSession" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="gvClientSessions" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ODSGetClientSessions">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
<asp:BoundField DataField="ClientFullName" HeaderText="Client Name" ReadOnly="True" 
                    SortExpression="ClientFullName"></asp:BoundField>
                <asp:BoundField DataField="StatusName" HeaderText="Status" 
                    ReadOnly="True" SortExpression="StatusName" />
                <asp:CheckBoxField DataField="ClientSessionPaid" HeaderText="Paid" 
                    SortExpression="ClientSessionPaid" />
                <asp:BoundField DataField="ClientSessionID" HeaderText="ClientSessionID" 
                    SortExpression="ClientSessionID" Visible="False" />
                <asp:BoundField DataField="ClientID" HeaderText="ClientID" 
                    SortExpression="ClientID" Visible="False" />
                <asp:BoundField DataField="StatusID" HeaderText="StatusID" 
                    SortExpression="StatusID" Visible="False" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        Register Client for Session by Company:</p>
    <p>
        Company: 
        <asp:DropDownList ID="ddlCompanies" runat="server" AutoPostBack="True" 
            DataSourceID="ODSGetCompanies" DataTextField="CompanyBillingName" 
            DataValueField="CompanyID">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp; Client:
        <asp:DropDownList ID="ddlClients" runat="server" 
            DataSourceID="ODSGetClientsByCompany" DataTextField="ClientFullName" 
            DataValueField="ClientID">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ODSGetCompanies" runat="server" 
            SelectMethod="GetCompanies" TypeName="ADD_Demo.Classes.Company">
        </asp:ObjectDataSource>
        <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
            Text="Register" />
    </p>
    <p>
        <asp:ObjectDataSource ID="ODSGetClientsByCompany" runat="server" 
            SelectMethod="GetClientsByCompanyID" TypeName="ADD_Demo.Classes.Client">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCompanies" Name="companyID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>
