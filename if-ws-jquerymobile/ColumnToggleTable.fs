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

/// See Widgets / Column-Toggle Table
module IntelliFactory.WebSharper.JQuery.Mobile.ColumnToggleTable

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let ColumnToggleTableConfig =
    Pattern.Config "ColumnToggleTableConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

//                "classes.columnBtn", T<string>
//                "classes.columnToggleTable", T<string>
//                "classes.popup", T<string>
//                "classes.priorityPrefix", T<string>
                "columnBtnText", T<string>
                "columnBtnTheme", T<string>
                "columnPopupTheme", T<string>
            ]
    }

let ColumnToggleTable =
    let p = Common.Plugin("table")
    Class "ColumnToggleTable"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(ColumnToggleTableConfig.Type)
            p.DefineMethod("refresh")
        ]
