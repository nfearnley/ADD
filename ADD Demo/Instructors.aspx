<%@ Page Title="Instructors" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Instructors.aspx.cs" Inherits="ADD_Demo.Instructors" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h3>
            Instructors:</h3>
        <asp:DropDownList ID="InstructorList" runat="server" DataSourceID="InstructorsDataSource"
            DataTextField="InstructorFullName" DataValueField="InstructorID" AutoPostBack="True" OnDataBound="InstructorList_DataBound">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="InstructorsDataSource" runat="server" SelectMethod="GetInstructors"
            TypeName="ADD_Demo.Classes.Instructor"></asp:ObjectDataSource>
        <asp:DetailsView ID="InstructorDetails" runat="server" Height="50px" Width="394px"
            AutoGenerateRows="False" DataKeyNames="InstructorID" DataSourceID="InstructorDetailsDataSource">
            <EmptyDataTemplate>
                <asp:LinkButton ID="InsertButton" runat="server" OnClick="InsertButton_Click">New</asp:LinkButton>
            </EmptyDataTemplate>
            <Fields>
                <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" InsertVisible="False"
                    ReadOnly="True" SortExpression="InstructorID" Visible="False" />
                <asp:TemplateField HeaderText="First Name" SortExpression="InstructorFirstName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("InstructorFirstName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox10"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" CausesValidation="True" Text='<%# Bind("InstructorFirstName") %>'
                            ValidationGroup="Required"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox10"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("InstructorFirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name" SortExpression="InstructorLastName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("InstructorLastName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox9"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("InstructorLastName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox9"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("InstructorLastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Home Phone" SortExpression="InstructorHomePhone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" MaxLength="10" Text='<%# Bind("InstructorHomePhone") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox8"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" MaxLength="10" Text='<%# Bind("InstructorHomePhone") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox8"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("InstructorHomePhone") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alternate Phone" SortExpression="InstructorAltPhone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" MaxLength="10" Text='<%# Bind("InstructorAltPhone") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" MaxLength="10" Text='<%# Bind("InstructorAltPhone") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("InstructorAltPhone") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address Line 1" SortExpression="InstructorAddressLine1">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("InstructorAddressLine1") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("InstructorAddressLine1") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("InstructorAddressLine1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address Line 2" SortExpression="InstructorAddressLine2">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("InstructorAddressLine2") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("InstructorAddressLine2") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("InstructorAddressLine2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="City" SortExpression="InstructorAddressCity">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("InstructorAddressCity") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("InstructorAddressCity") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("InstructorAddressCity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Region" SortExpression="InstructorAddressRegion">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("InstructorAddressRegion") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("InstructorAddressRegion") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("InstructorAddressRegion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country" SortExpression="InstructorAddressCountry">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("InstructorAddressCountry") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("InstructorAddressCountry") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("InstructorAddressCountry") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Postal Code" SortExpression="InstructorAddressPostalCode">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("InstructorAddressPostalCode") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("InstructorAddressPostalCode") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Required" ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("InstructorAddressPostalCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True"
                    ValidationGroup="Instructor" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="InstructorDetailsDataSource" runat="server" ConflictDetection="CompareAllValues"
            DataObjectTypeName="ADD_Demo.Classes.Instructor" DeleteMethod="RemoveInstructor"
            InsertMethod="AddInstructor" OldValuesParameterFormatString="old{0}" SelectMethod="GetInstructor"
            TypeName="ADD_Demo.Classes.Instructor" UpdateMethod="UpdateInstructor" OnInserted="InstructorDetailsDataSource_Inserted"
            OnDeleted="InstructorDetailsDataSource_Deleted">
            <SelectParameters>
                <asp:ControlParameter ControlID="InstructorList" Name="instructorID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <h3>
        Qualifications:</h3>
    <asp:GridView ID="InstructorQualificationsList" runat="server" AutoGenerateColumns="False"
        DataSourceID="InstructorQualificationsDataSource">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" 
                SortExpression="CourseID" Visible="False" />
            <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" 
                SortExpression="InstructorID" Visible="False" />
            <asp:BoundField DataField="CourseCode" HeaderText="Course Code" 
                SortExpression="CourseCode" />
            <asp:BoundField DataField="CourseDescription" HeaderText="Description" 
                SortExpression="CourseDescription" />
            <asp:HyperLinkField DataNavigateUrlFields="CourseID" 
                DataNavigateUrlFormatString="Courses.aspx?CourseID={0}" Text="link" />
        </Columns>
        <EmptyDataTemplate>
            This instructor is not qualified to teach.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="InstructorQualificationsDataSource" runat="server" ConflictDetection="CompareAllValues"
        DataObjectTypeName="ADD_Demo.Classes.InstructorQualification" DeleteMethod="RemoveInstructorQualification"
        InsertMethod="AddInstructorQualification" SelectMethod="GetInstructorQualificationsByInstructorID"
        TypeName="ADD_Demo.Classes.InstructorQualification" OldValuesParameterFormatString="old{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="InstructorList" Name="instructorID" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DropDownList ID="UnqualifiedQualificationList" runat="server" DataSourceID="UnqualifiedCoursesDataSource"
        DataTextField="CourseCode" DataValueField="CourseID" OnDataBound="UnqualifiedQualificationList_DataBound">
    </asp:DropDownList>
    <asp:LinkButton ID="AddQualificationButton" runat="server" OnClick="AddQualificationButton_Click">Add</asp:LinkButton>
    <asp:ObjectDataSource ID="UnqualifiedCoursesDataSource" runat="server" SelectMethod="GetUnqualifiedCoursesByInstructorID"
        TypeName="ADD_Demo.Classes.Course" ConflictDetection="CompareAllValues" OldValuesParameterFormatString="old{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="InstructorList" Name="instructorID" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Sessions:
    </h3><asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" DataSourceID="SessionsDataSource">
            <Columns>
                <asp:BoundField DataField="SessionID" HeaderText="SessionID" 
                    SortExpression="SessionID" Visible="False" />
                <asp:BoundField DataField="CourseID" HeaderText="CourseID" 
                    SortExpression="CourseID" Visible="False" />
                <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" 
                    SortExpression="InstructorID" Visible="False" />
                <asp:BoundField DataField="RoomID" HeaderText="RoomID" 
                    SortExpression="RoomID" Visible="False" />
                <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" 
                    SortExpression="CourseCode" />
                <asp:BoundField DataField="CourseDescription" HeaderText="CourseDescription" 
                    SortExpression="CourseDescription" />
                <asp:BoundField DataField="CourseOutline" HeaderText="CourseOutline" 
                    SortExpression="CourseOutline" />
                <asp:BoundField DataField="CoursePrice" HeaderText="CoursePrice" 
                    SortExpression="CoursePrice" />
                <asp:BoundField DataField="RoomName" HeaderText="RoomName" 
                    SortExpression="RoomName" />
                <asp:BoundField DataField="RoomSeats" HeaderText="RoomSeats" SortExpression="RoomSeats" />
                <asp:BoundField DataField="SessionDateTime" HeaderText="SessionDateTime" 
                    SortExpression="SessionDateTime" />
                <asp:BoundField DataField="SessionLength" HeaderText="SessionLength" 
                    SortExpression="SessionLength" />
                <asp:BoundField DataField="SessionEnrolled" HeaderText="SessionEnrolled" 
                    SortExpression="SessionEnrolled" />
                <asp:BoundField DataField="SessionAvailableSeats" HeaderText="SessionAvailableSeats" 
                    SortExpression="SessionAvailableSeats" />
                <asp:HyperLinkField DataNavigateUrlFields="SessionID" 
                    DataNavigateUrlFormatString="Sessions.aspx?SessionID={0}" Text="link" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="SessionsDataSource" runat="server" 
            SelectMethod="GetSessionsByInstructorID" TypeName="ADD_Demo.Classes.Session">
            <SelectParameters>
                <asp:ControlParameter ControlID="InstructorList" Name="instructorID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
</asp:Content>
