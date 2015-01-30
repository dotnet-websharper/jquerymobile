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

/// See Widgets / Table
module IntelliFactory.WebSharper.JQuery.Mobile.Table

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let TableConfig =
    Pattern.ConfigObs "TableConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

//                "classes.table", T<string>
                "defaults", T<bool>
                "disabled", T<bool>
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let Table =
    let p = Common.Plugin("table")
    Class "Table"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(TableConfig.Type)
        ]
