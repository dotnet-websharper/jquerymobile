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
