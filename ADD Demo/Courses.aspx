<%@ Page Title="Courses" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Courses.aspx.cs" Inherits="ADD_Demo.Courses" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"><div>
    
        Choose a Course:<br />
        <asp:DropDownList ID="ddlCourses" runat="server" 
            DataSourceID="ODSGetCourses" DataTextField="CourseCode" 
            DataValueField="CourseID" AutoPostBack="True">
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
