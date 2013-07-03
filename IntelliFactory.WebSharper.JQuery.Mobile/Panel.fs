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
module IntelliFactory.WebSharper.JQuery.Mobile.Panel

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let PanelConfig =
    Pattern.Config "PanelConfig" {
        Required = []
        Optional =
            [
                "beforeclose", T<Events.JEvent * JQuery -> unit>
                "beforeopen", T<Events.JEvent * JQuery -> unit>
                "close", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "open", T<Events.JEvent * JQuery -> unit>
                
                "animate", T<bool>
//                "classes.animate", T<string>
//                "classes.contentFixedToolbar", T<string>
//                "classes.contentFixedToolbarClosed", T<string>
//                "classes.contentFixedToolbarOpen", T<string>
//                "classes.contentWrap", T<string>
//                "classes.contentWrapClosed", T<string>
//                "classes.contentWrapOpen", T<string>
//                "classes.modal", T<string>
//                "classes.modalOpen", T<string>
//                "classes.pagePanel", T<string>
//                "classes.pagePanelOpen", T<string>
//                "classes.panel", T<string>
//                "classes.panelClosed", T<string>
//                "classes.panelFixed", T<string>
//                "classes.panelInner", T<string>
//                "classes.panelOpen", T<string>
                "dismissible", T<bool>
                "display", T<string>
                "initSelector", T<string>
                "position", Common.PanelPosition.Type
                "positionFixed", T<bool>
                "swipeClose", T<string>
                "theme", Common.SwatchLetter.Type
            ]
    }

let Panel =
    let p = Common.Plugin("panel")   
    Class "Panel"
    |+> [
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
