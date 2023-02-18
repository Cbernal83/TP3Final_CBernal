<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="TP3Final_CBernal.Resultados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 50px"></div>

    <div class="container vh-100 d-flex justify-content-center  mt-50 mb-50">

        <div class="row">
            <div class="col-md-10">

                <div class="card card-body mt-3">
                    <div class="media align-items-center align-items-lg-start text-center text-lg-left flex-column flex-lg-row">
                        <div class="mr-2 mb-3 mb-lg-0">

                            <img src="https://i.imgur.com/5Aqgz7o.jpg" width="150" height="150" alt="">
                        </div>

                        <div class="media-body">
                            <h6 class="media-title font-weight-semibold">
                                <a href="#" data-abc="true">Apple iPhone XR (Red, 128 GB)</a>
                            </h6>

                            <ul class="list-inline list-inline-dotted mb-3 mb-lg-2">
                                <li class="list-inline-item"><a href="#" class="text-muted" data-abc="true">CATEGORIA</a></li>
                                <li class="list-inline-item"><a href="#" class="text-muted" data-abc="true">SUB CATEGORIA</a></li>
                            </ul>

                            <p class="mb-3">128 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor | Gorilla Glass with high quality display </p>

                        </div>

                        <div class="mt-3 mt-lg-0 ml-lg-3 text-center">
                            <h3 class="mb-0 font-weight-semibold">$459.99</h3>

                            <button type="button" class="btn btn-warning mt-4 text-white"><i class="icon-cart-add mr-2"></i>Add to cart</button>
                        </div>
                    </div>
                </div>


            </div>
        </div>
        

        </div>

        <style>
            body {
                margin: 0;
                font-family: Roboto,-apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol","Noto Color Emoji";
                font-size: .8125rem;
                font-weight: 400;
                line-height: 1.5385;
                color: #333;
                text-align: left;
                background-color: #f5f5f5;
            }

            .mt-50 {
                margin-top: 50px;
            }

            .mb-50 {
                margin-bottom: 50px;
            }


            .bg-teal-400 {
                background-color: #26a69a;
            }

            a {
                text-decoration: none !important;
            }

            /*body{background: linear-gradient(to right, #c04848, #480048);min-height: 100vh}.text-gray{color: #aaa}img{height: 170px;width: 140px}*/
        </style>
</asp:Content>
