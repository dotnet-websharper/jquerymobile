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

/// See Components / Content Formatting / Collapsible content blocks.
module IntelliFactory.WebSharper.JQuery.Mobile.Collapsible

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let CollapsibleConfig =
    Pattern.Config "CollapsibleConfig" {
        Required = []
        Optional =
            [
                "collapse", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "expand", T<Events.JEvent * JQuery -> unit>

                "collapseCueText", T<string>
                "collapsed", T<bool>
                "collapsedIcon", Common.Icon.Type
                "corners", T<bool>
                "expandCueText", T<string>
                "expandedIcon", Common.Icon.Type
                "heading", T<string>
                "iconpos", Common.IconPosition.Type
                "initSelector", T<string>
                "inset", T<bool>
                "mini", T<bool>
                "theme", Common.SwatchLetter.Type
            ]
    }

let Collapsible =
    let p = Common.Plugin("collapsible")
    Class "Collapsible"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(CollapsibleConfig.Type)

            Events.Define "collapse"
            |> WithSourceName "Collapse"

            Events.Define "expand"
            |> WithSourceName "Expande"
        ]
