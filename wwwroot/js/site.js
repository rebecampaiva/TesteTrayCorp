// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



    $(document).ready(function () {

        $("#content").html('<a id="riverroad" href="#" title="" >image of 1 Maple St.</a>');
        $("#content #riverroad").tooltip({ content: '<img src=https://i2.wp.com/www.precolandia.com.br/blog/wp-content/uploads/2017/09/Como-fazer-o-melhor-queijo-quente.jpg?fit=1140%2C500&ssl=1" />' });

        $("#card2").hide();
        $("#card3").hide();
        $("#card4").hide();


        $("#AddLanche1").click(function () {

            $("#card2").show();
          
        });

        $("#Lanche1").change(function () {

            var lancheid = $("#Lanche1").val()
            var qtde = $("#Combo1").is(':checked');
            var combo = $("#Qtde1").val()

            var value = CalculaValor(lancheid, qtde, combo);
            $("#QtdeItens").text("Qtd de Itens: " + combo);

            
        });


        $("#Combo1").change(function () {

            var lancheid = $("#Lanche1").val()
            var qtde = $("#Combo1").is(':checked');
            var combo = $("#Qtde1").val()

            var value = CalculaValor(lancheid, qtde, combo);

            $("#QtdeItens").text("Qtd de Itens: " + combo);


        });

        $("#Qtde1").change(function () {

            var lancheid = $("#Lanche1").val()
            var qtde = $("#Combo1").is(':checked');
            var combo = $("#Qtde1").val()

            var value = CalculaValor(lancheid, qtde, combo);

            $("#QtdeItens").text("Qtd de Itens: " + combo);



        });

        $("#AddLanche2").click(function () {

            $("#card3").show();

        });

       $("#AddLanche3").click(function () {

           $("#card4").show();

        });

        $("#SubLanche2").click(function () {

            $("#card2").hide();

        });

        $("#SubLanche3").click(function () {

            $("#card3").hide();

        });

        $("#SubLanche4").click(function () {

            $("#card4").hide();

        });



    });

function CalculaValor(lancheid, qtde, combo) {

    $.ajax({
        type: "POST",
        url: "/Pedido/CalculaValorLanche",
        data: { lancheid: lancheid, qtde: combo, combo: qtde },
        dataType: "json",
        success: function (result) {
            console.log(result);
            $("#ValorPedido").text("Valor: R$ " + result);
            return result;

          
        },
        error: function (result) {

        }
    });





}


