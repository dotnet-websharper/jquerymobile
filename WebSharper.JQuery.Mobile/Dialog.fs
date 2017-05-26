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

/// See Components / Pages & Dialogs / Dialogs.
module WebSharper.JQuery.Mobile.Dialog

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let DialogConfig =
    Pattern.ConfigObs "DialogConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "closeBtn", Common.ButtonPosition.Type
                "closeBtnText", T<string>
                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "overlayTheme", Common.SwatchLetter.Type
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }
    |> Obsolete

let Dialog =
    let p = Common.Plugin("dialog")
    Class "Dialog"
    |+> Static [
            p.DefineConstructor()
            p.DefineMethod("close")
        ]
    |> Obsolete
