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
module IntelliFactory.WebSharper.JQuery.Mobile.Toolbar

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

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
            p.DefineMethod("refresh")
            p.DefineMethod("updatePagePadding")
        ]
