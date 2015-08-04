var supportedTldPage = "http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html";

function getTldList(callback) {
    /*
    $.ajax({
        url: supportedTldPage,
        type: 'GET',
        success: function (res) {
            var pageHtml = res.responseText;
            var jsonResult = parseHtml(pageHtml);
            callback(jsonResult);
        }
    });
    */
    
    /* In chrome I installed an extension in order for this to work: https://chrome.google.com/webstore/detail/allow-control-allow-origi/nlfbmbojpeacfghkpbjhddihlkkiljbi?hl=en */
    var request = new XMLHttpRequest();
    request.open("GET", supportedTldPage, true);
    request.onreadystatechange = function () {
        if (request.readyState != 4 || request.status != 200) return;

        var pageHtml = request.responseText;
        var jsonResult = parseHtml(pageHtml);
        callback(jsonResult);
    };
    request.send();
}

function parseHtml(pageHtml) {
    var pattern = /<a class="xref" href="registrar-tld-list.html#.+?">[.](.+?)<\/a>/g;
    var regEx = new RegExp(pattern);

    var result = {};
    result.url = supportedTldPage;
    result.date = new Date().toUTCString();
    result.tldList = [];

    while ((match = regEx.exec(pageHtml)) !== null) {
        result.tldList.push(match[1]);
    }

    var myString = JSON.stringify(result);
    return myString;
}


