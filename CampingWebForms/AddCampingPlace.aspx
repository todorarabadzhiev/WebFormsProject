<%@ Page Title="Добави Ново Място" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCampingPlace.aspx.cs" Inherits="CampingWebForms.AddCampingPlace" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Предложете ново място за диво къмпингуване</h1>
    <asp:Label Text="Име" runat="server" AssociatedControlID="TextBoxName" />
    <asp:TextBox runat="server" ID="TextBoxName" placeholder="название на мястото"></asp:TextBox><br />
    <asp:Label Text="Положение на картата" runat="server" AssociatedControlID="TextBoxGoogleMapsUrl" />
    <asp:TextBox runat="server" ID="TextBoxGoogleMapsUrl" placeholder="линк към Google Maps"></asp:TextBox><br />
    <asp:Label Text="Кратко описание" runat="server" AssociatedControlID="TextBoxDescription" /><br />
    <asp:TextBox runat="server" ID="TextBoxDescription" 
        TextMode="MultiLine"
        Columns="50"
        Rows="5"
        placeholder="въведете кратко описание на мястото">
    </asp:TextBox><br />
    <asp:CheckBox runat="server" ID="CheckBoxHasWater" Text="Има питейна вода" ></asp:CheckBox><br />
    <asp:Label Text="Изберете подходящите категории за мястото" runat="server" /><br />
    <asp:CheckBoxList runat="server" ID="CheckBoxListCategories" DataTextField="Name">
    </asp:CheckBoxList><br />
    <asp:Label Text="Какви забележителности има около мястото" runat="server" /><br />
    <asp:CheckBoxList runat="server" ID="CheckBoxListSightseeing" DataTextField="Name">
    </asp:CheckBoxList><br />
    <asp:Button runat="server" ID="ButtonAddCampingPlace" Text="Добави" OnClick="ButtonAddCampingPlace_Click" />
</asp:Content>
