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
module WebSharper.JQuery.Mobile.Tabs

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let TabsConfig =
    Pattern.Config "TabsConfig" {
        Required = []
        Optional =
            [
                "activate", T<Events.JEvent * JQuery -> unit>
                "beforeActivate", T<Events.JEvent * JQuery -> unit>
                "beforeLoad", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "load", T<Events.JEvent * JQuery -> unit>

                "active", T<obj>
                "class", T<obj>
                "collapsible", T<bool>
                "disabled", T<bool>
                "event", T<string>
                "heightStyle", T<string>
                "hide", T<obj>
                "show", T<obj>
            ]
    }

let Tabs =
    let p = Common.Plugin("tabs")
    Class "Tabs"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(TabsConfig.Type)

            Events.Define "collapse"
            |> WithSourceName "Collapse"
            Events.Define "expand"
            |> WithSourceName "Expande"

            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("disable", T<int> + T<string>)
            p.DefineMethod("enable")
            p.DefineMethod("enable", T<int> + T<string>)
            p.DefineFunc("instance", T<obj>)
            p.DefineMethod("load", T<obj> + T<string> + T<int>)
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
            p.DefineMethod("refresh")
            p.DefineMethod("widget")

        ]
