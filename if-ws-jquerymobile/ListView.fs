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

                "countTheme", Common.SwatchLetter.Type
                "dividerTheme", Common.SwatchLetter.Type
                "filter", T<bool>
                "filterCallback", T<unit -> unit>
                "filterPlaceholder", T<string>
                "filterTheme", Common.SwatchLetter.Type
                "headerTheme", Common.SwatchLetter.Type
                "icon", Common.Icon.Type
                "initSelector", T<string>
                "inset", T<bool>
                "splitIcon", Common.Icon.Type
                "splitTheme", Common.SwatchLetter.Type
                "theme", Common.SwatchLetter.Type
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
