// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".menu-toggle").on("click", function () {
  $(".mobile-menu").toggleClass("hidden");
});

$(".auth-toggle").on("click", function () {
  $(".auth-menu").toggleClass("hidden");
});

$("#range").on("input", function () {
  var range = document.getElementById("range");
  var val = range.value;
  var display = document.getElementById("range-label");
  display.innerHTML = "Discount " + val * 100 + "%";
});
