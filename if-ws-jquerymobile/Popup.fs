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

/// See Components / Pages & Dialogs / Popup.
module IntelliFactory.WebSharper.JQuery.Mobile.Popup

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let PopupConfig =
    Pattern.Config "PopupConfig" {
        Required = []
        Optional =
            [
                "corners", T<bool>
                "initSelector", T<string>
                "overlayTheme", T<string>
                "positionTo", Common.Positioning.Type
                "shadow", T<bool>
                "theme", T<string>
                "tolerance", Common.Tolerance.Type
                "transition", Common.Transition.Type
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

            p.DefineMethod("open")
            p.DefineMethod("open", PopupOpenConfig.Type)
            p.DefineMethod("close")

            Events.Define "popupbeforeposition"
            |> WithSourceName "BeforePosition"

            Events.Define "popupafteropen"
            |> WithSourceName "AfterOpen"

            Events.Define "popupafterclose"
            |> WithSourceName "AfterClose"
        ]
