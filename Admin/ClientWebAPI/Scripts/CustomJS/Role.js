

$(document).ready(function () {
    $("#btn-save").click(function () {
        var userId = $("#userId").val();
        var roleChecked = $('input[name=role]:checked');
        var res = '';
        var count = 0;
        roleChecked.each(function () {
            if (count == 0) {
                res = $(this).val();
                count++;
            }
            else {
                res = res + ',' + $(this).val();
            }
        });

        $.ajax({
            url: "/Role/PhanQuyenUser",
            type: "POST",
            //contentType: "application/json; charset=utf-8",
            data: { sRole: res, userId : userId },
            success: function (res) {
                if (res != null && parseInt(res) >= 0) {
                   
                    if (res > 0) {
                        var r = confirm("Phân quyền thành công!");
                        if (r == true) {
                            document.location = "/Role/PhanQuyenUser?userid=" + res;
                        }
                    } else {
                        alert("Không thực hiện được!");
                    }
                } else {
                    alert("Bạn không có quyền thực hiện thao tác này!");
                }
            }
        })

    });
})
