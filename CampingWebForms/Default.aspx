<%@ Page Title="Начало" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CampingWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center">Биваци</h1>
        <p class="lead">
            Нашето приложение има за цел споделяне на информация за интересни места, подходящи за 
            диво къмпингуване.
        </p>
    </div>

    <div>
        <asp:ListView ID="ListViewLatestPlaces" runat="server">
            <LayoutTemplate>
                <h2 class="text-center">Последни споделени местенца</h2>
                <div class="container">
                    <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
                </div>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="col-md-4 text-center">
                    <asp:Image ImageUrl='<%# ConvertToImage(Eval("ImageFiles[0].Data")) %>'
                        runat="server" Width="200px" /><br />
                    <asp:HyperLink runat="server" ID="hlDetails" Text='<%# Eval("Name") %>'
                        NavigateUrl='<%# "User/CampingPlaceDetails.aspx?id=" + Eval("Id") %>' />
                </div>
            </ItemTemplate>

        </asp:ListView>
    </div>

</asp:Content>
