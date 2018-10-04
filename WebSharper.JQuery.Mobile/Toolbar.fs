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

/// See Components / Toolbars / Fixed positioning.
module WebSharper.JQuery.Mobile.Toolbar

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let ToolbarConfig =
    Pattern.ConfigObs "ToolbarConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>
                
                "addBackBtn", T<bool>
                "backBtnText", T<string>
                "backBtnTheme", Common.SwatchLetter.Type
                "defaults", T<bool>
                "disablePageZoom", T<bool>
                "disabled", T<bool>
                "fullscreen", T<bool>
                "hideDuringFocus", T<string>
                "position", T<string>
                "supportBlacklist", T<unit -> bool>
                "tapToggle", T<bool>
                "tapToggleBlacklist", T<string>
                "theme", Common.SwatchLetter.Type
                "transition", Common.Transition.Type
                "updatePagePadding", T<bool>
                "visibleOnPageShow", T<bool>
            ]
        Obsolete =
            [
                "trackPersistentToolbars", T<bool>
            ]
    }

let Toolbar =
    let p = Common.Plugin("toolbar")
    Class "Toolbar"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(ToolbarConfig.Type)

            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
            p.DefineMethod("refresh")
            p.DefineMethod("show")
            p.DefineMethod("toggle")
            p.DefineMethod("updatePagePadding")
        ]
