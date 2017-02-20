<%@ Page Title="Редактиране на потребителите" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUsers.aspx.cs" Inherits="CampingWebForms.Admin.EditUsers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center">Редактиране на потребителите</h1>
    </div>

    <div>
        <asp:GridView ID="EditUsersContol" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" DataKeyNames="ID"
            onpageindexchanging="EditUsersContol_PageIndexChanging">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="UserName" HeaderText="User Name" />
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="EditCustomer.aspx?id={0}" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
