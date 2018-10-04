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

/// See API / Widgets / Filterable.
module WebSharper.JQuery.Mobile.Filterable

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let FilterableConfig =
    Pattern.ConfigObs "FilterableConfig" {
        Required = []
        Optional =
            [
                "beforefilter", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "filter", T<Events.JEvent * JQuery -> unit>

                "children", T<obj>
                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "filterCallback", T<int * string -> bool>
                "filterReveal", T<bool>
                "input", T<obj>
            ]
        Obsolete =
            [
                "filterPlaceholder", T<string>
                "filterTheme", T<string>
            ]
    }

let Filterable =
    let p = Common.Plugin("filterable")
    Class "Filterable"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(FilterableConfig.Type)
            
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
            p.DefineMethod("refresh")

            Events.DefineTyped "filterablebeforefilter" T<obj> |> WithSourceName "BeforeFiltered"
            Events.DefineTyped "filterablefilter" T<obj> |> WithSourceName "Filtered"
        ]
