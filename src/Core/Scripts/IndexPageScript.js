var WebsiteBuilder = WebsiteBuilder || {};

WebsiteBuilder.LanguageRedirect = function (supportedLanguages, startPage) {
    supportedLanguages = supportedLanguages || [];

    var language = navigator.language || navigator.userLanguage;
    var index = supportedLanguages.indexOf(language);

    if (index == -1) {
        language = supportedLanguages[0];
    }

    var file = 'index.html';
    var url = location.href;
    var fileIndex = url.lastIndexOf(file);

    if (fileIndex > -1) url = url.substr(0, fileIndex);

    if (url.indexOf('/', url.length - 1) === -1) url += '/';

    url += language;
    if (startPage) {
        url += '/' + startPage;
    }

    location.href = url;
}