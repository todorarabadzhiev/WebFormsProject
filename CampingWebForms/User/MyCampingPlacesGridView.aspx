<%@ Page Title="Моите местенца" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCampingPlacesGridView.aspx.cs" Inherits="CampingWebForms.User.MyCampingPlaces" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="ListViewMyPlaces" runat="server" ItemType="Services.Models.ICampingPlace"
        SelectMethod="ListViewMyPlaces_GetData" DeleteMethod="ListViewMyPlaces_DeleteItem"
        AllowSorting="true" AllowPaging="true" PageSize="5" DataKeyNames="Id" >
        
    </asp:GridView>
    <div class="back-link">
        <a href="/">Назад</a>
    </div>
</asp:Content>