<%@ Page Title="Местенца от категория" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SiteCategoryPlaces.aspx.cs" Inherits="CampingWebForms.SiteCategoryPlaces" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center">Местенца от категорията "<%= this.CategoryName %>"</h2>
    <asp:ListView ID="ListViewSiteCategoryPlaces" runat="server">
        <LayoutTemplate>
            <div class="container">
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
            </div>
        </LayoutTemplate>

        <ItemTemplate>
            <div class="col-md-3 text-center">
                <asp:Image ImageUrl='<%# ConvertToImage(Eval("ImageFiles[0].Data")) %>'
                    runat="server" Width="200px" /><br />
                <asp:HyperLink runat="server" ID="hlDetails" Text='<%# Eval("Name") %>'
                    NavigateUrl='<%# "User/CampingPlaceDetails.aspx?id=" + Eval("Id") %>' /><br />
                <asp:HyperLink runat="server" NavigateUrl='<%# Eval("GoogleMapsUrl") %>'
                    Target="_blank" Text="Виж на картата">
                </asp:HyperLink>
            </div>
        </ItemTemplate>

    </asp:ListView>
</asp:Content>
