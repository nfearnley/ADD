<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="ADD_Demo.Rooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Rooms</p>
    <p>
        <asp:DropDownList ID="ddlRooms" runat="server" AutoPostBack="True" 
            DataSourceID="ODSGetRooms" DataTextField="RoomName" DataValueField="RoomID">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ODSGetRooms" runat="server" SelectMethod="GetRooms" 
            TypeName="ADD_Demo.Classes.Room"></asp:ObjectDataSource>
    </p>
    <p>
        <asp:DetailsView ID="dvRoom" runat="server" AutoGenerateRows="False" 
            DataSourceID="ODSRoomInfo" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="RoomName" HeaderText="Room Name" 
                    SortExpression="RoomName" />
                <asp:BoundField DataField="RoomSeats" HeaderText="Seats Available" 
                    SortExpression="RoomSeats" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </p>
    <p>
        <asp:ObjectDataSource ID="ODSRoomInfo" runat="server" 
            DataObjectTypeName="ADD_Demo.Classes.Room" DeleteMethod="RemoveRoom" 
            InsertMethod="AddRoom" SelectMethod="GetRoom" TypeName="ADD_Demo.Classes.Room" 
            UpdateMethod="UpdateRoom">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlRooms" Name="roomID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="room" Type="Object" />
                <asp:Parameter Name="oldRoom" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>
