﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteBuilder.Modules.Gallery.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebsiteBuilder.Modules.Gallery.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (function () {
        ///
        ///    var images = document.querySelectorAll(&apos;.gallery a&apos;);
        ///    var container = document.querySelector(&apos;.gallery .full&apos;);
        ///
        ///    var hide = function (e) {
        ///        e.preventDefault();
        ///        e.cancel = true;
        ///        container.style.display = &apos;none&apos;;
        ///        container.innerHTML = &apos;&apos;;
        ///    };
        ///
        ///    var show = function (e) {
        ///        e.preventDefault();
        ///        e.cancel = true;
        ///
        ///        var img = document.createElement(&apos;img&apos;);
        ///        img.src = this.href;
        ///        container.appendChil [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GalleryCode {
            get {
                return ResourceManager.GetString("GalleryCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .gallery {
        ///    img {
        ///        border: 0;
        ///    }
        ///
        ///    a:not(.close) {
        ///        display: inline-block;
        ///        vertical-align:middle;
        ///        border: 1px solid #DDD;
        ///        padding: 10px;
        ///        margin: 8px;
        ///
        ///        &amp;:hover {
        ///            background-color: #EEE;
        ///        }
        ///    }
        ///
        ///    .full {
        ///        position: fixed;
        ///        top: 0;
        ///        left: 0;
        ///        right: 0;
        ///        bottom: 0;
        ///        display: none;
        ///        background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAY [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GalleryStyles {
            get {
                return ResourceManager.GetString("GalleryStyles", resourceCulture);
            }
        }
    }
}
