<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Form_ABM.aspx.cs" Inherits="TP3Final_CBernal.Vender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container vh-100">
            <%-- SEPERACION NAVBAR --%>
               <div style="height: 100px"> </div>

           <%-- COLUMNA INGRESO DE DATOS --%>
         <div class="row justify-content-md-center">
            <div class="col-md-6 col-xs-9 bg-light" style="border-radius:5%;" >
                <div class="row ">
                    <%--<div class="col-md-3 col-xs-12" style="margin-top:10px;">
        
                        
                    </div>--%>
                    <div class="col-md-3 col-xs-12"style="margin-top:10px;">
                        <asp:Label ID="lbl_cod" runat="server" Text="Cod"></asp:Label>
                        <asp:TextBox ID="txb_cod" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3 col-xs-12"style="margin-top:10px;">
                        <asp:Label ID="lbl_categoria" runat="server" Text="Categoria"></asp:Label>
                        <div>
                            <asp:DropDownList ID="ddl_categoria" CssClass="custom-select mr-sm-2" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3 col-xs-12"style="margin-top:10px;">
                        <asp:Label ID="lbl_marca" runat="server" Text="Marca"></asp:Label>
                        <div>
                            <asp:DropDownList ID="ddl_marca" CssClass="custom-select mr-sm-2" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-12 col-xs-12"  style="margin-top:20px";>
                        <asp:Label ID="lbl_nombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="txb_nombre" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-xs-12"style="margin-top:20px";>
                        <asp:Label ID="lbl_precio" runat="server" Text="Precio"></asp:Label>
                        <asp:TextBox ID="txb_precio" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- TEXBOX SUBIR IMG --%>

                    <div class="col-md-12 col-xs-12"style="margin-top:20px";>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                                <asp:Label ID="lbl_img" runat="server" Text="Subir Imagen URL"></asp:Label>
                            
                                 <asp:TextBox ID="txb_urlimg" CssClass=" form-control " runat="server" 
                                  AutoPostback="true" OnTextChanged="txb_urlimg_TextChanged" ></asp:TextBox>
                                  
                        </ContentTemplate>
                    </asp:UpdatePanel>
                            </div>


                    <div class="col-md-12 col-xs-12"style="margin:20px 0px 50px 0px";>
                        <asp:Label ID="lbl_descripcion" runat="server" Text="Descripcion"></asp:Label>
                        <asp:TextBox ID="txb_descripcion" CssClass="form-control" runat="server" TextMode="MultiLine" MaxLength="150"></asp:TextBox>
                    </div>
                </div>
                    <%-- BOTONES ACEPTAR CANCELAR --%>
                <div class="row  " >
                    <div class="col-12">
                        <div class="form-group">
                            <div class="d-grid gap-2 col-8 mx-auto" >
                              
                                <asp:Button ID="btn_aceptarVenta" CssClass="btn btn-dark btn-lg" OnClick="btn_aceptarVenta_Click" runat="server" Text="Aceptar" />
                                <asp:Button ID="btn_cancelar" CssClass="btn btn-outline-primary"  OnClick="btn_cancelar_Click" runat="server" Text="Cancelar" />
                          
                            </div>
                        </div>
                    </div>
                    </div>

                 <% if (alerta)
                        {%>
                
                            <div class="alert alert-warning alert-dismissible fade show" role="alert">
                                <asp:Label ID="lbl_Alerta" runat="server" Text="Label"></asp:Label>
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>
                   
                      <% } %>
                
                 <%-- CHECK ELIMINAR --%>

                     <div class="d-grid gap-2 col-5 mx-auto alert alert-warning form-check form-check-reverse">
                          <asp:CheckBox ID="chk_habilitarEliminacion" CssClass="form-check-label" Text="&nbsp;Habilitar Eliminacion" runat="server" AutoPostBack="true" />
                     </div>
                 
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>  
                
                 <!-- BOTON ELIMINAR -->
            <% if (chk_habilitarEliminacion.Checked)
                {%>

            
                        <div class="row  " >
                            <div class="col-12">
                                <div class="form-group">
                                    <div class="d-grid gap-2 col-4 mx-auto" >
                                        <asp:Button ID="btn_eliminar" CssClass="btn btn-danger " OnClick="btn_eliminar_Click"  runat="server" Text="Eliminar" />
                                    </div>
                                </div>
                            </div>
                         </div>
                
           <%  } %>       
                        </ContentTemplate>
                 </asp:UpdatePanel>
            </div> <!--FIN COLUMNA IZQUIERDA-->
        
            <%-- COLUMNA IMAGEN --%>
                    
            <div class="col-md-4 col-xs-9 ">
               <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="row "> 
                             <asp:Image ID="Img_ImagenABM" CssClass="img-fluid object-fit-scale " runat="server" />                                                               
                        </div>
                    </ContentTemplate>
                 </asp:UpdatePanel>
              </div>
           </div>
     </div>


</asp:Content>
                
