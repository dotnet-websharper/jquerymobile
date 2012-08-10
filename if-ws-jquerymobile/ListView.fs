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

/// See Components / Listviews / Lists basics & API.
module IntelliFactory.WebSharper.JQuery.Mobile.ListView

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let ListViewConfig =
    Pattern.Config "ListViewConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "countTheme", T<string>
                "dividerTheme", T<string>
                "filter", T<bool>
                "filterCallback", T<unit->unit>
                "filterPlaceholder", T<string>
                "filterTheme", T<string>
                "headerTheme", T<string>
                "initSelector", T<string>
                "inset", T<bool>
                "splitIcon", Common.Icon.Type
                "splitTheme", T<string>
                "theme", T<string>
            ]
    }

let ListView =
    let p = Common.Plugin("listview")
    Class "ListView"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(ListViewConfig.Type)
            p.DefineFunc("childPages", T<JQuery>)
            p.DefineMethod("refresh")
        ]
