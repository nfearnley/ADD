<%@ Page Title="Clients" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="ADD_Demo.Clients" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    
        <asp:Label ID="lblClientSearch" runat="server" Text="Search for a Client"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlClientSearch" runat="server" AutoPostBack="True" 
            DataSourceID="ODSGetClients" DataTextField="LastName" 
            DataValueField="ClientID" 
            onselectedindexchanged="ddlClientSearch_SelectedIndexChanged" 
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
                <asp:BoundField DataField="FirstName" HeaderText="First Name" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" 
                    SortExpression="LastName" />
                <asp:BoundField DataField="HomePhone" HeaderText="Home Phone" 
                    SortExpression="HomePhone" />
                <asp:BoundField DataField="WorkPhone" HeaderText="Work Phone" 
                    SortExpression="WorkPhone" />
                <asp:BoundField DataField="FaxPhone" HeaderText="Fax Phone" 
                    SortExpression="FaxPhone" />
                <asp:BoundField DataField="AddressCity" HeaderText="City" 
                    SortExpression="AddressCity" />
                <asp:BoundField DataField="AddressCountry" HeaderText="Country" 
                    SortExpression="AddressCountry" />
                <asp:BoundField DataField="AddressRegion" HeaderText="Region" 
                    SortExpression="AddressRegion" />
                <asp:BoundField DataField="AddressLine1" HeaderText="Address Line  1" 
                    SortExpression="AddressLine1" />
                <asp:BoundField DataField="AddressLine2" HeaderText="Address Line 2" 
                    SortExpression="AddressLine2" />
                <asp:BoundField DataField="AddressPostalCode" HeaderText="Postal Code" 
                    SortExpression="AddressPostalCode" />
                <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyID" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="ODSGetCompanies" DataTextField="BillingName" 
                            DataValueField="CompanyID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="ODSGetCompanies" DataTextField="BillingName" 
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
            Width="250px" AutoGenerateRows="False">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="CompanyID" 
                    HeaderText="CompanyID" />
                <asp:BoundField DataField="BillingName" HeaderText="Company Name" />
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
        Sessions Registered<asp:GridView ID="gvClientSessions" runat="server">
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
            DataSourceID="ODSSessionsByCourse" DataTextField="Date" 
            DataValueField="SessionID" Enabled="False" 
            ondatabound="ddlSessionsByCourse_DataBound" 
            onselectedindexchanged="ddlSessionsByCourse_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="cbPaid" runat="server" Enabled="False" Text="Paid" />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbPrice" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Button ID="btnEnroll" runat="server" Enabled="False" 
            onclick="btnEnroll_Click" Text="Enroll" />
        <br />
        <asp:Label ID="lblStatusText" runat="server"></asp:Label>
        <asp:ObjectDataSource ID="ODSCourses" runat="server" SelectMethod="GetCourses" 
            TypeName="ADD_Demo.Classes.Course"></asp:ObjectDataSource>
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
