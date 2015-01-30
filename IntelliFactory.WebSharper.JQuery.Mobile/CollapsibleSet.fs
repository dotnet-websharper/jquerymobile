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

/// See Components / Content Formatting / Collapsible sets (accordions).
module IntelliFactory.WebSharper.JQuery.Mobile.CollapsibleSet

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let CollapsibleSetConfig =
    Pattern.ConfigObs "CollapsibleSetConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "collapsedIcon", Common.Icon.Type
                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "expandedIcon", Common.Icon.Type
                "iconpos", Common.IconPosition.Type
                "inset", T<bool>
                "mini", T<bool>
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let CollapsibleSet =
    let p = Common.Plugin("collapsible-set")
    Class "Accordion"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(CollapsibleSetConfig.Type)

            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineMethod("refresh")
        ]
