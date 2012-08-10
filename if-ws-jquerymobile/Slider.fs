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

/// See Components / Form Elements / Slider.
module IntelliFactory.WebSharper.JQuery.Mobile.Slider

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let SliderConfig =
    Pattern.Config "SliderConfig" {
        Required = []
        Optional =
            [
                "disabled", T<bool>
                "highlight", T<bool>
                "initSelector", T<string>
                "mini", T<string>
                "theme", T<string>
                "trackTheme", T<string>
            ]
    }

let Slider =
    let p = Common.Plugin("slider")
    Class "Slider"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(SliderConfig.Type)

            p.DefineMethod("enable")
            p.DefineMethod("disable")
            p.DefineMethod("refresh")
        ]
