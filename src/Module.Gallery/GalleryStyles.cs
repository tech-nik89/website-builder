using System;

namespace WebsiteBuilder.Modules.Gallery {
    class GalleryStyles {

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
            }";

    }
}
