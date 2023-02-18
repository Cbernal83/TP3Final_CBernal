<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP3Final_CBernal.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row vh-100 align-items-center justify-content-center ">
            <div class="bg-light col-4 p-4 ">
                <div>
                    <h2 class="text-center">Log in</h2>
                    <div class="form-group">
                        <asp:TextBox ID="txb_username" CssClass="form-control" runat="server" placeholder="Username" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txb_pass" CssClass="form-control" runat="server" placeholder="Password" required="required" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">

                        <asp:Button ID="btn_aceptarLogin" CssClass="btn btn-dark btn-block" OnClick="btn_aceptarLogin_Click" runat="server" Text="Aceptar" />
                    </div>
                    <div class="text-center">
                        <a href="#">Olvidaste tu Password?</a>
                    </div>
                    <div class="text-center">
                        <a href="Registrarse.aspx">Crear una Cuenta.</a>
                    </div>
                    <%if (alertaErrorLogin)
                        {%>
                            <div class="alert alert-warning alert-dismissible fade show " role="alert">
                                <strong>Error!</strong> Email o Contraseña incorrecto.
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>

                      <%  } %>
                     <% if (alerta)
                        {%>
                
                            <div class="alert alert-warning alert-dismissible fade show" role="alert">
                                <asp:Label ID="lbl_Alerta" runat="server" Text="Label"></asp:Label>
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>
                   
                      <% } %>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
