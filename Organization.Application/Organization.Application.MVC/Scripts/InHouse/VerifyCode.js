
var appvc = {
    handler: {
        btnResendCodeClick: function () {
            var resendCodeUrl = $('#ResendCodeUrl').val(),
                alertInfo = $('.alert');

            $.ajax({
                type: "POST",
                url: resendCodeUrl,
                contentType:'application/json',
                success: function (data, textStatus, jqXHR) {
                    alertInfo.text("Code verification has been sent. Please check your text message at your phone device.")
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alertInfo.text("There was an error. Verificaion code not generated. Please try again.");
                }
            });
        }
    },
    init: function () {
        $("#btnResendCode").click(appvc.handler.btnResendCodeClick);

    }
};

$(document).ready(function () {
    appvc.init();
});