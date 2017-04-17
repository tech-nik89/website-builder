(function () {

    var images = document.querySelectorAll('.gallery a');
    var container = document.querySelector('.gallery .full');

    var hide = function (e) {
        e.preventDefault();
        e.cancel = true;
        container.style.display = 'none';
        container.innerHTML = '';
    };

    var show = function (e) {
        e.preventDefault();
        e.cancel = true;

        var img = document.createElement('img');
        img.src = this.href;
        container.appendChild(img);

        var close = document.createElement('a');
        close.className = 'close';
        close.href = 'javascript:void(0)';
        close.addEventListener('click', hide);
        container.appendChild(close);

        container.style.display = 'block';
        return false;
    };

    for (var i = 0; i < images.length; i++) {
        var img = images[i];
        var fileName = img.href;
        img.target = '';
        img.addEventListener('click', show);
    }

})();