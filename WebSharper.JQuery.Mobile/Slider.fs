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
module WebSharper.JQuery.Mobile.Slider

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let SliderConfig =
    Pattern.ConfigObs "SliderConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>
                "start", T<Events.JEvent * JQuery -> unit>
                "stop", T<Events.JEvent * JQuery -> unit>

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

let Slider =
    let p = Common.Plugin("slider")
    Class "Slider"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(SliderConfig.Type)
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
            p.DefineMethod("refresh")

            Events.Define "slidestart"
            |> WithSourceName "Started"

            Events.Define "slidestop"
            |> WithSourceName "Stopped"
        ]      
