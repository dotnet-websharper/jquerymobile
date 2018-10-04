// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

/// See Widgets / Table
module WebSharper.JQuery.Mobile.Table

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let CL = 
    Pattern.Config "TableClasses" {
        Required = []
        Optional =
            [
                "table", T<string>
            ]
    }

let TableConfig =
    Pattern.ConfigObs "TableConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "class", CL.Type
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

            p.DefineMethod("rebuild")
        ]
