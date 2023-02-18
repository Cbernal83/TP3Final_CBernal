<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TP3Final_CBernal.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row vh-100 align-items-center justify-content-center ">
            <div class="bg-light col-4 p-4 ">
                <div>
                    <h2 class="text-center">Registrarse</h2>
                    <div class="form-group">
                        <asp:TextBox ID="txb_nombre" CssClass="form-control" runat="server" placeholder="Nombre" required="required" MaxLength="50" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txb_apellido" CssClass="form-control" runat="server" placeholder="Apellido" required="required" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txb_mail" CssClass="form-control" runat="server" placeholder="Email" required="required"></asp:TextBox>                      
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txb_pass" CssClass="form-control" runat="server" placeholder="Password" ToolTip="4 a 8 caracteres,min,may,num" required="required" TextMode="Password"></asp:TextBox>                   
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txb_passConf" CssClass="form-control" runat="server" placeholder="Repetir Password" required="required" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group p-5">
                        <asp:Button ID="btn_aceptarReg" CssClass="btn btn-dark btn-block" OnClick="btn_aceptarReg_Click" runat="server" Text="Aceptar" />
                
                    </div>
                    <% if (alerta)
                        {%>
                
                            <div class="alert alert-warning alert-dismissible fade show" role="alert">
                                <asp:Label ID="lbl_Alerta" runat="server" Text="Label"></asp:Label>
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>
                   
                      <% } %>
                </div>
                    <%--VALIDACIONES--%>
                
            </div>
        </div>
     
          
    </div>
</asp:Content>
