<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TP3Final_CBernal.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="vh-100" style="background-color: #f4f5f7;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col col-lg-6 mb-4 mb-lg-0">
                        <%-- SUBIR IMAGEN --%>
                   
                    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
                        <asp:Label ID="lbl_FULeyenda" runat="server" Visible="False" BorderStyle="None" Font-Bold="True"></asp:Label>
                    </div>
                        <div class="d-md-flex d-flex align-items-center input-group input-group-sm mb-1">
                             <asp:TextBox ID="txb_FU" runat="server" ReadOnly="True" CssClass="form-control align-text-bottom" Visible="False"></asp:TextBox>
                            <div class="d-grid gap-2 d-md-flex justify-content-md-end ">
                                <asp:LinkButton ID="LBN_FU" runat="server"  ><img src="./Images/Ico/upload-file.png"/></asp:LinkButton>

                            </div>
                        </div>

                        <asp:FileUpload ID="FU_subirImg" runat="server" style="display:none;"  onchange="fileinfo()"/>

                        <script type="text/javascript">
                            function fileinfo() {
                                document.getElementById('<%=txb_FU.ClientID%>').value = document.getElementById('<%=FU_subirImg.ClientID%>').value;
                            }
                        </script>

                    <div class="card mb-3" style="border-radius: .5rem;">
                        <div class="row g-0">
                            <div class="col-md-4 bg-dark text-center " style="border-top-left-radius: .5rem; border-bottom-left-radius: .5rem;">
                                <%-- IMAGEN AVATAR --%>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Image ID="Img_Perfil" runat="server" CssClass="img-fluid my-5 rounded-circle" Width="75px" Height="75px"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <%-- NOMBRE --%>
                                <hr class="mt-0 mb-4 " style="background-color: white">
                                <h5><asp:Label ID="lbl_nombre1" runat="server" ForeColor="White" Text="Editar Nombre"></asp:Label></h5>
                                <h5><asp:TextBox ID="txb_nombre" runat="server" CssClass="bg-light" ForeColor="Black" width="150px" Text="" BorderStyle="None" MaxLength="15" AutoPostBack="False"></asp:TextBox></h5>
                                <%-- CONTROL VALIDACION --%>
                                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="txb_nombre" runat="server" />

                                 <%-- APELLIDO --%>
                                <h5><asp:Label ID="lbl_apellido" runat="server" ForeColor="White" Text="Editar Apellido"></asp:Label></h5>
                                <h5><asp:TextBox ID="txb_apellido" runat="server" CssClass="bg-light" ForeColor="Black" width="150px" Text="" BorderStyle="None" MaxLength="15" AutoPostBack="False"></asp:TextBox></h5>
                                <%-- CONTROL VALIDACION --%>
                                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="txb_apellido" runat="server" />
                                
                                <%-- ALERTAS --%>
                                <div>
                                    <asp:Label ID="Alert_Nombre" runat="server" Text="Completar Nombre." Visible="False" ForeColor="Red" Font-Size="10px"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="Alert_Apellido" runat="server" Text="Completar Apellido." Visible="False" ForeColor="Red" Font-Size="10px"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="card-body p-4">
                                    <h6>Informacion</h6>
                                    <hr class="mt-0 mb-4">
                                    <div class="row pt-1">
                                        <div class="col-12 mb-3">
                                             <%-- MAIL --%>
                                            <h6>Email</h6>
                                            <asp:Label ID="lbl_mail" CssClass="text-muted" runat="server" Text="info@example.com"></asp:Label>
                                            <asp:TextBox ID="txb_mail" runat="server" AutoPostBack="False" Visible="False" TextMode="Email" MaxLength="30"></asp:TextBox>
                                            
                                            <div>
                                                <asp:Label ID="lbl_mailexiste" runat="server" Text="El Mail ya existe, elegir otro." Visible="False" ForeColor="Red" Font-Size="10px"></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                    <h6>Cambiar Password</h6>
                                    <hr class="mt-0 mb-4">
                                    <div class="row pt-1">
                                        <div class="col-6 mb-3">
                                            <h6>Clave Actual</h6>
                                            <asp:TextBox ID="txb_Pass" CssClass="text-muted" TextMode="Password" PlaceHolder="****" runat="server" ReadOnly="True" BorderStyle="None"></asp:TextBox>
                                        </div>
                                        <%-- Alerta Mail --%>
                                        <div>
                                            <asp:Label ID="lbl_PassNoCoincide" runat="server" Text="La Clave Actual no coincide." Visible="False" ForeColor="Red" Font-Size="10px"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row pt-1">
                                        <div class="col-6 mb-3">
                                            <h6>Clave Nueva</h6>
                                            <asp:TextBox ID="txb_PassUpdate" CssClass="text-muted" TextMode="Password" PlaceHolder="****" runat="server" ReadOnly="True" BorderStyle="None"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- BOTONES ACEPTAR EDITAR AGREGAR IMG --%>
                    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                        <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-secondary" OnClick="btn_cancelar_Click" Visible="False" />
                        <asp:Button ID="btn_editar" runat="server" Text="Editar" CssClass="btn btn-outline-dark" OnClick="btn_editar_Click" />
                        <asp:Button ID="btn_aceptar" runat="server" Text="Aceptar" CssClass="btn btn-dark" OnClick="btn_aceptar_Click" />
                    </div>
                     <% if (alerta)
                        {%>
                
                            <div class="alert alert-warning alert-dismissible fade show" role="alert">
                                <asp:Label ID="lbl_Alerta" runat="server" Text="Label"></asp:Label>
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>
                   
                      <% } %>

                    <%-- CHECK ELIMINAR CUENTA --%>
                    <hr class="mt-0 mb-4">
                    <div class="d-grid gap-2 col-7 mx-auto alert alert-warning text-center ">
                        <asp:CheckBox ID="chk_habilitarEliminacion" CssClass="form-check-label" Text="&nbsp;Habilitar Eliminacion de Cuenta" runat="server" AutoPostBack="true" />
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>

                            <!-- BOTON ELIMINAR -->
                            <% if (chk_habilitarEliminacion.Checked)
                                {%>


                            <div class="row  ">
                                <div class="col-12">
                                    <div class="form-group">
                                        <div class="d-grid gap-2 col-6 mx-auto">
                                            <asp:Button ID="btn_eliminarCuenta" CssClass="btn btn-danger" OnClick="btn_eliminarCuenta_Click" runat="server" Text="Eliminar Cuenta" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%  } %>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
