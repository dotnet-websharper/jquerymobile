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

/// See Widgets / Rangeslider.
module IntelliFactory.WebSharper.JQuery.Mobile.RangeSlider

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let RangeSliderConfig =
    Pattern.Config "RangeSliderConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>
                "normalize", T<Events.JEvent * JQuery -> unit>

                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "highlight", T<bool>
                "initSelector", T<string>
                "mini", T<bool>
                "theme", Common.SwatchLetter.Type
                "trackTheme", Common.SwatchLetter.Type
            ]
    }
    |> Obsolete

let RangeSlider =
    let p = Common.Plugin("rangeslider")
    Class "RangeSlider"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(RangeSliderConfig.Type)
            
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineMethod("refresh")

            Events.Define "normalize"
            |> WithSourceName "Normalize"
        ]
    |> Obsolete
