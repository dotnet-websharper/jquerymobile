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
module WebSharper.JQuery.Mobile.ReflowTable

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let CL =
    Pattern.Config "RefTabClasses" {
        Required = []
        Optional =
            [
                "cellLabels", T<string>
                "reflowTable", T<string>
            ]
    }

let ReflowTableConfig =
    Pattern.Config "ReflowTableConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "classes", CL.Type
                "initSelector", T<string>
            ]
    }

let ReflowTable =
    let p = Common.Plugin("table")
    Class "ReflowTable"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(ReflowTableConfig.Type)

            p.DefineMethod("refresh")
        ]
