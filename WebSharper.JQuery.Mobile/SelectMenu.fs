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

/// See Components / Form Elements / Select menus.
module WebSharper.JQuery.Mobile.SelectMenu

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let SelectMenuConfig =
    Pattern.ConfigObs "SelectMenuConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "closeText", T<string>
                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "dividerTheme", Common.SwatchLetter.Type
                "hidePlaceholderMenuItems", T<bool>
                "icon", Common.Icon.Type
                "iconpos", Common.IconPosition.Type
                "inline", T<bool>
                "mini", T<bool>
                "nativeMenu", T<bool>
                "overlayTheme", Common.SwatchLetter.Type
                "preventFocusZoom", T<bool>
                "shadow", T<bool>
                "theme", Common.SwatchLetter.Type
            ]
        Obsolete =
            [
                "initSelector", T<string>
                "iconshadow", T<bool>
            ]
    }

let SelectMenu =
    let p = Common.Plugin("selectmenu")
    Class "SelectMenu"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(SelectMenuConfig.Type)
            p.DefineMethod("close")
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("open")
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
            p.DefineMethod("refresh")
            p.DefineMethod("refresh", T<bool>)
        ]
