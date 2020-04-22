/* Arquivo .js que contém todas funções necessárias para a página de Assunto */
$(document).ready(function () {
    $('#dtAssunto').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json",
            "infoEmpty": "No entries to show"
        }
    });

    $('#btnCreateAssunto').on('click', function () {
        $("#modalAssunto").load("/Assunto/Create", function () {
            $("#modalAssunto").modal('show');
        });
    });

    $(document).on('click', '.btnDetailsAssunto', function (e) {
        e.preventDefault();
        id = $(this).data('id');

        $("#modalAssunto").load("/Assunto/Details?id=" + id, function () {
            $("#modalAssunto").modal('show');
        });
    });

    $(document).on('click', '.btnEditarAssunto', function (e) {
        e.preventDefault();
        id = $(this).data('id');

        $("#modalAssunto").load("/Assunto/Edit?id=" + id, function () {
            $("#modalAssunto").modal('show');
        });
    });

    $(document).on('click', '.btnDeleteAssunto', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var nome = $(this).data('nome');

        var msg = "<p class=\"success-message\">Deseja excluir realmente este Assunto: <b>" + nome + "</b>? </p>";
        $("#modal-body-Assunto").html(msg);
        $("#modalDeleteAssunto").modal('show');
        $('#modalDeleteAssunto').on('click', '.delete-confirm', function (e) {

            //Ajax Function to send a get request
            $.ajax({
                type: "POST",
                url: '/Assunto/Delete',
                data: JSON.stringify({ id: id }), //use id here
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    if (result.success) {
                        // window.location = window.location;
                        $("#modalDeleteAssunto").modal('hide');
                        bootbox.alert("Assunto excluído com sucesso!");

                    } else {
                        if (result.error === null) {
                            $('#modalDeleteAssunto').html(result);
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

    $('#btnRefreshAssunto').on('click', function () {
        loadData();
    });
});

function loadData() {
    //Ajax Function to send a get request
    $.ajax({
        type: "Get",
        url: '/Assunto/Index',
        success: function () {
            window.location = window.location;
        },
        error: function (er) {
            bootbox.alert(er);
        }
    });
}