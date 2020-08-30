$(function () {
    $("a[data-modal]").on("click",
        function (e) {
            $("#myModalContent").load(this.href,
                function () {
                    $("#myModal").modal({ keyboard: true }, 'show');
                    bindForm(this);
                }
            );
            return false;
        }
    );

    $("#Endereco_Cep").blur(function () {
        var cep = $(this).val();
        buscaCep(cep);
    });
});

function ajaxModal() {
    $.ajaxSetup({ cache: false });
}

function bindForm(dialog) {
    $("form", dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $("#myModal").modal("hide");
                    $("#EnderecoTarget").load(result.url);
                }
                else {
                    $("#myModalContent").html(result);
                    bindForm(dialog);
                }
            },
            error: function (xhr, status, error) {
                console.log(xhr);
                console.log(status);
                console.log(error);
            }
        });
        return false;
    });
}

function buscaCep(cep) {
    cep = cep.replace(/\D/g, '');

    if (cep != "") {
        var validaCep = /^[0-9]{8}$/;

        if (validaCep.test(cep)) {
            $("#Endereco_Logradouro").val("...");
            $("#Endereco_Bairro").val("...");
            $("#Endereco_Cidade").val("...");
            $("#Endereco_Estado").val("...");

            $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                function (dados) {
                    if (!("erro" in dados)) {
                        $("#Endereco_Logradouro").val(dados.logradouro);
                        $("#Endereco_Bairro").val(dados.bairro);
                        $("#Endereco_Cidade").val(dados.localidade);
                        $("#Endereco_Estado").val(dados.uf);
                    }
                    else {
                        limpaFomularioCep();
                        alert("CEP não encontrado.");
                    }
                }
            );
        }
        else {
            limpaFomularioCep();
            alert("Formato de CEP inválido.");
        }
    }
    else {
        limpaFomularioCep();
    }
}

function limpaFomularioCep() {
    $("#Endereco_Logradouro").val();
    $("#Endereco_Bairro").val();
    $("#Endereco_Cidade").val();
    $("#Endereco_Estado").val();
}