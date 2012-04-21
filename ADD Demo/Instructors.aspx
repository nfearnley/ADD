<%@ Page Title="Instructors" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Instructors.aspx.cs" Inherits="ADD_Demo.Instructors" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"><div>
    
        <h3>
            Instructors:</h3>
    
        <asp:DropDownList ID="InstructorList" runat="server" 
            DataSourceID="InstructorsDataSource" DataTextField="FullName" 
            DataValueField="InstructorID" AutoPostBack="True" 
            ondatabound="InstructorList_DataBound">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="InstructorsDataSource" runat="server" 
            SelectMethod="GetInstructors" TypeName="ADD_Demo.Classes.Instructor">
        </asp:ObjectDataSource>
        <asp:DetailsView ID="InstructorDetails" runat="server" Height="50px" Width="394px" 
            AutoGenerateRows="False" DataKeyNames="InstructorID" 
            DataSourceID="InstructorDetailsDataSource">
            <EmptyDataTemplate>
                <asp:LinkButton ID="InsertButton" runat="server" onclick="InsertButton_Click">New</asp:LinkButton>
            </EmptyDataTemplate>
            <Fields>
                <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="InstructorID" 
                    Visible="False" />
                <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="TextBox10" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" CausesValidation="True" 
                            Text='<%# Bind("FirstName") %>' ValidationGroup="Required"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="TextBox10" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="TextBox9" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="TextBox9" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Home Phone" SortExpression="HomePhone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" MaxLength="10" 
                            Text='<%# Bind("HomePhone") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="TextBox8" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" MaxLength="10" 
                            Text='<%# Bind("HomePhone") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="TextBox8" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("HomePhone") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alternate Phone" SortExpression="AltPhone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" MaxLength="10" 
                            Text='<%# Bind("AltPhone") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" MaxLength="10" 
                            Text='<%# Bind("AltPhone") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("AltPhone") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address Line 1" SortExpression="AddressLine1">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("AddressLine1") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="TextBox6" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("AddressLine1") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="TextBox6" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("AddressLine1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address Line 2" SortExpression="AddressLine2">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("AddressLine2") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("AddressLine2") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("AddressLine2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="City" 
                    SortExpression="AddressCity">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("AddressCity") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("AddressCity") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("AddressCity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Region" SortExpression="AddressRegion">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AddressRegion") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AddressRegion") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("AddressRegion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country" SortExpression="AddressCountry">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AddressCountry") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AddressCountry") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("AddressCountry") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Postal Code" SortExpression="AddressPostalCode">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("AddressPostalCode") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("AddressPostalCode") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="Required" 
                            ValidationGroup="Instructor"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("AddressPostalCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowInsertButton="True" ValidationGroup="Instructor" />
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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="InstructorQualificationsDataSource">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" 
                SortExpression="CourseID" Visible="False" />
            <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" 
                SortExpression="InstructorID" Visible="False" />
            <asp:TemplateField HeaderText="Course Code" SortExpression="Code">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CourseID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Course.CourseCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="InstructorID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("InstructorID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Course.Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            This instructor is not qualified to teach.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="InstructorQualificationsDataSource" runat="server" 
        ConflictDetection="CompareAllValues" 
        DataObjectTypeName="ADD_Demo.Classes.InstructorQualification" 
        DeleteMethod="RemoveInstructorQualification" 
        InsertMethod="AddInstructorQualification" 
        SelectMethod="GetInstructorQualificationsByInstructorID" 
        TypeName="ADD_Demo.Classes.InstructorQualification" 
        OldValuesParameterFormatString="old{0}" 
        oninserting="InstructorQualificationsDataSource_Inserting">
        <SelectParameters>
            <asp:ControlParameter ControlID="InstructorList" Name="instructorID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DropDownList ID="UnqualifiedQualificationList" runat="server" 
        DataSourceID="UnqualifiedCoursesDataSource" DataTextField="CourseCode" 
        DataValueField="CourseID">
    </asp:DropDownList>
    <asp:LinkButton ID="AddQualificationButton" runat="server" 
        onclick="AddQualificationButton_Click">Add</asp:LinkButton>
    <asp:ObjectDataSource ID="UnqualifiedCoursesDataSource" runat="server" 
        SelectMethod="GetUnqualifiedCoursesByInstructorID" 
        TypeName="ADD_Demo.Classes.Course">
        <SelectParameters>
            <asp:ControlParameter ControlID="InstructorList" Name="instructorID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
