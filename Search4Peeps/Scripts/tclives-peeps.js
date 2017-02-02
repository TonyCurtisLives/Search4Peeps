var tclives;
(function (tclives) {
    var peeps;
    (function (peeps) {
        function onSuccessSearch(data) {
            var items = '';
            var row = '';
            if (data.length === 0) {
                $('#tblPeeps tbody').append(
                    "<tr><td colspan='5'>Sorry, no peeps match your search criteria.</td></tr>");
            }
            else {
                $.each(data, function (i, item) {
                    row = "<tr>"
                    + "<td class='photo-td'><img height = '100' src='/image/show/"
                    + item.Photo + "' /></td>"
                    + "<td>" + item.Name + "</td>"
                    + "<td>" + item.Age + "</td>"
                    + "<td class='address-col'>" + item.Address + "</td>"
                    + "<td class='multiline-col'>" + item.Interests + "</td>"
                    + "<td>" + item.HasShrubbery + "</td>"
                    + "<td>" + item.SwallowIQ + "</td>"
                    + "<td>" + item.FavoriteColor + "</td>"
                    + "<td>" + item.Nationality + "</td>"
                    + "</tr>";
                    $('#tblPeeps tbody').append(row);
                });
            }
            $('#tblPeeps').show();
        }
        function onBeginSearch() {
            $('#tblPeeps').hide();
            $('#searchError').hide();
            $('#errorMessage').empty();
            $('#tblPeeps tbody').empty();
            $('#waitMessage').show();
        }
        function onCompleteSearch() {
            $('#waitMessage').hide();
        }
        function onFailureSearch(error, status) {
            if (status === "error") {
                $('#errorMessage').append("Error Message: " + error.statusText === '' ? 'Unknown error' : error.statusText);
                $('#searchError').show();
            }
        }
        peeps.onSuccessSearch = onSuccessSearch;
        peeps.onBeginSearch = onBeginSearch;
        peeps.onCompleteSearch = onCompleteSearch;
        peeps.onFailureSearch = onFailureSearch;
    })(peeps = tclives.peeps || (tclives.peeps = {}));
})(tclives || (tclives = {}));
