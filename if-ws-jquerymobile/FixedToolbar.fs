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

/// See Components / Toolbars / Fixed positioning.
module IntelliFactory.WebSharper.JQuery.Mobile.FixedToolbar

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let FixedToolbarConfig =
    Pattern.Config "FixedToolbarConfig" {
        Required = []
        Optional =
            [
                "create", (T<Events.JEvent> * T<JQuery> ^-> T<unit>)
                "disablePageZoom", T<bool>
                "fullscreen", T<bool>
                "hideDuringFocus", T<bool>
                "initSelector", T<string>
                "supportBlacklist", T<unit->bool>
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
