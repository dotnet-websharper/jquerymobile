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
module IntelliFactory.WebSharper.JQuery.Mobile.ReflowTable

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let ReflowTableConfig =
    Pattern.Config "ReflowTableConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

//                "classes.cellLabels", T<string>
//                "classes.reflowTable", T<string>
                "initSelector", T<string>
            ]
    }

let ReflowTable =
    let p = Common.Plugin("table")
    Class "ReflowTable"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(ReflowTableConfig.Type)
            p.DefineMethod("refresh")
        ]
