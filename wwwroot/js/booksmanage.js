$(document).ready(function () {
    //Xử lí modal
    $("#myModal").on("shown.bs.modal", function () {
        $("#myInput").trigger("focus");
    });
    $(".btn-fix").on("click", function () {
        $("#exampleModal").modal("show");
        $("#exampleModalLabel").text("Cập nhật sản phẩm");
    });
    $("#btn-add").on("click", function () {
        $("#exampleModal").modal("show");
        $("#exampleModalLabel").text("Thêm sản phẩm");
    });
    $("#btn-close").on("click", function () {
        $("#exampleModal").modal("toggle");
    });
    $("#btn-action").on("click", function () {
        // $("#exampleModal").modal("toggle");
    });

    //Xử lý nút sửa
    $(".btn-fix").on("click", function () {
        var bookID = $(this).parent("td").siblings(".item_masach");
        var bookName = $(this).parent("td").siblings(".bookname");
        var bookNXB = $(this).parent("td").siblings(".nxb");
        var bookDesc = $(this).parent("td").siblings(".description");
        var bookAmount = $(this).parent("td").siblings(".amount");
        var bookStatus = $(this).parent("td").siblings(".status");
        var bookPrice = $(this).parent("td").siblings(".price");
        var bookCategory = $(this).parent("td").siblings(".category");
        var bookAuthor = $(this).parent("td").siblings(".author");

        $("#book-name").val(bookName.text());
        $("#nhaxuatban").val(bookNXB.text());
        $("#book-description").val(bookDesc.text().trim());
        $("#book-price").val(bookPrice.text());
        $("#book-amount").val(bookAmount.text());
        $("#book-status").val(bookStatus.text());
        $("#book-category").val(bookCategory.attr("value"));
        $("#book-author").val(bookAuthor.text());

        $("#btn-action").off("click").on("click", function () {
            var currentbookID = bookID.val();
            var newbookName = $("#book-name").val();
            var newbookNXB = $("#nhaxuatban").val();
            var newbookDesc = $("#book-description").val().trim();
            var newbookAmount = $("#book-amount").val();
            var newbookStatus = "Còn sách";
            var newbookPrice = $("#book-price").val();
            var newbookCategory = $("#book-category").val();
            var newbookAuthor = $("#book-author").val();

            var formData = new FormData();
            formData.append("bookID", currentbookID);
            formData.append("bookName", newbookName);
            formData.append("bookNXB", newbookNXB);
            formData.append("bookDesc", newbookDesc);
            formData.append("bookStatus", newbookStatus);
            formData.append("bookPrice", newbookPrice);
            formData.append("bookCategory", newbookCategory);
            formData.append("bookAuthor", newbookAuthor);
            formData.append("bookAmount", newbookAmount);

            $.ajax({
                url: "/update_book",
                type: "POST",
                data: formData,
                contentType: false,
                processData: false,
                success: function (data) {
                    console.log(data);

                    bookName.text(data[0]["sTenSach"]);
                    bookNXB.text(data[0]["sTenNXB"]);
                    bookDesc.text(data[0]["sMoTa"]);
                    bookAmount.text(data[0]["iSoLuong"]);
                    bookStatus.text(data[0]["sTrangThai"]);
                    bookPrice.text(data[0]["fGiaTien"]);
                    bookCategory.text(data[0]["sTenDanhMuc"]);
                    bookAuthor.text(data[0]["sTenTacGia"]);
                    CloseModal();
                },
                error: function (data) {
                    console.log(data);
                },
            });
        });
    });

    //Các hàm xử lý
    function CloseModal() {
        $("#exampleModal").modal("toggle");
    }
    $.ajax({
        url: "/getdanhmuc",
        dataType: "json",
        success: function (data) {
            var optDanhMuc = "<option selected>---Chọn danh mục---</option>";
            $.each(data, function (key, value) {
                optDanhMuc += `<option value="${value["sMaDanhMuc"]}">${value["sTenDanhMuc"]}</option>`;
            });
            $("#book-category").append(optDanhMuc);
        },
    });
});
