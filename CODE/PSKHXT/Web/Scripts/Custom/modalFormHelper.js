//模态框操作js函数
var modalFormHelper = {
    /*******弹出表单*********/
    showModal: function (actionUrl, param, title) {
        var $modal = $("#modal-form");
        //表单初始化
        $(".modal-title", $modal).html(title);
        $("#modal-content", $modal).attr("action", actionUrl);

        $.ajax({
            type: "GET",
            url: actionUrl,
            data: param,
            beforeSend: function () {
                //
            },
            success: function (result) {
                $("#modal-content").html(result);
                $('#modal-form').modal('show');
                modalFormHelper.registerForm();//通过Ajax加载返回的页面原有MVC属性验证将失效，需要重新注册验证脚本。
            },
            error: function () {
                //
            },
            complete: function () {
                //
            }
        });
    },

    /*******注册验证脚本，通过Ajax返回的页面原有MVC属性验证将失效，需要重新注册验证脚本*********/
    registerForm: function () {
        $('#modal-content').removeData('validator');
        $('#modal-content').removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse('#modal-content');
    },

    /*******保存表单*********/
    saveModal: function (table) {

        var actionUrl = $("#modal-content").attr("action");
        var $form = $("#modal-content");
        if (!$form.valid()) {
            return;
        }
        $.ajax({
            type: "POST",
            url: actionUrl,
            data: $form.serialize(),
            success: function (result) {
                if (result.ResultType === 0) {
                    toastr.success(result.Message);
                    $('#modal-form').modal('hide');
                    $(table).bootstrapTable('refresh');
                }
                else {
                    toastr.error(result.Message);
                }
            },
            error: function () {
                toastr.error('网络错误，请重新提交！');
            }
        });
    }
};