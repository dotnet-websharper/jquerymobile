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

/// See Components / Content Formatting / Collapsible content blocks.
module WebSharper.JQuery.Mobile.Tabs

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let TabsConfig =
    Pattern.Config "TabsConfig" {
        Required = []
        Optional =
            [
                "activate", T<Events.JEvent * JQuery -> unit>
                "beforeActivate", T<Events.JEvent * JQuery -> unit>
                "beforeLoad", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "load", T<Events.JEvent * JQuery -> unit>

                "active", T<obj>
                "class", T<obj>
                "collapsible", T<bool>
                "disabled", T<bool>
                "event", T<string>
                "heightStyle", T<string>
                "hide", T<obj>
                "show", T<obj>
            ]
    }

let Tabs =
    let p = Common.Plugin("tabs")
    Class "Tabs"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(TabsConfig.Type)

            Events.Define "collapse"
            |> WithSourceName "Collapse"
            Events.Define "expand"
            |> WithSourceName "Expande"

            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("disable", T<int> + T<string>)
            p.DefineMethod("enable")
            p.DefineMethod("enable", T<int> + T<string>)
            p.DefineFunc("instance", T<obj>)
            p.DefineMethod("load", T<obj> + T<string> + T<int>)
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
            p.DefineMethod("refresh")
            p.DefineMethod("widget")

        ]
