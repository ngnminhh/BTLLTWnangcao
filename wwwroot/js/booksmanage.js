$(document).ready(function () {
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
});
