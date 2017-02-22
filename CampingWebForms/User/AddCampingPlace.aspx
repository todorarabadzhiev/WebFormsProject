<%@ Page Title="Добави Ново Място" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCampingPlace.aspx.cs" Inherits="User.CampingWebForms.AddCampingPlace" %>

<%@ Register Src="~/Components/AddCampingPlaceControl.ascx" TagPrefix="my" TagName="AddCampingPlaceControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center">Предложете ново място за диво къмпингуване</h3>
    
    <my:AddCampingPlaceControl ID="MyAddCampingPlaceControl" runat="server" />

</asp:Content>
