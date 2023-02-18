<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TP3Final_CBernal.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="py-5">

        <div class="container  px-4 px-lg-5 mt-5 mb-5 ">

            <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center">

                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>

                        <div class="col mb-5">
                            <div class="card h-100">
                                <!-- btn quitar-->
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                <div class="position-relative position-relative-example">
                                    <div class="position-absolute end-0">

                                        <asp:Button ID="btn_Remove" OnClick="btn_Remove_Click" runat="server" Text="Quitar" 
                                            CssClass="btn btn-outline-warning position-relative border-0  text-dark font-italic tex"
                                            Height="30" Width="60" Font-Size="12px" CommandArgument='<% #Eval("Id") %>' CommandName='' />

                                    </div>
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                                    <!-- Sale badge-->
                                    <div class="row">
                                        <div class="col-9"></div>
                                   
                                            <%-- boton favorito --%>
                                        </div>

                                    </div>

                                    <!-- Product image-->

                                    <img class="mx-auto object-fit-contain " src='<%#Eval("ImagenUrl") %>' style="width: 220px; height: 220px">

                                    <!-- Product details-->
                                    <div class="card-body p-4">
                                        <div class="text-center">
                                            <!-- NOMBRE PRODUCTO-->
                                            <h5 class="fw-bolder"><%#Eval("Nombre") %></h5>
                                            <!-- Product reviews-->
                                            <div class="d-flex justify-content-center small text-warning mb-2">
                                                <div class="bi-star-fill"></div>
                                                <div class="bi-star-fill"></div>
                                                <div class="bi-star-fill"></div>
                                                <div class="bi-star-fill"></div>
                                                <div class="bi-star-fill"></div>
                                            </div>
                                            <!-- PRECIO-->

                                        </div>
                                    </div>
                                    <div class="bg-white" style="text-align: center; font-size: 20px; margin-bottom: 5px">
                                        <span class=""><%#Eval("Precio") %></span>

                                    </div>
                                    <!-- AGREGAR CARRITO y DETALLES-->
                                    <div class="col mb-4 ">
                                        <asp:Button ID="btn_agregarCarrito" CssClass="btn btn-primary  btn-sm btn-block" runat="server" Text="Agregar al Carrito" />

                                        <asp:Button ID="btn_detalles" CssClass="btn btn-secondary btn-sm btn-block"
                                            CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloID"
                                            OnClick="btn_detalles_Click" runat="server" Text="Ver Detalles" />

                                    </div>
                                </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>


            </div>

        </div>
    </section>
</asp:Content>
