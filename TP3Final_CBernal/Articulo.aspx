<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="TP3Final_CBernal.Articulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 50px"></div>
   
    <div class="container vh-100  p-5">
        <div class="row align-items-start">
            <%--Columna derecha--%>
            <div class="col">
                <asp:Image ID="Img_imagen" CssClass="img-fluid object-fit-scale " runat="server" />
            </div>
            <%--Columna izquierda--%>
            <div class="col border" >
                <div class="row ">
                    <div class="col-10 mx-auto p-5 text-center">
                        <asp:Label ID="lbl_TITULO" runat="server" Font-Size="30px" Font-Bold="true"></asp:Label>
                    </div>
                   
                    <div class="col-10 mx-auto p-5">
                        <h5>Precio:</h5>
                        <asp:Label ID="lbl_precio" runat="server" Text="PRECIO" Font-Bold="False" Font-Size="25px"></asp:Label>
                    </div>
                    <div class="col-10 mx-auto p-5">
                        <asp:Button ID="btn_detalles" CssClass="btn btn-primary btn-sm btn-block " runat="server" Text="COMPRAR" />
                        <asp:Button ID="btn_addFavoritos" OnClick="btn_addFavoritos_Click" CssClass="btn btn-secondary btn-sm btn-block" runat="server" Text="AÑADIR FAVORITOS" />
                    </div>
                </div>
            </div>

        </div>
         <%--DESCRIPCION--%>
        <div class="row">
            <div class="col-12 ">
                <h3>Características Principales</h3>
                <div class="col-12 ">

                    <asp:Label ID="lbl_descripcion" runat="server" Font-Size="20px" Font-Names="calibri"></asp:Label>
                  
                </div>
            </div>
        </div>
    </div>

</asp:Content>
