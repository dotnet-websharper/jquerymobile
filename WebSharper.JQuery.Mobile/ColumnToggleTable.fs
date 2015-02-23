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
module WebSharper.JQuery.Mobile.ColumnToggleTable

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let ColumnToggleTableConfig =
    Pattern.ConfigObs "ColumnToggleTableConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

//                "classes.columnBtn", T<string>
//                "classes.columnToggleTable", T<string>
//                "classes.popup", T<string>
//                "classes.priorityPrefix", T<string>
                "columnBtnText", T<string>
                "columnBtnTheme", Common.SwatchLetter.Type
                "columnPopupTheme", Common.SwatchLetter.Type
                "enhanced", T<bool>
            ]
        Obsolete =
            [
            ]
    }

let ColumnToggleTable =
    let p = Common.Plugin("table")
    Class "ColumnToggleTable"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(ColumnToggleTableConfig.Type)
            
            p.DefineMethod("refresh")
        ]
