<%@ Page Title="Clients" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="ADD_Demo.Clients" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    
        <asp:Label ID="lblClientSearch" runat="server" Text="Search for a Client"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlClientSearch" runat="server" AutoPostBack="True" 
            DataSourceID="ODSGetClients" DataTextField="ClientFullName" 
            DataValueField="ClientID" 
            ondatabound="ddlClientSearch_DataBound">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ODSGetClients" runat="server" 
            SelectMethod="GetClients" TypeName="ADD_Demo.Classes.Client">
        </asp:ObjectDataSource>
        <br />
        <asp:Label ID="lblClientInfo" runat="server" Text="Client Information"></asp:Label>
        <asp:DetailsView ID="dvClientDetails" runat="server" AutoGenerateRows="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataSourceID="ODSGetClient" 
            GridLines="Vertical" Height="50px" Width="250px" 
            onmodechanged="dvClientDetails_ModeChanged">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="ClientFirstName" HeaderText="First Name" 
                    SortExpression="ClientFirstName" />
                <asp:BoundField DataField="ClientLastName" HeaderText="Last Name" 
                    SortExpression="ClientLastName" />
                <asp:BoundField DataField="ClientHomePhone" HeaderText="Home Phone" 
                    SortExpression="ClientHomePhone" />
                <asp:BoundField DataField="ClientWorkPhone" HeaderText="Work Phone" 
                    SortExpression="ClientWorkPhone" />
                <asp:BoundField DataField="ClientFaxPhone" HeaderText="Fax Phone" 
                    SortExpression="ClientFaxPhone" />
                <asp:BoundField DataField="ClientAddressCity" HeaderText="City" 
                    SortExpression="ClientAddressCity" />
                <asp:BoundField DataField="ClientAddressCountry" HeaderText="Country" 
                    SortExpression="ClientAddressCountry" />
                <asp:BoundField DataField="ClientAddressRegion" HeaderText="Region" 
                    SortExpression="ClientAddressRegion" />
                <asp:BoundField DataField="ClientAddressLine1" HeaderText="Address Line  1" 
                    SortExpression="ClientAddressLine1" />
                <asp:BoundField DataField="ClientAddressLine2" HeaderText="Address Line 2" 
                    SortExpression="ClientAddressLine2" />
                <asp:BoundField DataField="ClientAddressPostalCode" HeaderText="Postal Code" 
                    SortExpression="ClientAddressPostalCode" />
                <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyID" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="ODSGetCompanies" DataTextField="CompanyBillingName" 
                            DataValueField="CompanyID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="ODSGetCompanies" DataTextField="CompanyBillingName" 
                            DataValueField="CompanyID">
                        </asp:DropDownList>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowInsertButton="True" />
                <asp:BoundField DataField="ClientID" HeaderText="ClientID" 
                    SortExpression="ClientID" InsertVisible="False" Visible="False" />
            </Fields>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ODSGetClient" runat="server" 
            ConflictDetection="CompareAllValues" 
            DataObjectTypeName="ADD_Demo.Classes.Client" DeleteMethod="RemoveClient" 
            InsertMethod="AddClient" OldValuesParameterFormatString="old{0}" 
            SelectMethod="GetClient" TypeName="ADD_Demo.Classes.Client" 
            UpdateMethod="UpdateClient">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlClientSearch" Name="clientID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="client" Type="Object" />
                <asp:Parameter Name="oldClient" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        Company Information<br />
        <asp:DetailsView ID="dvClientCompany" runat="server" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" Height="50px" 
            Width="250px" AutoGenerateRows="False" DataSourceID="ODSGetClient">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="CompanyID" 
                    HeaderText="CompanyID" />
                <asp:BoundField DataField="CompanyBillingName" HeaderText="Company Name" />
                <asp:HyperLinkField DataNavigateUrlFields="CompanyID" 
                    DataNavigateUrlFormatString="Companies.aspx?CompanyID={0}" Text="link" />
            </Fields>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        </asp:DetailsView>
        <br />
        <asp:ObjectDataSource ID="ODSGetCompanies" runat="server" 
            SelectMethod="GetCompanies" TypeName="ADD_Demo.Classes.Company">
        </asp:ObjectDataSource>
        Sessions Registered<asp:GridView ID="gvClientSessions" runat="server" 
            AutoGenerateColumns="False" DataSourceID="ODSGetSessions">
            <Columns>
                <asp:BoundField DataField="ClientSessionID" HeaderText="ClientSessionID" 
                    SortExpression="ClientSessionID" Visible="False" />
                <asp:BoundField DataField="CourseCode" 
                    HeaderText="Course Code" ReadOnly="True" 
                    SortExpression="CourseCode" />
                <asp:BoundField DataField="SessionDateTime" 
                    HeaderText="Date" ReadOnly="True" 
                    SortExpression="SessionDateTime" />
                <asp:BoundField DataField="SessionLength" HeaderText="Length" 
                    ReadOnly="True" SortExpression="SessionLength" />
                <asp:BoundField DataField="InstructorFullName" HeaderText="Instructor" 
                    ReadOnly="True" SortExpression="InstructorFullName" />
                <asp:BoundField DataField="RoomName" 
                    HeaderText="Room" ReadOnly="True" 
                    SortExpression="RoomName" />
                <asp:BoundField DataField="CourseDescription" HeaderText="Description" 
                    ReadOnly="True" SortExpression="CourseDescription" />
                <asp:BoundField DataField="ClientSessionPrice" HeaderText="Price" 
                    SortExpression="ClientSessionPrice" />
                <asp:CheckBoxField DataField="ClientSessionPaid" HeaderText="Paid" 
                    SortExpression="ClientSessionPaid" />
                <asp:BoundField DataField="StatusName" HeaderText="Status" 
                    SortExpression="StatusName" ReadOnly="True" />
                <asp:HyperLinkField DataNavigateUrlFields="SessionID" 
                    DataNavigateUrlFormatString="Sessions.aspx?SessionID={0}" Text="link" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSGetSessions" runat="server" 
            SelectMethod="GetClientSessionsByClientID" 
            TypeName="ADD_Demo.Classes.ClientSession">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlClientSearch" Name="clientID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        Register For Session<br />
        <asp:DropDownList ID="ddlCourses" runat="server" AutoPostBack="True" 
            DataSourceID="ODSCourses" DataTextField="CourseCode" DataValueField="CourseID" 
            ondatabound="ddlCourses_DataBound" 
            onselectedindexchanged="ddlCourses_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSessionsByCourse" runat="server" AutoPostBack="True" 
            DataSourceID="ODSSessionsByCourse" DataTextField="SessionDateTime" 
            DataValueField="SessionID" Enabled="False" 
            ondatabound="ddlSessionsByCourse_DataBound" 
            onselectedindexchanged="ddlSessionsByCourse_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="cbPaid" runat="server" Enabled="False" Text="Paid" />
        <asp:TextBox ID="tbPrice" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Button ID="btnEnroll" runat="server" Enabled="False" 
            onclick="btnEnroll_Click" Text="Enroll" />
        <br />
        <asp:Label ID="lblStatusText" runat="server"></asp:Label>
        <asp:ObjectDataSource ID="ODSCourses" runat="server" SelectMethod="GetCourses" 
            TypeName="ADD_Demo.Classes.Course"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSGetCourse" runat="server" SelectMethod="GetCourse" 
            TypeName="ADD_Demo.Classes.Course">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCourses" Name="courseID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODSSessionsByCourse" runat="server" 
            SelectMethod="GetSessionsByCourseID" TypeName="ADD_Demo.Classes.Session">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCourses" Name="courseID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    
    </div>
</asp:Content>
