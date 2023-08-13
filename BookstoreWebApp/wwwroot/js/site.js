$(document).ready(function () {
    $("#logoutButton").click(function () {
        $('#logoutModal').show();
    });

    $('#logoutModal').on('click', '.no-logout-button', function () {
        $('#logoutModal').hide();
    });

    $('#logoutModal').on('click', '.yes-logout-button', function () {
        $('#logoutModal').hide();
        sessionStorage.removeItem('token');
        window.location.href = "/Account/Index";
    });
});