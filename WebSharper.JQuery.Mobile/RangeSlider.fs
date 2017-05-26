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
module WebSharper.JQuery.Mobile.RangeSlider

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let RangeSliderConfig =
    Pattern.ConfigObs "RangeSliderConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>
                "normalize", T<Events.JEvent * JQuery -> unit>

                "defaults", T<bool>
                "disabled", T<bool>
                "highlight", T<bool>
                "mini", T<bool>
                "theme", Common.SwatchLetter.Type
                "trackTheme", Common.SwatchLetter.Type
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

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
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
            p.DefineMethod("refresh")

            Events.Define "rangeslidernormalize"
            |> WithSourceName "Normalize"
        ]
