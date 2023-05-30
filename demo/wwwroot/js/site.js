$(document).ready(function (e) {
    $("#logout").on("click", function (e) {
        localStorage.clear();
        sessionStorage.clear();
    })
})