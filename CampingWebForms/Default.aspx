<%@ Page Title="Начало" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CampingWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center">Диваци Айляци</h1>
        <p class="lead">
            Нашето приложение има за цел споделяне на информация за интересни места, подходящи за 
            диво къмпингуване.
        </p>
    </div>

    <div class="row">
        <asp:ListView ID="ListViewLatestPlaces" runat="server">
            <LayoutTemplate>
                <h2 class="text-center">Последни споделени местенца</h2>
                <table>
                    <tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <td class="col-md-2">
                    <img src="image" alt="снимка от Мястото" /><br />
                    <asp:HyperLink runat="server" ID="hlDetails"
                        NavigateUrl='<%# "CampingPlaceDetails.aspx?id=" + Eval("Id") %>' Text='<%# Eval("Name") %>'>
                    </asp:HyperLink>
                    <p>Кратка информация за Мястото</p>
                </td>
            </ItemTemplate>

        </asp:ListView>
    </div>

</asp:Content>
