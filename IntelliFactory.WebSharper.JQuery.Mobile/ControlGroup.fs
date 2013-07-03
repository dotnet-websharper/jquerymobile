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
module IntelliFactory.WebSharper.JQuery.Mobile.ControlGroup

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let ControlGroupConfig =
    Pattern.Config "ControlGroupConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "corners", T<bool>
                "excludeInvisible", T<bool>
                "initSelector", T<string>
                "mini", T<bool>
                "shadow", T<bool>
                "type", Common.ControlGroupType.Type
            ]
    }

let ControlGroup =
    let p = Common.Plugin("controlgroup")
    Class "ControlGroup"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(ControlGroupConfig.Type)

            p.DefineFunc("container", T<JQuery>)
        ]