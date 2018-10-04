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

/// See Components / Pages & Dialogs / Popup.
module WebSharper.JQuery.Mobile.Popup

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let PopupConfig =
    Pattern.ConfigObs "PopupConfig" {
        Required = []
        Optional =
            [
                "afterclose", T<Events.JEvent * JQuery -> unit>
                "afteropen", T<Events.JEvent * JQuery -> unit>
                "beforeposition", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>

                "arrow", T<obj>
                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "dismissible", T<bool>
                "history", T<bool>
                "overlayTheme", Common.SwatchLetter.Type
                "positionTo", Common.Positioning.Type
                "shadow", T<bool>
                "theme", Common.SwatchLetter.Type
                "tolerance", Common.Tolerance.Type
                "transition", Common.Transition.Type
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let PopupOpenConfig =
    Pattern.Config "PopupOpenConfig" {
        Required = []
        Optional =
            [
                "x", T<int>
                "y", T<int>
                "transition", Common.Transition.Type
                "positionTo", Common.Positioning.Type
            ]
    }

let Popup =
    let p = Common.Plugin("popup")

    Class "Popup"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(PopupConfig.Type)

            p.DefineMethod("close")
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("open")
            p.DefineMethod("open", PopupOpenConfig.Type)
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
            p.DefineMethod("reposition", T<obj>)

            Events.Define "popupbeforeposition"
            |> WithSourceName "BeforePosition"

            Events.Define "popupafteropen"
            |> WithSourceName "AfterOpen"

            Events.Define "popupafterclose"
            |> WithSourceName "AfterClose"
        ]
