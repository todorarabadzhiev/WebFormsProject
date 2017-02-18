<%@ Page Title="Добави Ново Място" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCampingPlace.aspx.cs" Inherits="CampingWebForms.AddCampingPlace" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Предложете ново място за диво къмпингуване</h1>
    <asp:Label Text="Име" runat="server" AssociatedControlID="TextBoxName" />
    <asp:RequiredFieldValidator runat="server"
        ControlToValidate="TextBoxName"
        ErrorMessage="Името е задължително" CssClass="alert alert-danger">
    </asp:RequiredFieldValidator>
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
    <asp:CheckBox runat="server" ID="CheckBoxHasWater" Text="Има питейна вода"></asp:CheckBox><br />
    <asp:Label Text="Подходящи категории за мястото" runat="server" /><br />
    <asp:CheckBoxList runat="server" ID="CheckBoxListCategories" DataTextField="Name">
    </asp:CheckBoxList><br />
    <asp:Label Text="Забележителности около мястото" runat="server" /><br />
    <asp:CheckBoxList runat="server" ID="CheckBoxListSightseeing" DataTextField="Name">
    </asp:CheckBoxList><br />

    <asp:Panel runat="server">
        <asp:UpdatePanel ID="ImgUploadUpdatePanel" runat="server">
            <ContentTemplate>
                <asp:FileUpload ID="ImgFileUpload" runat="server" />
                <asp:Button ID="AddImageButton" runat="server" Text="Добави изображение" OnClick="AddImageButton_Click" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server"
                    ErrorMessage="Разрешени са само JPG изображения!"
                    ValidationExpression="^.+(.jpg|.JPG)$"
                    ControlToValidate="ImgFileUpload" CssClass="alert alert-danger">
                </asp:RegularExpressionValidator>
                <h4 id="FilesCount" runat="server"></h4>
                <asp:Label ID="LblErrorMessage" runat="server" 
                    Text="Добавете поне едно изображение" Visible="false" CssClass="alert alert-danger" />
                <asp:Repeater ID="UploadedImgFiles" runat="server">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                        <asp:Image ImageUrl='<%# Eval("Data") %>' runat="server" Width="50px" />
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <hr />
                    </SeparatorTemplate>
                </asp:Repeater>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="AddImageButton" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>


    <asp:Button runat="server" ID="ButtonAddCampingPlace" Text="Добави" OnClick="ButtonAddCampingPlace_Click" />
</asp:Content>
