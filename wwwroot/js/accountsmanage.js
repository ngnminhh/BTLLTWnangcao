$(document).ready(function() {
    $("#myModal").on("shown.bs.modal", function() {
        $("#myInput").trigger("focus");
    });
    $("#btn-add").on("click", function() {
        $("#exampleModal").modal("show");
        $("#exampleModalLabel").text("Thêm tài khoản");

        $("#btn-action")
            .off("click")
            .on("click", function() {
                $("#form-books").submit();
            });
    });

    //hàm sửa
    $(".btn-fix").on("click", function() {
        $("#exampleModal").modal("show");
        $("#exampleModalLabel").text("Cập nhật tài khoản");

        var taikhoan = $(this).parents("td").siblings(".taikhoan");
        var matkhau = $(this).parents("td").siblings(".matkhau");
        var cccd = $(this).parents("td").siblings(".cccd");
        var diachi = $(this).parents("td").siblings(".diachi");
        var ngaysinh = $(this).parents("td").siblings(".dob");

        $("#STaiKhoan").val(taikhoan.text());
        $("#SMatKhau").val(matkhau.text());
        $("#SCccd").val(cccd.text());
        $("#SDiaChi").val(diachi.text());
        $("#DNgaySinh").val(formatDate(ngaysinh.text()));
        console.log(formatDate(ngaysinh.text()));

        $("#btn-action")
            .off("click")
            .on("click", function() {
                var formData = new FormData();
                formData.append("STaiKhoan", $("#STaiKhoan").val());
                formData.append("SMatKhau", $("#SMatKhau").val());
                formData.append("SCccd", $("#SCccd").val());
                formData.append("SDiaChi", $("#SDiaChi").val());
                formData.append("DNgaySinh", $("#DNgaySinh").val());
                fetch("/edit_account", {
                        method: "POST",
                        body: formData,
                    })
                    .then((response) => {
                        if (!response.ok) {
                            console.log("Có lỗi xảy ra");
                        }
                        return response.json();
                    })
                    .then((data) => {
                        console.log(data);
                        taikhoan.text(data["taikhoan"]);
                        matkhau.text(data["matkhau"]);
                        cccd.text(data["cccd"]);
                        diachi.text(data["diachi"]);
                        ngaysinh.text(showDate(data["ngaysinh"] + ""));
                        CloseModal();
                        alert("Cập nhật thành công");
                    });
            });
    });
    $("#btn-close").on("click", function() {
        $("#exampleModal").modal("toggle");
    });
});
$(".btn-del")
    .off("click")
    .on("click", function() {
        if (confirm("Bạn có chắc muốn xóa tài khoản này") == true) {
            var row = $(this).parent("td").parent("tr");
            var taikhoan = $(this).parent("td").siblings(".taikhoan");
            console.log(taikhoan.text());

            var formData = new FormData();
            formData.append("STaiKhoan", taikhoan.text());

            fetch("/del_account", {
                    method: "POST",
                    body: formData,
                })
                .then((response) => {
                    if (!response.ok) {
                        console.log("Có lỗi xảy ra");
                    }
                    return response.json();
                })
                .then((data) => {
                    console.log(data);
                    alert("Tài khoản đã được xóa");
                    row.remove();
                });
        }
    });

function formatDate(date) {
    var parts = date.split("/");
    var formattedDate = parts[2] + "-" + parts[1] + "-" + parts[0];
    return formattedDate;
}

function showDate(date) {
    var parts = date.split("-");
    var formattedDate = parts[2] + "/" + parts[1] + "/" + parts[0];
    return formattedDate;
}

function CloseModal() {
    $("#exampleModal").modal("toggle");
}