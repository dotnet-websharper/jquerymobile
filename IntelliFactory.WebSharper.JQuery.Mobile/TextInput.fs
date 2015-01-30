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

/// See Components / Form Elements / Text inputs.
module IntelliFactory.WebSharper.JQuery.Mobile.TextInput

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let TextInputConfig =
    Pattern.ConfigObs "TextInputConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "autogrow", T<bool>
                "clearBtn", T<bool>
                "clearBtnText", T<string>
                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "keyupTimeoutBuffer", T<int>
                "mini", T<bool>
                "preventFocusZoom", T<string>
                "theme", Common.SwatchLetter.Type
                "wrapperClass", T<string>
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let TextInput =
    let p = Common.Plugin("textinput")
    Class "TextInput"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(TextInputConfig.Type)
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineMethod("refresh")
        ]
