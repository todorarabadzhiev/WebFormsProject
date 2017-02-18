<%@ Page Title="Място" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CampingPlaceDetails.aspx.cs" Inherits="CampingWebForms.CampingPlaceDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="DetailsView" CssClass="text-center">
        <HeaderTemplate>
            <h1><%# Eval("Name") %></h1>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:HyperLink runat="server"
                NavigateUrl='<%# Eval("GoogleMapsUrl") %>'
                Target="_blank"
                Text="See on Google maps">
            </asp:HyperLink>
            <h3>Кратко описание</h3>
            <p><%# Eval("Description") %></p>
            <asp:CheckBox runat="server" 
                Checked='<%# Eval("HasWater") %>' 
                Text="Питейна вода"
                Enabled="false" />
            <h3>Тип място</h3>
            <asp:BulletedList runat="server" DataSource='<%# Eval("SiteCategoriesNames") %>'>
            </asp:BulletedList>
            <h3>Забележителности</h3>
            <asp:BulletedList runat="server" DataSource='<%# Eval("SightseeingNames") %>'>
            </asp:BulletedList>
            <asp:Repeater runat="server" DataSource='<%# Eval("ImageFiles") %>'>
                <ItemTemplate>
                    <%# Eval("FileName") %>
                    <asp:Image ImageUrl='<%# ConvertToImage(Eval("Data")) %>' runat="server" Width="50px" />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
