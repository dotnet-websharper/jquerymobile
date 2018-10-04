// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

/// See API / Widgets / PageContainer
module WebSharper.JQuery.Mobile.PageContainer

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let PageContainerConfig =
    Pattern.Config "PageContainerConfig" {
        Required = []
        Optional =
            [
                "beforehide", T<Events.JEvent * JQuery -> unit>
                "beforeload", T<Events.JEvent * JQuery -> unit>
                "beforeshow", T<Events.JEvent * JQuery -> unit>
                "beforetransition", T<Events.JEvent * JQuery -> unit>
                "changefailed", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "hide", T<Events.JEvent * JQuery -> unit>
                "load", T<Events.JEvent * JQuery -> unit>
                "loadfailed", T<Events.JEvent * JQuery -> unit>
                "show", T<Events.JEvent * JQuery -> unit>
                "transition", T<Events.JEvent * JQuery -> unit>

                "defaults", T<bool>
                "disabled", T<bool>
                "theme", Common.SwatchLetter.Type
            ]
    }

let PageLoadConfig =
    Pattern.ConfigObs "PageLoadConfig" {
        Required = []
        Optional =
            [
                "data", T<obj> + T<string>
                "loadMsgDelay", T<int>
                "pageContainer", T<JQuery>
                "role", T<string>
                "reload", T<bool>
                "showLoadMsg", T<bool>
                "type", T<string>
            ]
        Obsolete =
            [
                "reloadPage", T<bool>
            ]
    }

let PageChangeConfig =
    Pattern.ConfigObs "ChangePageConfig" {
        Required = []
        Optional =
            [
                "allowSamePageTransition", T<bool>
                "changeHash", T<bool>
                "data", T<obj>
                "dataUrl", T<string>
                "loadMsgDelay", T<int>
                "reload", T<bool>
                "reverse", T<bool>
                "role", T<string>
                "showLoadMsg", T<bool>
                "transition", T<string>
                "type", T<string>
            ]
        Obsolete =
            [
                "reloadPage", T<bool>
            ]
    }

let PageContainer =
    let p = Common.Plugin("pagecontainer")  
    Class "PageContainer"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(PageContainerConfig.Type)

            p.DefineMethod("change", T<string> + T<JQuery>, PageChangeConfig.Type)
            p.DefineFunc("getActivePage", T<JQuery>)
            p.DefineFunc("load", T<string>, PageLoadConfig.Type, T<Promise>)
        ]
