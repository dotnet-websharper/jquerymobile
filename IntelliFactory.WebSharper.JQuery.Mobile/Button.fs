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

/// See Components / Buttons.
module IntelliFactory.WebSharper.JQuery.Mobile.Button

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let ButtonConfig =
    Pattern.ConfigObs "ButtonConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "corners", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "icon", Common.Icon.Type
                "iconpos", Common.IconPosition.Type
                "inline", T<bool>
                "mini", T<bool>
                "shadow", T<bool>
                "theme", T<string>
                "wrapperClass", T<string>
            ]
        Obsolete =
            [
                "iconshadow", T<bool>
                "initSelector", T<string>
            ]
    }

let Button =
    let p = Common.Plugin("button")
    Class "Button"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(ButtonConfig.Type)
            
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineMethod("refresh")
        ]
