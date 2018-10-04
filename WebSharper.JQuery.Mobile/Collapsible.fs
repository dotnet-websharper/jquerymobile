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
module WebSharper.JQuery.Mobile.Collapsible

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let CollapsibleConfig =
    Pattern.ConfigObs "CollapsibleConfig" {
        Required = []
        Optional =
            [
                "collapse", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "expand", T<Events.JEvent * JQuery -> unit>

                "collapseCueText", T<string>
                "collapsed", T<bool>
                "collapsedIcon", Common.Icon.Type
                "contentTheme", T<string>
                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "enhanced", T<bool>
                "expandCueText", T<string>
                "expandedIcon", Common.Icon.Type
                "heading", T<string>
                "iconpos", Common.IconPosition.Type
                "inset", T<bool>
                "mini", T<bool>
                "theme", Common.SwatchLetter.Type
            ]
        Obsolete = 
            [
                "initSelector", T<string>
            ]
    }

let Collapsible =
    let p = Common.Plugin("collapsible")
    Class "Collapsible"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(CollapsibleConfig.Type)

            Events.DefineTyped "collapsiblecollapse" T<obj>
            |> WithSourceName "Collapse"
            Events.DefineTyped "collapsibleexpand" T<obj>
            |> WithSourceName "Expand"


            p.DefineMethod("collapse")
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
        ]
