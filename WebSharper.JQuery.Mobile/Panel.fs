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

/// See API / Widgets / Panel
module WebSharper.JQuery.Mobile.Panel

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let Cl =
    Pattern.Config "PanelClasses" {
        Required = []
        Optional =
            [
                "animate", T<string>
                "modal", T<string>
                "modalOpen", T<string>
                "pageContainer", T<string>
                "pageContentPrefix", T<string>
                "pageFixedToolbar", T<string>
                "panel", T<string>
                "panelClosed", T<string>
                "panelFixed", T<string>
                "panelInner", T<string>
                "panelOpen", T<string>
            ]
    }

let PanelConfig =
    Pattern.ConfigObs "PanelConfig" {
        Required = []
        Optional =
            [
                "beforeclose", T<Events.JEvent * JQuery -> unit>
                "beforeopen", T<Events.JEvent * JQuery -> unit>
                "close", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "open", T<Events.JEvent * JQuery -> unit>
                
                "animate", T<bool>
                "classes", Cl.Type
                "defaults", T<bool>
                "disabled", T<bool>
                "dismissible", T<bool>
                "display", T<string>
                "position", Common.PanelPosition.Type
                "positionFixed", T<bool>
                "swipeClose", T<string>
                "theme", Common.SwatchLetter.Type
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let Panel =
    let p = Common.Plugin("panel")   
    Class "Panel"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(PanelConfig.Type)

            p.DefineMethod("close")
            p.DefineMethod("open")
            p.DefineMethod("toggle")

            Events.Define "beforeclose"
            |> WithSourceName "BeforeClose"

            Events.Define "beforeopen"
            |> WithSourceName "BeforeOpene"

            Events.Define "close"
            |> WithSourceName "Closed"

            Events.Define "open"
            |> WithSourceName "Opened"
        ]
