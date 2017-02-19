<%@ Page Title="Добави Ново Място" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCampingPlace.aspx.cs" Inherits="User.CampingWebForms.AddCampingPlace" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h3 class="text-center">Предложете ново място за диво къмпингуване</h3>
        <div class="form-group">
            <asp:Label Text="Име" runat="server" AssociatedControlID="TextBoxName" CssClass="col-md-2 control-label" />
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBoxName"
                    placeholder="название на мястото" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxName"
                    ErrorMessage="Името е задължително" CssClass="text-danger" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Положение на картата" runat="server" AssociatedControlID="TextBoxGoogleMapsUrl" CssClass="col-md-2 control-label" />
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBoxGoogleMapsUrl"
                    placeholder="линк към Google Maps" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Кратко описание на мястото" runat="server" AssociatedControlID="TextBoxDescription" CssClass="col-md-2 control-label" />
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBoxDescription" TextMode="MultiLine" Rows="5"
                    placeholder="въведете кратко описание на мястото" CssClass="form-control" />
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

        <asp:UpdatePanel ID="ImgUploadUpdatePanel" runat="server" CssClass="container form-group">
            <ContentTemplate>
                <div class="row">
                    <asp:FileUpload ID="ImgFileUpload" runat="server" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server"
                        ErrorMessage="Разрешени са само JPG изображения!" ValidationExpression="^.+(.jpg|.JPG)$"
                        ControlToValidate="ImgFileUpload" CssClass="text-danger" /><br />
                    <asp:Button ID="AddImageButton" runat="server" Text="Добави изображение"
                        OnClick="AddImageButton_Click" /><br />
                    <asp:Label ID="LblErrorMessage" runat="server" Visible="false"
                        Text="Добавете поне едно изображение" CssClass="text-danger" />
                </div>
                <h4 id="FilesCount" runat="server" class="text-center"></h4>
                <div class="row">
                    <asp:Repeater ID="UploadedImgFiles" runat="server">
                        <ItemTemplate>
                            <div class="col-md-1">
                                <asp:Image ImageUrl='<%# Eval("Data") %>' runat="server" Width="50px" /><br />
                                <asp:Label Text='<%# Eval("Name") %>' runat="server" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="AddImageButton" />
            </Triggers>
        </asp:UpdatePanel>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="ButtonAddCampingPlace" Text="Добави" OnClick="ButtonAddCampingPlace_Click" />
            </div>
        </div>
    </div>
</asp:Content>
