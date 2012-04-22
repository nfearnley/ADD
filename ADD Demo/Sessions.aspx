<%@ Page Title="Sessions" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Sessions.aspx.cs" Inherits="ADD_Demo.Sessions" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"><div>
    
        <h3>
            Sessions</h3>
        <p>
            &nbsp;</p>
    
        <asp:DropDownList ID="SessionList" runat="server" 
            DataSourceID="SessionsDataSource" DataTextField="SessionID" 
            DataValueField="SessionID" AutoPostBack="True" 
            ondatabound="InstructorList_DataBound" Visible="False">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="SessionsDataSource" runat="server" 
            SelectMethod="GetSessions" TypeName="ADD_Demo.Classes.Session">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="SessionDataSource" runat="server" 
            SelectMethod="GetSession" TypeName="ADD_Demo.Classes.Session" 
            DataObjectTypeName="ADD_Demo.Classes.Session" DeleteMethod="RemoveSession" 
            InsertMethod="AddSession" UpdateMethod="UpdateSession">
            <SelectParameters>
                <asp:ControlParameter ControlID="SessionList" Name="sessionID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="session" Type="Object" />
                <asp:Parameter Name="oldSession" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="394px" 
            AutoGenerateRows="False" 
            DataSourceID="SessionDataSource">
            <Fields>
                <asp:BoundField DataField="SessionID" HeaderText="SessionID" 
                    SortExpression="SessionID" />
                <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" 
                    SortExpression="InstructorID" />
                <asp:BoundField DataField="RoomID" HeaderText="RoomID" 
                    SortExpression="RoomID" />
                <asp:BoundField DataField="Length" HeaderText="Length" 
                    SortExpression="Length" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="InstructorDetailsDataSource" runat="server" 
            ConflictDetection="CompareAllValues" 
            DataObjectTypeName="ADD_Demo.Classes.Instructor" 
            DeleteMethod="RemoveInstructor" InsertMethod="AddInstructor" 
            OldValuesParameterFormatString="old{0}" SelectMethod="GetInstructor" 
            TypeName="ADD_Demo.Classes.Instructor" UpdateMethod="UpdateInstructor" 
            oninserted="InstructorDetailsDataSource_Inserted" 
            ondeleted="InstructorDetailsDataSource_Deleted">
            <DeleteParameters>
                <asp:Parameter Name="instructorID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="InstructorList" Name="instructorID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    <h3>
        Qualifications:</h3>
    <asp:SqlDataSource ID="InstructorQualificationsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ADDDatabase %>" 
        SelectCommand="SELECT Courses.Description, Courses.CourseCode FROM InstructorQualifications INNER JOIN Courses ON InstructorQualifications.CourseID = Courses.CourseID WHERE (InstructorQualifications.InstructorID = @InstructorID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="InstructorList" Name="InstructorID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="InstructorQualificationsDataSource">
        <Columns>
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="CourseCode" HeaderText="Course Code" 
                SortExpression="CourseCode" />
        </Columns>
        <EmptyDataTemplate>
            This instructor is not qualified to teach.
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
