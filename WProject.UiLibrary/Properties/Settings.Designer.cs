﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WProject.UiLibrary.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Resources\\wpDefaultStyle.json")]
        public string StylePath {
            get {
                return ((string)(this["StylePath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<html>\r\n\t<head>\r\n\t\t<style>\r\n\t\t\t#preloader_1{\r\n\t\t\t\tposition: absolute;\r\n\t\t\t\ttop: 5" +
            "0%;\r\n\t\t\t\tleft: 50%;\r\n\t\t\t\tmargin-left: 23px;\r\n\t\t\t}\r\n\t\t\t#preloader_1 span{\r\n\t\t\t\tdi" +
            "splay:block;\r\n\t\t\t\tbottom:0px;\r\n\t\t\t\twidth: 9px;\r\n\t\t\t\theight: 5px;\r\n\t\t\t\tbackground" +
            ":#9b59b6;\r\n\t\t\t\tposition:absolute;\r\n\t\t\t\tanimation: preloader_1 1.5s  infinite eas" +
            "e-in-out;\r\n\t\t\t}\r\n\t\t\t \r\n\t\t\t#preloader_1 span:nth-child(2){\r\n\t\t\tleft:11px;\r\n\t\t\tani" +
            "mation-delay: .2s;\r\n\t\t\t \r\n\t\t\t}\r\n\t\t\t#preloader_1 span:nth-child(3){\r\n\t\t\tleft:22px" +
            ";\r\n\t\t\tanimation-delay: .4s;\r\n\t\t\t}\r\n\t\t\t#preloader_1 span:nth-child(4){\r\n\t\t\tleft:3" +
            "3px;\r\n\t\t\tanimation-delay: .6s;\r\n\t\t\t}\r\n\t\t\t#preloader_1 span:nth-child(5){\r\n\t\t\tlef" +
            "t:44px;\r\n\t\t\tanimation-delay: .8s;\r\n\t\t\t}\r\n\t\t\t@keyframes preloader_1 {\r\n\t\t\t\t0% {he" +
            "ight:5px;transform:translateY(0px);background:#9b59b6;}\r\n\t\t\t\t25% {height:30px;tr" +
            "ansform:translateY(15px);background:#3498db;}\r\n\t\t\t\t50% {height:5px;transform:tra" +
            "nslateY(0px);background:#9b59b6;}\r\n\t\t\t\t100% {height:5px;transform:translateY(0px" +
            ");background:#9b59b6;}\r\n\t\t\t}\r\n\t\t\t.loader-overlay {\r\n\t\t\t\t-ms-opacity: 0.9;\r\n\t\t\t\tb" +
            "ackground: #444;\r\n\t\t\t\tdisplay: block;\r\n\t\t\t\theight: 100%;\r\n\t\t\t\tleft: 0;\r\n\t\t\t\topac" +
            "ity: 0.9;\r\n\t\t\t\tposition: fixed;\r\n\t\t\t\ttop: 0;\r\n\t\t\t\tvertical-align: middle;\r\n\t\t\t\tw" +
            "idth: 100%;\r\n\t\t\t\tz-index: 100000;\r\n\t\t\t\tpadding-left: 20px;\r\n\t\t\t\tpadding-top: 20p" +
            "x;\r\n\t\t\t}\r\n\r\n\t\t\t.loader-content {\r\n\t\t\t\tmargin-left: auto;\r\n\t\t\t\tmargin-top: auto;\r" +
            "\n\t\t\t\twidth: 50%;\r\n\t\t\t}\r\n\r\n\t\t\t.loader-center {\r\n\t\t\t\t-moz-transform: translate(-50" +
            "%, -50%);\r\n\t\t\t\t-ms-transform: translate(-50%, -50%);\r\n\t\t\t\t-o-transform: translat" +
            "e(-50%, -50%);\r\n\t\t\t\t-webkit-transform: translate(-50%, -50%);   \r\n\t\t\t\tleft: 50%;" +
            "\r\n\t\t\t\tdisplay: block;\r\n\t\t\t\tposition: fixed;\r\n\t\t\t\ttop: 50%;\r\n\t\t\t\ttransform: trans" +
            "late(-50%, -55%);\r\n\t\t\t}\r\n\r\n\t\t\t.loader-text {\r\n\t\t\t\tfont-family: \"Segoe UI Light\";" +
            "\r\n\t\t\t\tfont-size: 20px;\r\n\t\t\t\tcolor: white;\r\n\t\t\t\theight: 50%;\r\n\t\t\t\tmargin-top: 20p" +
            "x;\r\n\t\t\t\tpadding-left: 0px;\r\n\t\t\t\tmargin-left: 55px;\r\n\t\t\t}\r\n\t\t</style>\r\n\t</head>\r\n" +
            "\t<body>\r\n\t\t<div id=\"loadingOverlay\" class=\"loader-overlay\">\r\n\t\t\t<div class=\"load" +
            "er-content loader-center\">\r\n\t\t\t\t<div class=\"loader-center\">\r\n\t\t\t\t<div id=\"preloa" +
            "der_1\">\r\n\t\t\t\t\t<span></span>\r\n\t\t\t\t\t<span></span>\r\n\t\t\t\t\t<span></span>\r\n\t\t\t\t\t<span>" +
            "</span>\r\n\t\t\t\t\t<span></span>\r\n\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t\t<div class=\"loader-cent" +
            "er loader-text\">")]
        public string LoaderHtmlPart1 {
            get {
                return ((string)(this["LoaderHtmlPart1"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t<body>\r\n</html>")]
        public string LoaderHtmlPart2 {
            get {
                return ((string)(this["LoaderHtmlPart2"]));
            }
            set {
                this["LoaderHtmlPart2"] = value;
            }
        }
    }
}
