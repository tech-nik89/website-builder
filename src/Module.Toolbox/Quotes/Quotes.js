(function () {
    function instance(container) {
        var _Quotes = container.querySelectorAll('.quotes > blockquote');
        var _Progress = container.querySelector('.quotes > .progress > span');
        var _Index = 0;
        var _Interval = 10;

        function hideAllExcept(except) {
            for (var i = 0; i < _Quotes.length; i++) {
                if (i == except) {
                    _Quotes[i].style.display = 'block';
                }
                else {
                    _Quotes[i].style.display = 'none';
                }
            }

            _Progress.className = '';
            setTimeout(function () {
                _Progress.className = 'run';
            }, 35);
        }

        function next() {
            _Index++;

            if (_Index >= _Quotes.length) {
                _Index = 0;
            }

            hideAllExcept(_Index);
        }

        setInterval(function () {
            next();
        }, _Interval * 1000);

        hideAllExcept(0);
        _Progress.style.animationDuration = _Interval + 's';
    }

    var _Instances = document.getElementsByClassName('quotes');
    for (var x = 0; x < _Instances.length; x++) {
        new instance(_Instances[x]);
    }
})();