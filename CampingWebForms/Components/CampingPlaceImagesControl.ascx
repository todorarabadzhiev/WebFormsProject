<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CampingPlaceImagesControl.ascx.cs" Inherits="CampingWebForms.Components.CampingPlaceImagesControl" %>

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
            <asp:Repeater ID="UploadedImgFiles" runat="server" OnItemCommand="UploadedImgFiles_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-1">
                        <asp:Image ImageUrl='<%# Eval("Data") %>' runat="server" Width="50px" /><br />
                        <asp:Label Text='<%# Eval("Name") %>' runat="server" />
                        <asp:LinkButton Text="Изтрий" runat="server" ID="DeleteImage" CommandName="Delete" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="AddImageButton" />
    </Triggers>
</asp:UpdatePanel>
