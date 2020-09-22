function DynamicNotify(type, msg) {
    switch (type) {
        case 1:
            {
                $('#modalSuccess').modal('show');
                $('#psuccess').text(msg);
                break;
            }
        case 2:
            {
                $('#modalError').modal('show');
                $('#perror').text(msg);
                break;
            }
        case 3:
            {
                $('#modalWarning').modal('show');
                $('#pwarning').text(msg);
                break;
            }
        case 4:
            {
                $('#modalInfo').modal('show');
                $('#pinfo').text(msg);
                break;
            }
        case 0:
            {
                $('#modalError').modal('show');
                $('#perror').text("Something went wrong.Try again later.");
            break;
            }
        default:
            break;
    }
}
var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};
