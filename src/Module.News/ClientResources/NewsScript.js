(function () {

    var expanders = document.querySelectorAll('article a.expander')

    for (var i = 0; i < expanders.length; i++) {
        var expander = expanders[i];
        var article = expander.previousElementSibling;
        var offset = Math.abs(article.scrollHeight - article.offsetHeight);

        if (offset > 1) {
            expander.addEventListener('click', function () {
                this.previousElementSibling.style.maxHeight = '';
                this.style.display = 'none';
            });
        }
        else {
            expander.style.display = 'none';
        }
    }

})();