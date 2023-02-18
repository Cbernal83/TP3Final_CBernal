<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GrillaProductos.aspx.cs" Inherits="TP3Final_CBernal.GrillaProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container vh-100 ">
        <div class="row ">
            <div classs="col-12">
                <div class="d-flex justify-content-center p-3 ">
                    <h2>LISTA DE PRODUCTOS</h2>
                </div>

            </div>
            <div class="row ">
                <div class="d-flex justify-content-start col-6">

                    <asp:TextBox ID="txb_buscar" CssClass=" col-6 form-control me-2" OnTextChanged="txb_buscar_TextChanged" runat="server" AutoPostBack="True"></asp:TextBox>
                    <button class="btn btn-dark form-control me-2 btn-sm" type="submit">Buscar</button>
                    <asp:Button CssClass="btn btn-outline-dark form-control me-1 btn-sm" ID="btn_busava" runat="server" OnClick="btn_busava_Click" Text="Avanzado" />
                </div>
            </div>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <hr />
                    <% if (txb_buscar.ReadOnly)
                        {%>
                    <div class="row ">
                        <div class="d-flex justify-content-start col-6 ">
                            <asp:DropDownList ID="ddl_categoria" CssClass="form-control me-2" runat="server">
                              
                            </asp:DropDownList>

                            <asp:DropDownList ID="ddl_marca" CssClass="form-control me-2" runat="server">
                                
                            </asp:DropDownList>
                            <asp:TextBox ID="txb_busavazNombre" CssClass="form-control me-2" runat="server"></asp:TextBox>
                            <asp:Button ID="btn_avanzado" CssClass="btn btn-dark btn-sm" OnClick="btn_avanzado_Click" runat="server" Text="Buscar" />
                        </div>
                    </div>
                    <hr />
                    <%}%>
                </ContentTemplate>

            </asp:UpdatePanel>
            <div class="col-12 p-2 d-flex flex-row-reverse align-items-center dropdown show">
                <div>
                    <asp:DropDownList ID="ddl_orden" runat="server" AutoPostBack="true" CssClass="btn btn-dark btn-sm dropdown-toggle" OnTextChanged="DropDownList1_TextChanged">
                        
                        <asp:ListItem Value="2" Text="Ordenar por Precio" />
                        <asp:ListItem Value="1" Text="Mayor Precio" />
                        <asp:ListItem Value="0" Text="Menor Precio" />
                    </asp:DropDownList>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
                    <asp:GridView ID="dgv_Articulos" runat="server" CssClass="table table-sm table-dark "
                        OnSelectedIndexChanged="dgv_Articulos_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="Id"
                        AllowPaging="True" PageSize="6" OnPageIndexChanging="dgv_Articulos_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca" />
                            <asp:BoundField HeaderText="Titulo" DataField="Nombre" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="true" HeaderText="Accion" ControlStyle-CssClass="btn btn-warning "  />

                        </Columns>
                    </asp:GridView>
                       
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row">
            <div class="col-12 d-flex flex-row-reverse align-items-center">
                <div>
                    <asp:Button ID="btn_Agregar" runat="server" OnClick="btn_Agregar_Click" CssClass="btn btn-dark" Text="Agregar" />
                </div>
            </div>

        </div>

    </div>
</asp:Content>
