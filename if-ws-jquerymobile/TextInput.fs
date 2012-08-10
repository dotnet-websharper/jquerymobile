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
    Pattern.Config "TextInputConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "clearSearchButtonText", T<string>
                "disabled", T<bool>
                "initSelector", T<string>
                "mini", T<bool>
                "preventFocusZoom", T<bool>
                "theme", T<string>
            ]
    }

let TextInput =
    let p = Common.Plugin("textinput")
    Class "TextInput"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(TextInputConfig.Type)
            p.DefineMethod("disable")
            p.DefineMethod("enable")
        ]
