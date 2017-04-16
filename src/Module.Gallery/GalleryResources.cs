using System;

namespace WebsiteBuilder.Modules.Gallery {
    class GalleryResources {

        public const String Styles = @"
.gallery {
    img {
        border:0;
    }
    a {
        display:inline-block;
        border:1px solid #DDD;
        padding:10px;
        margin:8px;
        &:hover {
            background-color:#EEE;
        }
    }
    .full {
        position:fixed;
        top:30px;
        left:30px;
        right:30px;
        bottom:30px;
        display:none;
        
        img {
            max-width:100%;
            max-height:100%;
            border:2px solid #666;
            cursor:pointer;
        }
    }
}";

        public const String Script = @"(function() {

var images = document.querySelectorAll('.gallery a');
var container = document.querySelector('.gallery .full');

var hide = function(e) {
    e.preventDefault();
    e.cancel = true;
    container.style.display = 'none';
};

var show = function(e) {
    e.preventDefault();
    e.cancel = true;

    var img = document.createElement('img');
    img.src = this.href;
    img.addEventListener('click', hide);
    container.innerHTML = '';
    container.appendChild(img);

    container.style.display = 'block';
    return false;
};

for(var i = 0; i < images.length; i++) {
    var img = images[i];
    var fileName = img.href;
    img.target = '';
    img.addEventListener('click', show);
}

})();";
    }
}
