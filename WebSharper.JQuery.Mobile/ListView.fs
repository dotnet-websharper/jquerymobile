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
module WebSharper.JQuery.Mobile.ListView

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let ListViewConfig =
    Pattern.ConfigObs "ListViewConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "autodividers", T<bool>
                "autodividersSelector", T<JQuery -> string>
                "defaults", T<bool>
                "disabled", T<bool>
                "dividerTheme", Common.SwatchLetter.Type
                "hideDividers", T<bool>
                "icon", Common.Icon.Type
                "inset", T<bool>
                "splitIcon", Common.Icon.Type
                "splitTheme", Common.SwatchLetter.Type
                "theme", Common.SwatchLetter.Type
            ]
        Obsolete =
            [
                "countTheme", Common.SwatchLetter.Type
                "filter", T<bool>
                "filterCallback", T<string * string -> bool>
                "filterPlaceholder", T<string>
                "filterReveal", T<string>
                "filterTheme", Common.SwatchLetter.Type
                "initSelector", T<string>
            ]
    }

let ListView =
    let p = Common.Plugin("listview")
    Class "ListView"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(ListViewConfig.Type)
            
            p.DefineMethod("refresh")
        ]
