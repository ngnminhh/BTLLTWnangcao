$(document).ready(function() {
    //Xử lí modal
    $("#myModal").on("shown.bs.modal", function() {
        $("#myInput").trigger("focus");
    });
    $(".btn-fix").on("click", function() {
        $("#exampleModal").modal("show");
        $("#exampleModalLabel").text("Cập nhật sản phẩm");
    });
    $("#btn-add").on("click", function() {
        $("#exampleModal").modal("show");
        $("#exampleModalLabel").text("Thêm sản phẩm");
    });
    $("#btn-close").on("click", function() {
        $("#exampleModal").modal("toggle");
    });
    $("#btn-action").on("click", function() {
        // $("#exampleModal").modal("toggle");
    });

    //Xử lý nút thêm
    $("#btn-add").on("click", function() {
        $("#btn-action")
            .off("click")
            .on("click", function() {
                var newbookName = $("#book-name").val();
                var newbookNXB = $("#nhaxuatban").val();
                var newbookDesc = $("#book-description").val().trim();
                var newbookAmount = $("#book-amount").val();
                var newbookStatus = "Còn sách";
                var newbookPrice = $("#book-price").val();
                var newbookCategory = $("#book-category").val();
                var newbookCateName = $("#book-category option:selected").text();
                var newbookAuthor = $("#book-author").val();

                var formData = new FormData();
                formData.append("bookName", newbookName);
                formData.append("bookNXB", newbookNXB);
                formData.append("bookDesc", newbookDesc);
                formData.append("bookStatus", newbookStatus);
                formData.append("bookPrice", newbookPrice);
                formData.append("bookCategory", newbookCategory);
                formData.append("bookAuthor", newbookAuthor);
                formData.append("bookAmount", newbookAmount);
                //  hiển thị sau khi thêm thành công - cóp cái shtml bên category xong đổ ra như này ôk 
                $.ajax({
                    url: "add_book",
                    type: "POST",
                    data: formData,
                    contentType: false,
                    processData: false,
                    success: function(data) {
                        // console.log(data);

                        var xml = "<tr>";
                        xml += `<th scope="row">${data["sMaSach"]}</th>`;
                        xml += `<td class="bookname">${data["sTenSach"]}</td>`;
                        xml += `<td class="nxb">${data["sNhaXuatBan"]}</td>`;
                        xml += `<td style="max-width: 80px;text-overflow: ellipsis;overflow: hidden;white-space: nowrap;" class="description">
                    ${data["sMoTa"]}
                </td>`;
                        xml += `<td class="status">${data["iSoLuong"]}</td>`;
                        xml += `<td class="status">${data["sTrangThai"]}</td>`;
                        xml += `<td class="price">${data["fGiaTien"]}</td>`;
                        xml += `<td class="category" value="${data["sMaDanhMuc"]}">${newbookCateName}</td>`;
                        xml += `<td class="author">${data["sTenTacGia"]}</td>`;
                        xml += `<td class="image">
                    <img src="/images/megazine11.jpg" alt="" style="max-height: 60px;">
                </td>`;
                        xml += `<td>
                    <button type="button" class="btn btn-primary btn-fix"><i class="fa-solid fa-wrench"
                            style="color: #ffffff;"></i></button>
                    <button type="button" class="btn btn-danger btn-del"><i class="fa-solid fa-trash"
                            style="color: #ffffff;"></i></button>
                </td>`;
                        xml += "</tr>";
                        CloseModal();
                        $("#form-books")[0].reset();
                        $("#list-sach").append(xml);
                    },
                });
            });
    });

    //Xử lý nút sửa
    $(".btn-fix").on("click", function() {
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

        $("#btn-action")
            .off("click")
            .on("click", function() {
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
                // dc roi 
                $.ajax({
                    url: "/update_book",
                    type: "POST",
                    data: formData,
                    contentType: false,
                    processData: false,
                    success: function(data) {
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
                        $("#form-books")[0].reset();
                    },
                    error: function(data) {
                        console.log(data);
                    },
                });
            });
    });

    //Xử lý nút xóa
    $(".btn-del").off("click").on("click", function() {
        var row = $(this).parent("td").parent("tr");
        var bookID = $(this).parent("td").siblings(".item_masach");
        console.log("Nhấn");

        if (confirm("Bạn có chắc muốn xóa sản phẩm này?") == true) {
            var formData = new FormData();
            formData.append("bookID", bookID.val());
            $.ajax({
                url: "/delete_book",
                type: "post",
                data: formData,
                contentType: false,
                processData: false,
                success: function(data) {
                    console.log(data);
                }
            });
            row.html("");
        }
    });

    //Các hàm xử lý
    function CloseModal() {
        $("#exampleModal").modal("toggle");
    }
    $.ajax({
        url: "/getdanhmuc",
        dataType: "json",
        success: function(data) {
            var optDanhMuc = "<option selected>---Chọn danh mục---</option>";
            $.each(data, function(key, value) {
                optDanhMuc += `<option value="${value["sMaDanhMuc"]}">${value["sTenDanhMuc"]}</option>`;
            });
            $("#book-category").append(optDanhMuc);
        },
    });
});