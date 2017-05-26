// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2012.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
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
