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
module IntelliFactory.WebSharper.JQuery.Mobile.Dialog

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let DialogConfig =
    Pattern.Config "DialogConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "closeBtn", Common.ButtonPosition.Type
                "closeBtnText", T<string>
                "corners", T<bool>
                "initSelector", T<string>
                "overlayTheme", Common.SwatchLetter.Type
            ]
    }

let Dialog =
    let p = Common.Plugin("dialog")
    Class "Dialog"
    |+> [
            p.DefineConstructor()
            p.DefineMethod("close")
        ]
