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

/// See Widgets / Column-Toggle Table
module WebSharper.JQuery.Mobile.ColumnToggleTable

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let CL =
    Pattern.Config "CTTClasses" {
        Required = []
        Optional =
            [
                "columnBtn", T<string>
                "columnToggleTable", T<string>
                "popup", T<string>
                "priorityPrefix", T<string>
            ]
    }

let ColumnToggleTableConfig =
    Pattern.ConfigObs "ColumnToggleTableConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "classes", CL.Type
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
