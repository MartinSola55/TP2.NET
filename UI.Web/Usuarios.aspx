<%@ Page Title="Usuarios" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content" ContentPlaceHolderID="bodyContentPlaceholder" runat="server">
    <asp:Panel ID="gridPanel" CssClass="container-fluid" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped table-bordered table-oscura text-white" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowDataBound="gridView_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Nombre" ItemStyle-VerticalAlign="Middle" DataField="Nombre">
                    <HeaderStyle CssClass="text-center header-tabla" HorizontalAlign="Center" />
                    <ItemStyle VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Apellido" ItemStyle-VerticalAlign="Middle" DataField="Apellido">
                    <HeaderStyle CssClass="text-center header-tabla" HorizontalAlign="Center" />
                    <ItemStyle VerticalAlign="Middle"/>
                </asp:BoundField>
                <asp:BoundField HeaderText="Email" ItemStyle-VerticalAlign="Middle" DataField="Email">
                    <HeaderStyle CssClass="text-center header-tabla" HorizontalAlign="Center" />
                    <ItemStyle VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Usuario" ItemStyle-VerticalAlign="Middle" DataField="NombreUsuario">
                    <HeaderStyle CssClass="text-center header-tabla" HorizontalAlign="Center" />
                    <ItemStyle VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Habilitado" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" DataField="Habilitado" NullDisplayText="-">
                    <HeaderStyle CssClass="text-center header-tabla" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                </asp:BoundField>
                <asp:CommandField HeaderText="Editar - Eliminar" ControlStyle-CssClass="btn btn-outline-light rounded " ButtonType="Button" ShowSelectButton="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ControlStyle CssClass="btn btn-outline-light" />
                    <HeaderStyle CssClass="text-center header-tabla" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
            </Columns>
            <SelectedRowStyle Font-Bold="True"/>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server" CssClass="mx-3">
        <asp:LinkButton ID="editarLinkButton" runat="server" CssClass="btn btn-primary btn-m px-5 mb-3" OnClick="editarLinkButton_Click" Visible="False">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" CssClass="btn btn-danger btn-m px-5 mb-3" OnClick="eliminarLinkButton_Click" Visible="False">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" CssClass="btn btn-success btn-m px-5 mb-3" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <div class="container-fluid">
        <asp:Panel ID="formPanel" Visible="false" runat="server" CssClass="sombra">
            <div class="container m-0">
                <div class="row">
                    <asp:Label ID="nombreLabel" CssClass="col-1 my-auto" runat="server" Text="Nombre: "></asp:Label>
                    <asp:TextBox ID="nombreTextBox" runat="server" CssClass="form-control w-25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="nombreRequired" runat="server" CssClass="col-1 align-self-center" ErrorMessage="Debes ingresar un nombre" Text="*" ForeColor="Red" ControlToValidate="nombreTextBox" ValidationGroup="errores" Font-Size="Large"></asp:RequiredFieldValidator>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="apellidoLabel" CssClass="col-1 my-auto" runat="server" Text="Apellido: "></asp:Label>
                    <asp:TextBox ID="apellidoTextBox" runat="server" CssClass="form-control w-25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="apellidoValidator" runat="server" CssClass="col-1 align-self-center" ErrorMessage="Debes ingresar un apellido" Text="*" ForeColor="Red" ControlToValidate="apellidoTextBox" ValidationGroup="errores" Font-Size="Large"></asp:RequiredFieldValidator>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="emailLabel" runat="server" CssClass="col-1 my-auto" Text="Email: "></asp:Label>
                    <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control w-25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="emailValidator" runat="server" CssClass="col-1 align-self-center" ErrorMessage="Debes ingresar un email" Text="*" ForeColor="Red" ControlToValidate="emailTextBox" ValidationGroup="errores" Font-Size="Large"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="emailFormatValidator" runat="server" ErrorMessage="Debes ingresar un email válido" Text="*" ForeColor="Red" ControlToValidate="emailTextBox" ValidationGroup="errores" Font-Size="Large" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="habilitadoLabel" runat="server" CssClass="col-1 my-auto" Text="Habilitado: "></asp:Label>
                    <asp:CheckBox ID="habilitadoCheckBox" runat="server" CssClass="w-25 check-large"/>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="nombreUsuarioLabel" runat="server" CssClass="col-1 my-auto" Text="Usuario: "></asp:Label>
                    <asp:TextBox ID="nombreUsuarioTextBox" runat="server" CssClass="form-control w-25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="usuarioValidator" runat="server" ControlToValidate="nombreUsuarioTextBox" CssClass="col-1 align-self-center" ErrorMessage="Debes ingresar un usuario" Font-Size="Large" ForeColor="Red" Text="*" ValidationGroup="errores"></asp:RequiredFieldValidator>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="claveLabel" runat="server" CssClass="col-1 mt-auto mb-auto" Text="Clave: "></asp:Label>
                    <asp:TextBox ID="claveTextBox" TextMode="Password" CssClass="form-control col-2 w-25" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="claveValidator" runat="server" ControlToValidate="claveTextBox" CssClass="col-1 align-self-center" ErrorMessage="Debes ingresar una clave" Font-Size="Large" ForeColor="Red" Text="*" ValidationGroup="errores"></asp:RequiredFieldValidator>
                    <asp:Label ID="repetirClaveLabel" runat="server" CssClass="col-2 my-auto ms-3 text-end" Text="Repetir clave: "></asp:Label>
                    <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" CssClass="form-control col-2 w-25" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="clavesCompareValidator" runat="server" ErrorMessage="Las claves no coinciden" CssClass="col-1 align-self-center" Font-Size="Large" ForeColor="Red" Text="*" ValidationGroup="errores" ControlToCompare="repetirClaveTextBox" ControlToValidate="claveTextBox"></asp:CompareValidator>
                </div>
                <br />
                <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" ValidationGroup="errores" />
                <br />
            </div>
        </asp:Panel>
        <asp:Panel ID="formActionsPanel" runat="server" CssClass="mx-3 mb-5" Visible="false">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" ValidationGroup="errores" CssClass="btn btn-success btn-m px-5 me-3" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" CssClass="btn btn-danger btn-m px-5" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </div>
</asp:Content>
