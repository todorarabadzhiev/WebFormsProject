<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCampingPlaceControl.ascx.cs" Inherits="CampingWebForms.Components.EditCampingPlaceControl" %>

<%@ Register Src="~/Components/CampingPlaceImagesControl.ascx" TagPrefix="my" TagName="AddImageControl" %>

<div class="form-horizontal">
    <div class="form-group">
        <asp:Label Text="Име" runat="server" AssociatedControlID="TextBoxName" CssClass="col-md-2 control-label" />
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="TextBoxName"
                Text="название на мястото" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxName"
                ErrorMessage="Името е задължително" CssClass="text-danger" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label Text="Положение на картата" runat="server" AssociatedControlID="TextBoxGoogleMapsUrl" CssClass="col-md-2 control-label" />
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="TextBoxGoogleMapsUrl"
                Text="Google Maps" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label Text="Кратко описание на мястото" runat="server" AssociatedControlID="TextBoxDescription" CssClass="col-md-2 control-label" />
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="TextBoxDescription" TextMode="MultiLine" Rows="5"
                Text="въведете кратко описание на мястото" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group container">
        <div class="row">
            <asp:Panel runat="server" CssClass="col-md-4" GroupingText="Подходящи категории">
                <asp:CheckBoxList runat="server" ID="CheckBoxListCategories" DataTextField="Name">
                </asp:CheckBoxList>
            </asp:Panel>
            <asp:Panel runat="server" CssClass="col-md-4" GroupingText="Забележителности">
                <asp:CheckBoxList runat="server" ID="CheckBoxListSightseeing" DataTextField="Name">
                </asp:CheckBoxList>
            </asp:Panel>
            <asp:Panel runat="server" CssClass="col-md-4" GroupingText="Условия">
                <asp:CheckBox runat="server" ID="CheckBoxHasWater" Text="Има питейна вода" />
            </asp:Panel>
        </div>
    </div>

    <my:AddImageControl ID="MyAddImageControl" runat="server" />

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button runat="server" ID="ButtonAddCampingPlace" Text="Добави" OnClick="ButtonAddCampingPlace_Click" />
        </div>
    </div>
</div>