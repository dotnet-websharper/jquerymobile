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
                "create", T<Events.JEvent * JQuery -> unit>
                "start", T<Events.JEvent * JQuery -> unit>
                "stop", T<Events.JEvent * JQuery -> unit>

                "defaults", T<bool>
                "disabled", T<bool>
                "highlight", T<bool>
                "initSelector", T<string>
                "mini", T<bool>
                "theme", Common.SwatchLetter.Type
                "trackTheme", Common.SwatchLetter.Type
            ]
    }
    |> Obsolete

let Slider =
    let p = Common.Plugin("slider")
    Class "Slider"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(SliderConfig.Type)
            p.DefineMethod("enable")
            p.DefineMethod("disable")
            p.DefineMethod("refresh")

            Events.Define "start"
            |> WithSourceName "Started"

            Events.Define "stop"
            |> WithSourceName "Stopped"
        ]        
    |> Obsolete
