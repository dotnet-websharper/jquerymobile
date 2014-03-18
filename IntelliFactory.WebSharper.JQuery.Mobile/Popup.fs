﻿// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2012.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

/// See Components / Pages & Dialogs / Popup.
module IntelliFactory.WebSharper.JQuery.Mobile.Popup

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

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
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(PopupConfig.Type)

            p.DefineMethod("close")
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("open")
            p.DefineMethod("open", PopupOpenConfig.Type)
            p.DefineMethod("reposition", T<obj>)

            Events.Define "beforeposition"
            |> WithSourceName "BeforePosition"

            Events.Define "afteropen"
            |> WithSourceName "AfterOpen"

            Events.Define "afterclose"
            |> WithSourceName "AfterClose"
        ]
