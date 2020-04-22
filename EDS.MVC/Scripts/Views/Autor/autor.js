/* Arquivo .js que contém todas funções necessárias para a página de Autor */
$(document).ready(function () {
    $('#dtAutor').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json",
            "infoEmpty": "No entries to show"
        }
    });

    $('#btnCreateAutor').on('click', function () {
        $("#modalAutor").load("/Autor/Create", function () {
            $("#modalAutor").modal('show');
        });
    });

    $(document).on('click', '.btnDetailsAutor', function (e) {
        e.preventDefault();
        id = $(this).data('id');

        $("#modalAutor").load("/Autor/Details?id=" + id, function () {
            $("#modalAutor").modal('show');
        });
    });

    $(document).on('click', '.btnEditarAutor', function (e) {
        e.preventDefault();
        id = $(this).data('id');

        $("#modalAutor").load("/Autor/Edit?id=" + id, function () {
            $("#modalAutor").modal('show');
        });
    });

    $(document).on('click', '.btnDeleteAutor', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var nome = $(this).data('nome');

        var msg = "<p class=\"success-message\">Deseja excluir realmente este Autor: <b>" + nome + "</b>? </p>";
        $("#modal-body-Autor").html(msg);

        $("#modalDeleteAutor").modal('show');
        $('#modalDeleteAutor').on('click', '.delete-confirm', function (e) {

            //Ajax Function to send a get request
            $.ajax({
                type: "POST",
                url: '/Autor/Delete',
                data: JSON.stringify({ id: id }), //use id here
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    if (result.success) {
                        $("#modalDeleteAutor").modal('hide');
                        bootbox.alert("Autor excluído com sucesso!");
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

    $('#btnRefreshAutor').on('click', function () {
        loadData();
    });
});

function loadData() {
    //Ajax Function to send a get request
    $.ajax({
        type: "Get",
        url: '/Autor/Index',
        success: function () {
            window.location = window.location;
        },
        error: function (er) {
            bootbox.alert(er);
        }
    });
}