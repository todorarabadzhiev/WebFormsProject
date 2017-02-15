<%@ Page Title="Типове места" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SiteCategories.aspx.cs" Inherits="CampingWebForms.SiteCategories" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="jumbotron text-center">Типове места за диво къмпингуване</h1>

    <div class="row">
        <asp:ListView ID="ListViewSiteCategories" runat="server">
            <LayoutTemplate>
                <table>
                    <tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <td class="col-md-2">
                    <img src="image" alt="снимка тип място" /><br />
                    <asp:HyperLink runat="server" NavigateUrl="~/Contact.aspx" Text='<%# Eval("Name") %>'></asp:HyperLink>
                    <p>Кратка информация за типа място</p>
                </td>
            </ItemTemplate>

        </asp:ListView>
    </div>

</asp:Content>
