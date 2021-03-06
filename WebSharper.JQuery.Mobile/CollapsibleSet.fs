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

/// See Components / Content Formatting / Collapsible sets (accordions).
module WebSharper.JQuery.Mobile.CollapsibleSet

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let CollapsibleSetConfig =
    Pattern.ConfigObs "CollapsibleSetConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "collapsedIcon", Common.Icon.Type
                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "expandedIcon", Common.Icon.Type
                "iconpos", Common.IconPosition.Type
                "inset", T<bool>
                "mini", T<bool>
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let CollapsibleSet =
    let p = Common.Plugin("collapsible-set")
    Class "Accordion"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(CollapsibleSetConfig.Type)

            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
            p.DefineMethod("refresh")
        ]
