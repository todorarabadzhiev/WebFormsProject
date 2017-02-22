<%@ Page Title="Място" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CampingPlaceDetails.aspx.cs" Inherits="User.CampingWebForms.CampingPlaceDetails" %>

<%--<%@ Register Src="~/Components/EditCampingPlaceControl.ascx" TagPrefix="my" TagName="EditCampingPlaceControl" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="DetailsView" CssClass="container text-center" >
        <HeaderTemplate>
            <h1 class="text-center"><%# Eval("Name") %></h1>
            <h5 class="text-center">Добавено от <i><%# Eval("AddedBy") %></i> на <%# Eval("AddedOn") %></h5>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:HyperLink runat="server" NavigateUrl='<%# Eval("GoogleMapsUrl") %>'
                Target="_blank" Text="Виж на картата" CssClass="text-center">
            </asp:HyperLink>
            <h3 class="text-center">Кратко описание</h3>
            <p><%# Eval("Description") %></p>
            <asp:CheckBox runat="server" Checked='<%# Eval("HasWater") %>'
                Text="Питейна вода" Enabled="false" />
            <h3>Тип място</h3>
            <asp:BulletedList runat="server" DataSource='<%# Eval("SiteCategoriesNames") %>' CssClass="list-inline">
            </asp:BulletedList>
            <h3>Забележителности</h3>
            <asp:BulletedList runat="server" DataSource='<%# Eval("SightseeingNames") %>' CssClass="list-inline">
            </asp:BulletedList>
            <asp:Repeater runat="server" DataSource='<%# Eval("ImageFiles") %>'>
                <ItemTemplate>
                    <div class="col-md-6">
                        <asp:Image ImageUrl='<%# ConvertToImage(Eval("Data")) %>' runat="server" Width="500px" /><br />
                        <asp:Label Text='<%# Eval("FileName") %>' runat="server" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
        <%--<EditItemTemplate>
            <my:EditCampingPlaceControl ID="MyEditCampingPlaceControl" runat="server" />
        </EditItemTemplate>--%>
    </asp:FormView>

    <%--<asp:MultiView ID="MultiViewButtons" runat="server" ActiveViewIndex="0">
        <asp:View ID="ViewNormalMode" runat="server">
            <asp:LinkButton ID="LinkButtonEdit" runat="server"
                OnClick="LinkButtonEdit_Click" Text="Редактирай" />
        </asp:View>
        <asp:View ID="ViewEditMode" runat="server">
            <asp:LinkButton ID="LinkButtonSave" runat="server"
                OnClick="LinkButtonSave_Click" Text="Запази" />
            <asp:LinkButton ID="LinkButtonCancel" runat="server"
                OnClick="LinkButtonCancel_Click" Text="Откажи" />
        </asp:View>
    </asp:MultiView>--%>

    <div class="back-link">
        <a href="/">Назад</a>
    </div>
</asp:Content>
