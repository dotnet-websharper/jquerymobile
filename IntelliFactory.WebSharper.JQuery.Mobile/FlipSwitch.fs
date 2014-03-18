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
module IntelliFactory.WebSharper.JQuery.Mobile.FlipSwitch

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let FlipSwitchConfig =
    Pattern.Config "FlipSwitchConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "mini", T<bool>
                "offText", T<string>
                "onText", T<string>
                "theme", T<string>
                "wrapperClass", T<string>
            ]
    }

let FlipSwitch =
    let p = Common.Plugin("flipswitch")
    Class "FlipSwitch"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(FlipSwitchConfig.Type)
            
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineMethod("refresh")
        ]
