/* Arquivo .js que contém todas funções necessárias para a página de Livro */
$(document).ready(function () {
    $('#dtLivro').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json",
            "infoEmpty": "No entries to show"
        }
    });

    $('#btnCreateLivro').on('click', function () {
        $("#modalLivro").load("/Livro/Create", function () {
            $("#modalLivro").modal('show');
        });
    });

    //$(document).on('click', '.btnRelPDFLivro', function (e) {
    //    e.preventDefault();
    //    var pdf = $(this).data('pdf');
    //    //Ajax Function to send a get request
    //    $.ajax({
    //        type: "Get",
    //        url: '/Livro/RelatorioPDF',
    //        data: JSON.stringify({ pdf: pdf }), //use id here
    //        dataType: "json",
    //        contentType: "application/json; charset=utf-8",
    //        success: function (result) {
    //            if (result.success) {

    //                bootbox.alert("Livro excluído com sucesso!");
    //                // window.location = window.location;

    //            } else {
    //                //if (result.error === null) {
    //                //    $('#modalDeleteAutor').html(result);
    //                //} else {
    //                var r = result.error.split('|');
    //                bootbox.alert(r[1]);
    //                // }

    //                return false;
    //            }

    //            //loadData();
    //        },
    //        error: function (er) {
    //            bootbox.alert(er);
    //        }
    //    });

    //    //$('#btnRelPDFLivro').on('click', function () {
    //    //$("#modalLivro").load("/Livro/RelatorioPDF", function () {
    //    //    $("#modalLivro").modal('show');
    //    //});
    //});

    $(document).on('click', '.btnDetailsLivro', function (e) {
        e.preventDefault();
        id = $(this).data('id');

        $("#modalLivro").load("/Livro/Details?id=" + id, function () {
            $("#modalLivro").modal('show');
        });
    });

    $(document).on('click', '.btnEditarLivro', function (e) {
        e.preventDefault();
        id = $(this).data('id');

        $("#modalLivro").load("/Livro/Edit?id=" + id, function () {
            $("#modalLivro").modal('show');
        });
    });

    $(document).on('click', '.btnDeleteLivro', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var nome = $(this).data('nome');

        var msg = "<p class=\"success-message\">Deseja excluir realmente este Livro: <b>" + nome + "</b>? </p>";
        $("#modal-body-Livro").html(msg);
        $("#modalDeleteLivro").modal('show');
        $('#modalDeleteLivro').on('click', '.delete-confirm', function (e) {
            //Ajax Function to send a get request
            $.ajax({
                type: "POST",
                url: '/Livro/Delete',
                data: JSON.stringify({ id: id }), //use id here
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    if (result.success) {
                        $("#modalDeleteLivro").modal('hide');
                        bootbox.alert("Livro excluído com sucesso!");
                        // window.location = window.location;

                    } else {
                        if (result.error === null) {
                            $('#modalDeleteAutor').html(result);
                        } else {
                            var r = result.error.split('|');
                            bootbox.alert(r[1]);
                        }

                        return false;
                    }

                    //loadData();
                },
                error: function (er) {
                    bootbox.alert(er);
                }
            });
        });
    });

    $('#btnRefreshLivro').on('click', function () {
        loadData();
    });
});

function loadData() {
    //Ajax Function to send a get request
    $.ajax({
        type: "Get",
        url: '/Livro/Index',
        success: function () {
            window.location = window.location;
        },
        error: function (er) {
            bootbox.alert(er);
        }
    });
}