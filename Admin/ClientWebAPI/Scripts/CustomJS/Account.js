

function PrepareEditUser(id) {
    $('#myLoading').modal('show');
    $.ajax({
        url: "/Account/PrepareUpdateUser/",
        type: "POST",
        data: { id: id },
        success: function (result) {

            var res = result;

            if (res.mgs == '' || res.mgs == null) {
                $('#myLoading').modal('hide');
                $('#id').val(result.id);
                $('#username').val(result.userName);
                $('#password').val(result.passWord);
                $('#name').val(result.name);
                $('#mobile').val(result.mobile);
                $('#email').val(result.email);

                $('#myModal').modal("show");
            }
            else {
                $('#myLoading').modal('hide');
                toastr.error('Không thể kết nối đến API', 'Lỗi Server', { timeOut: 3000, closeButton: true, progressBar: true, showMethod: 'fadeIn', hideMethod: 'hide' })
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function DeleteUser(id, userName) {
    var r = confirm("Bạn có muốn xóa " + userName + " không?");
    if (r == true) {
        $('#myLoading').modal('show');
        $.ajax({
            url: "/Account/DeleteUser/",
            type: "POST",
            data: { id: id },
            success: function (result) {
                if (result == "1") {
                    document.location = "/Account/Index";
                }
                else {
                    if (result == "-1") {
                        $('#myLoading').modal('hide');
                        toastr.error('Không thể kết nối đến API', 'Lỗi Server', { timeOut: 4000, closeButton: true, progressBar: true, showMethod: 'fadeIn', hideMethod: 'hide' });
                    } else {
                        $('#myLoading').modal('hide');
                        toastr.error('Bạn không có quyền thực hiện chức năng này', 'Không có quyền', { timeOut: 4000, closeButton: true, progressBar: true, showMethod: 'fadeIn', hideMethod: 'hide' });
                    }

                }
            }
        });

    }

}

function CreateOrUpdate(obj) {
    $.ajax({
        url: "/Account/addorupdateuser/",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(obj),
        success: function (res) {
            if (res.mgs != "-1" && res.mgs != undefined) {
                var r = confirm(res.mgs);
                if (r == true) {
                    $('#myLoading').modal('hide');
                    document.location = "/Account/Index";
                }
            }
            else {
                if (res.mgs == "-1" && res.mgs != undefined) {
                    $('#myLoading').modal('hide');
                    toastr.error('Không thể kết nối đến API', 'Lỗi Server', { timeOut: 3000, closeButton: true, progressBar: true, showMethod: 'fadeIn', hideMethod: 'hide' });
                }
                else {
                    $('#myLoading').modal('hide');
                    toastr.error('Bạn không có quyền thực hiện chức năng này', 'Không có quyền', { timeOut: 4000, closeButton: true, progressBar: true, showMethod: 'fadeIn', hideMethod: 'hide' });
                }

            }
        }
    })
}

$(document).ready(function () {
    $('#dataTables-example').dataTable();
    $('#dataTables-example1').dataTable();

    $('#openModal').click(function () {
        $('#id').val("");
        $('#username').val("");
        $('#password').val("");
        $('#name').val("");
        $('#mobile').val("");
        $('#email').val("");
        $('#myModal').modal("show");
    });

    $('#btnSave').click(function () {
        $('#myLoading').modal('show');
        var id = $('#id').val();
        if (id == null || id == '') {
            id = "0";
        }
        var username = $('#username').val();
        var password = $('#password').val();

        if (username == null || username == '') {
            $('#myLoading').modal('hide');
            toastr.error('Không được để trống tên đăng nhập.', 'Lỗi', { timeOut: 3000, closeButton: true, progressBar: true, showMethod: 'fadeIn', hideMethod: 'hide' })
            return;
        }

        if (password == null || password == '') {
            $('#myLoading').modal('hide');
            toastr.error('Không được để trống mật khẩu.', 'Lỗi', { timeOut: 3000, closeButton: true, progressBar: true, showMethod: 'fadeIn', hideMethod: 'hide' })
            return;
        }

        var obj = {
            id: id,
            userName: username,
            passWord: password,
            name: $('#name').val(),
            mobile: $('#mobile').val(),
            email: $('#email').val(),
            mgs: ""
        }

        if (id == "0") { //Tức là đang thêm mới thì phải check trùng Username
            $.ajax({
                url: "/Account/CheckDuplicate/",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(obj),
                success: function (res) {
                    if (res.mgs != null && res.mgs != '-1') {
                        //K trùng với ai
                        if (res.mgs == '0') {
                            CreateOrUpdate(obj);
                        } else { //đã tồn tại user
                            $('#myLoading').modal('hide');
                            toastr.error('Đã tồn tại tên đăng nhập', 'Lỗi', { timeOut: 3000, closeButton: true, progressBar: true, showMethod: 'fadeIn', hideMethod: 'hide' })
                        }
                    }
                    else { //Lỗi Server
                        $('#myLoading').modal('hide');
                        toastr.error('Không thể kết nối đến API', 'Lỗi', { timeOut: 3000, closeButton: true, progressBar: true, showMethod: 'fadeIn', hideMethod: 'hide' })
                    }
                }
            });
        }
        else { // đang sửa thì k cần
            CreateOrUpdate(obj);
        }

    })

});