<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceholder" runat="server">
    <h1 class="text-center mb-5">Iniciar sesión</h1>
    <asp:Panel runat="server" CssClass="container sombra d-flex flex-column align-self-center mx-auto py-4 w-50">
        <h3 class="text-center mb-4">Completa los campos</h3>
        <div class="mb-3 d-flex row-col-2">
            <asp:Label ID="lblUser" runat="server" CssClass="form-label align-self-center mx-4 col-2">Usuario: </asp:Label>
            <asp:TextBox ID="txtUser" runat="server" class="form-control col me-4" placeholder="Tu usuario"></asp:TextBox>
        </div>
        <div class="mb-3 d-flex row-col-2">
            <asp:Label ID="lblPass" runat="server" CssClass="form-label align-self-center mx-4 col-2">Contraseña: </asp:Label>
            <asp:TextBox ID="txtPass" runat="server" class="form-control col me-4" placeholder="Tu contraseña" TextMode="Password"></asp:TextBox>
        </div>
         <asp:LinkButton ID="ingresarLinkButton" runat="server" CssClass="btn btn-primary px-4 mx-4" OnClick="ingresarLinkButton_Click">INGRESAR</asp:LinkButton>
    </asp:Panel>
</asp:Content>
