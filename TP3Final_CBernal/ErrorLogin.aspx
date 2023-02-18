<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ErrorLogin.aspx.cs" Inherits="TP3Final_CBernal.ErrorLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container vh-100">

        <div class="alert alert-dark top-50 " role="alert">
            <h4 class="alert-heading">Hubo un Error de Acceso</h4>
            <hr>
            <div class="mb-0"><asp:Label ID="lbl_ErrorAcceso" runat="server"> </asp:Label></div>
        </div>

      


    </div>
</asp:Content>
