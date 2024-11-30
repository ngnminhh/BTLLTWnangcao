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
        $("#SMaDanhMuc").val("");
        $("#STenDanhMuc").val("");
        $("#VerifyKey").val("");
        $("#exampleModal").modal("show");
        $("#exampleModalLabel").text("Thêm sản phẩm");
        $("#btn-action").off("click").on("click", function() {
            $("#form-category").submit();
        });
    });
    $("#btn-close").on("click", function() {
        $("#exampleModal").modal("toggle");
    });
    $("#btn-action").on("click", function() {
        // $("#exampleModal").modal("toggle");
    });
    //them

    // // Xử lý nút thêm
    // $("#btn-add").on("click", function() {
    //     $("#btn-action")
    //         .off("click")
    //         .on("click", function() {
    //             // Lấy giá trị từ các input
    //             var newid = $("#SMaDanhMuc").val(); // ID của danh mục
    //             var newtenDM = $("#STenDanhMuc").val(); // Tên danh mục

    //             // Tạo FormData để gửi yêu cầu
    //             var formData = new FormData();
    //             formData.append("id", newid);
    //             formData.append("tendm", newtenDM);

    //             // Gửi yêu cầu AJAX
    //             $.ajax({
    //                 url: "/add_Category",
    //                 type: "POST",
    //                 data: formData,
    //                 contentType: false,
    //                 processData: false,
    //                 success: function(data) {
    //                     // Tạo hàng mới trong bảng
    //                     var xml = `<tr>
    //                     <td class="id">${data.id}</td>
    //                     <td class="tendm">${data.tendm}</td>
    //                     <td>
    //                         <button type="button" class="btn btn-primary btn-fix">
    //                             <i class="fa-solid fa-wrench" style="color: #ffffff;"></i>
    //                         </button>
    //                         <button type="button" class="btn btn-danger btn-del">
    //                             <i class="fa-solid fa-trash" style="color: #ffffff;"></i>
    //                         </button>
    //                     </td>
    //                 </tr>`;

    //                     // Thêm hàng mới vào bảng
    //                     $("#list-category").append(xml);

    //                     // Đặt lại form và đóng modal
    //                     $("#form-category")[0].reset();
    //                     CloseModal();
    //                 },
    //                 error: function(xhr, status, error) {
    //                     console.error("Lỗi:", error);
    //                     alert("Thêm danh mục thất bại. Vui lòng thử lại.");
    //                 }
    //             });
    //         });
    // });


    // Xử lý nút thêm
    //$("#btn-add").on("click", function() {
    //    $("#btn-action")
    //        .off("click")
    //        .on("click", function() {
    //            // Lấy giá trị từ các input
    //            var newid = $("#SMaDanhMuc").val().trim(); // ID của danh mục
    //            var newtenDM = $("#STenDanhMuc").val().trim(); // Tên danh mục

    //            // Kiểm tra giá trị input trước khi gửi yêu cầu
    //            if (!newid || !newtenDM) {
    //                alert("Vui lòng nhập đầy đủ thông tin!");
    //                return;
    //            }

    //            // Tạo FormData để gửi yêu cầu
    //            var formData = new FormData();
    //            formData.append("id", newid);
    //            formData.append("tendm", newtenDM);

    //            // Gửi yêu cầu AJAX
    //            $.ajax({
    //                url: "/add_Category",
    //                type: "POST",
    //                data: formData,
    //                contentType: false,
    //                processData: false,
    //                success: function(response) {
    //                    if (response.success && response.data) {
    //                        // Tạo hàng mới trong bảng
    //                        var currentCount = $("#list-category tr").length;
    //                        var newRow = `
    //                        <tr>
    //                            <td class="stt">${currentCount + 1}</td> <!-- STT được tính tự động -->
    //                            <td class="id d-none">${response.data.sMaDanhMuc}</td>

    //                            <td class="tendm">${response.data.sTenDanhMuc}</td>
    //                            <td>
    //                                <button type="button" class="btn btn-primary btn-fix">
    //                                    <i class="fa-solid fa-wrench" style="color: #ffffff;"></i>
    //                                </button>
    //                                <button type="button" class="btn btn-danger btn-del">
    //                                    <i class="fa-solid fa-trash" style="color: #ffffff;"></i>
    //                                </button>
    //                            </td>
    //                        </tr>`;

    //                        // Thêm hàng mới vào bảng
    //                        $("#list-category").append(newRow);

    //                        // Đặt lại form
    //                        $("#form-category")[0].reset();

    //                        // Đóng modal
    //                        $("#exampleModal").modal("hide"); // Sử dụng jQuery để đóng modal
    //                    } else {
    //                        alert("Phản hồi từ server không hợp lệ.");
    //                    }
    //                },
    //                error: function(xhr, status, error) {
    //                    console.error("Lỗi:", error);
    //                    alert("Thêm danh mục thất bại. Vui lòng thử lại.");
    //                },
    //            });
    //        });
    //});


    //sua

    $(".btn-fix").on("click", function() {
        $("#SMaDanhMuc").attr("disabled", true);
        // Xác định dòng hiện tại
        var row = $(this).closest(".item_cate"); // Lấy dòng chứa nút "Sửa"
        var id = row.find(".item_maDanhMuc").val(); // Lấy ID từ input ẩn
        var tendm = row.find(".item_tenDanhMuc").val(); // Lấy ID từ input ẩn
        var vKey = row.find(".item_vkey").val(); // Lấy ID từ input ẩn


        console.log("ID: ", id); // Kiểm tra xem id có đúng không
        console.log("Tên danh mục: ", tendm); // Kiểm tra xem tendm có đúng không
        console.log("VerifyKey: ", vKey); // Kiểm tra xem vKey có đúng không





        // Đưa dữ liệu vào modal
        $("#SMaDanhMuc").val(id);
        $("#STenDanhMuc").val(tendm.trim());
        $("#VerifyKey").val(vKey.trim());

        // Mở modal
        $("#exampleModal").modal("show");

        // Xử lý sự kiện khi nhấn nút "Thực hiện" trong modal
        $("#btn-action").off("click").on("click", function() {
            $('#form-category').submit(function(evt) {
                evt.preventDefault();
            });
            var newID = $("#SMaDanhMuc").val(); // Lấy ID mới từ input
            var newTenDM = $("#STenDanhMuc").val(); // Lấy tên danh mục mới từ input
            var newVKey = $("#VerifyKey").val();


            // Tạo FormData để gửi dữ liệu
            var formData = new FormData();
            formData.append("id", newID);
            formData.append("tendm", newTenDM);
            formData.append("vkey", newVKey);


            // Gửi AJAX để cập nhật danh mục
            if ($('#form-category').valid()) {
                $.ajax({
                    url: "/update_Category", // API cập nhật
                    type: "POST",
                    data: formData,
                    contentType: false,
                    processData: false,
                    success: function(response) {
                        if (response.success && response.data) {
                            // Cập nhật lại bảng trực tiếp
                            console.log(response);
                            row.find(".item_maDanhMuc").val(response.data.sMaDanhMuc);
                            row.find(".tendm").text(response.data.sTenDanhMuc);
                            row.find(".vkey").text(response.data.verifyKey);
                            $("#exampleModal").modal("toggle");
                            // Tải lại trang sau khi cập nhật
                            window.location.reload();

                        } else {
                            alert("Cập nhật thất bại: " + response.message);
                        }
                    },
                    error: function(xhr, status, error) {
                        console.error("Lỗi:", error);
                        alert("Có lỗi xảy ra. Vui lòng thử lại.");
                    }
                });
            }
        });
    });



    //Xử lý nút xóa
    $(".btn-del").off("click").on("click", function() {
        if (confirm("Bạn có chắc muốn xóa danh mục này?")) {
            // Lấy giá trị mã danh mục từ input ẩn
            var idDM = $(this).closest(".item_cate").find(".item_maDanhMuc").val();
            console.log("Mã danh mục: ", idDM);

            // Kiểm tra nếu idDM không hợp lệ
            if (!idDM) {
                alert("Không tìm thấy mã danh mục.");
                return;
            }

            // Gửi dữ liệu qua AJAX
            var formData = new FormData();
            formData.append("SMaDanhMuc", idDM);

            $.ajax({
                url: "/del_Category",
                type: "POST",
                data: formData,
                contentType: false,
                processData: false,
                success: function(data) {
                    console.log(data);
                    if (data.success) {
                        alert(data.message);
                        location.reload(); // Cập nhật lại danh sách
                    } else {
                        alert(data.message);
                    }
                },
                error: function(xhr, status, error) {
                    console.error("Lỗi AJAX: ", error);
                }
            });
        }


        // fetch("/del_Category", {
        //         method: "POST",
        //         body: formData,
        //     })
        //     .then((response) => {
        //         if (!response.ok) {
        //             console.log("Có lỗi xảy ra");
        //         }
        //         return response.json();
        //     })
        //     .then((data) => {

        //         console.log(data);
        //         if (data.success) {
        //             alert(data.message || "Danh mục đã được xóa"); // Hiển thị thông báo
        //             row.remove(); // Xóa dòng khỏi bảng

        //             // Cập nhật lại STT cho tất cả các dòng
        //             $("#list-category tr").each(function(index) {
        //                 $(this).find("td:first").text(index + 1); // Cột đầu tiên là STT
        //             });
        //         } else {
        //             alert(data.message || "Không thể xóa danh mục.");
        //         }
    });
});