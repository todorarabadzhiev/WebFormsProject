<%@ Page Title="Моите местенца" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCampingPlaces.aspx.cs" Inherits="CampingWebForms.User.MyCampingPlaces" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewMyPlaces" runat="server" ItemType="Services.Models.ICampingPlace"
        SelectMethod="ListViewMyPlaces_GetData" DeleteMethod="ListViewMyPlaces_DeleteItem" 
        DataKeyNames="Id" >
        <LayoutTemplate>
            <table class="table" id="MainContent_ListViewMyPlaces" >
                <tbody>
                    <tr>
                        <th scope="col">
                            <asp:LinkButton Text="Име" runat="server" ID="LinkButtonSortByName" CommandName="Sort" CommandArgument="Name" />
                        </th>
                        <th scope="col">Кратко описание</th>
                        <th scope="col">Положение на картата</th>
                        <th scope="col">Има питейна вода</th>
                        <th scope="col">Действие</th>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    <tr>
                        <td colspan="2">
                            <asp:DataPager runat="server" ID="DataPagerMyPlaces" PageSize="5" >
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><a href='CampingPlaceDetails.aspx?id=<%#: Item.Id %>'><%#: Item.Name %></a></td>
                <td><%#: Item.Description %></td>
                <td><a href='<%#: Item.GoogleMapsUrl %>'><%#: Item.GoogleMapsUrl %></a></td>
                <td><%#: Item.HasWater ? "Да" : "Не" %></td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Изтрий" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <div class="back-link">
        <a href="/">Назад</a>
    </div>
</asp:Content>