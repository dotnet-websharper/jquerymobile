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

/// See API / Widgets / Filterable.
module WebSharper.JQuery.Mobile.Filterable

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let FilterableConfig =
    Pattern.ConfigObs "FilterableConfig" {
        Required = []
        Optional =
            [
                "beforefilter", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "filter", T<Events.JEvent * JQuery -> unit>

                "children", T<obj>
                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "filterCallback", T<int * string -> bool>
                "filterReveal", T<bool>
                "input", T<obj>
            ]
        Obsolete =
            [
                "filterPlaceholder", T<string>
                "filterTheme", T<string>
            ]
    }

let Filterable =
    let p = Common.Plugin("filterable")
    Class "Filterable"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(FilterableConfig.Type)
            
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineMethod("refresh")

            Events.Define "beforefilter" |> WithSourceName "BeforeFiltered"
            Events.Define "filter" |> WithSourceName "Filtered"
        ]
