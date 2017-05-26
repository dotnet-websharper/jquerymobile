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
module WebSharper.JQuery.Mobile.Collapsible

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let CollapsibleConfig =
    Pattern.ConfigObs "CollapsibleConfig" {
        Required = []
        Optional =
            [
                "collapse", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "expand", T<Events.JEvent * JQuery -> unit>

                "collapseCueText", T<string>
                "collapsed", T<bool>
                "collapsedIcon", Common.Icon.Type
                "contentTheme", T<string>
                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "expandCueText", T<string>
                "expandedIcon", Common.Icon.Type
                "heading", T<string>
                "iconpos", Common.IconPosition.Type
                "inset", T<bool>
                "mini", T<bool>
                "theme", Common.SwatchLetter.Type
            ]
        Obsolete = 
            [
                "initSelector", T<string>
            ]
    }

let Collapsible =
    let p = Common.Plugin("collapsible")
    Class "Collapsible"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(CollapsibleConfig.Type)

            Events.DefineTyped "collapsiblecollapse" T<obj>
            |> WithSourceName "Collapse"
            Events.DefineTyped "collapsibleexpand" T<obj>
            |> WithSourceName "Expand"


            p.DefineMethod("collapse")
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
        ]
