$(document).ready(function () {
  $("#myModal").on("shown.bs.modal", function () {
    $("#myInput").trigger("focus");
  });
  $("#btn-add").on("click", function () {
    $("#exampleModal").modal("show");
    $("#exampleModalLabel").text("Thêm tài khoản");

    $("#btn-action").off("click").on("click", function () {
    var formData= new FormData();
    formData.append("STaiKhoan",$("#STaiKhoan").val());
    formData.append("SMatKhau",$("#SMatKhau").val());
    formData.append("SCccd",$("#SCccd").val());
    formData.append("SDiaChi",$("#SDiaChi").val());
    formData.append("DNgaySinh",$("#DNgaySinh").val());
      fetch("/add_account", {
        method: "POST",
        body:formData
      })
        .then((response) => {
          if (!response.ok) {
            console.log("Có lỗi xảy ra");
          } 
          return response.json();
        })
        .then((data) => {
          console.log(data);
        });
    });
  });
  $(".btn-fix").on("click", function () {
    $("#exampleModal").modal("show");
    $("#exampleModalLabel").text("Cập nhật tài khoản");
  });
  $("#btn-close").on("click", function () {
    $("#exampleModal").modal("toggle");
  });
});
