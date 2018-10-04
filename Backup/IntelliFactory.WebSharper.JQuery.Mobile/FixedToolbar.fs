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
module IntelliFactory.WebSharper.JQuery.Mobile.FixedToolbar

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let FixedToolbarConfig =
    Pattern.Config "FixedToolbarConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>
                
                "disablePageZoom", T<bool>
                "fullscreen", T<bool>
                "hideDuringFocus", T<string>
                "initSelector", T<string>
                "supportBlacklist", T<unit -> bool>
                "tapToggle", T<bool>
                "tapToggleBlacklist", T<string>
                "transition", Common.Transition.Type
                "updatePagePadding", T<bool>
                "visibleOnPageShow", T<bool>
            ]
    }

let FixedToolbar =
    let p = Common.Plugin("fixedtoolbar")
    Class "FixedToolbar"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(FixedToolbarConfig.Type)
            p.DefineMethod("destroy")
            p.DefineMethod("hide")
            p.DefineMethod("show")
            p.DefineMethod("toggle")
            p.DefineMethod("updatePagePadding")
        ]
