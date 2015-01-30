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

/// See Components / Form Elements / Radio buttons.
module IntelliFactory.WebSharper.JQuery.Mobile.CheckBoxRadio

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let CheckBoxRadioConfig =
    Pattern.ConfigObs "CheckBoxRadioConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "iconpos", Common.IconPosition.Type
                "mini", T<bool>
                "wrapperClass", T<string>
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let CheckBoxRadio =
    let p = Common.Plugin("checkboxradio")
    Class "CheckBoxRadio"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(CheckBoxRadioConfig.Type)

            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineMethod("refresh")
        ]
