<%@ Page Title="Instructors" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Instructors.aspx.cs" Inherits="ADD_Demo.Instructors" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"><div>
    
        <h3>
            Instructors:</h3>
    
        <asp:DropDownList ID="InstructorList" runat="server" 
            DataSourceID="InstructorsDataSource" DataTextField="LastName" 
            DataValueField="InstructorID" AutoPostBack="True" 
            ondatabound="InstructorList_DataBound">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="InstructorsDataSource" runat="server" 
            SelectMethod="GetInstructors" TypeName="ADD_Demo.Classes.Instructor">
        </asp:ObjectDataSource>
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
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowInsertButton="True" />
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
