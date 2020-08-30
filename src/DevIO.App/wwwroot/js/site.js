﻿function AjaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

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
            )
        });

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
    });    
}