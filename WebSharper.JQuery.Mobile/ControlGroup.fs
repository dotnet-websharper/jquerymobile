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

/// See Widgets / Controlgroup
module WebSharper.JQuery.Mobile.ControlGroup

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let ControlGroupConfig =
    Pattern.ConfigObs "ControlGroupConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "excludeInvisible", T<bool>
                "mini", T<bool>
                "shadow", T<bool>
                "theme", Common.SwatchLetter.Type
                "type", Common.ControlGroupType.Type
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let ControlGroup =
    let p = Common.Plugin("controlgroup")
    Class "ControlGroup"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(ControlGroupConfig.Type)

            p.DefineFunc("container", T<JQuery>)
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
        ]
