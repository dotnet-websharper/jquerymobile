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
module IntelliFactory.WebSharper.JQuery.Mobile.Accordion

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let AccordionConfig =
    Pattern.Config "AccordionConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "collapsedIcon", Common.Icon.Type
                "expandedIcon", Common.Icon.Type
                "iconpos", Common.IconPosition.Type
                "initSelector", T<string>
                "inset", T<bool>
                "mini", T<bool>
                "theme", T<string>
            ]
    }

let Accordion =
    let p = Common.Plugin("accordion")
    Class "Accordion"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(AccordionConfig.Type)
            p.DefineMethod("refresh")
        ]
