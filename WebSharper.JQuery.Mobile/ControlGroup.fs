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

/// See Widgets / Controlgroup
module WebSharper.JQuery.Mobile.ControlGroup

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let ControlGroupConfig =
    Pattern.ConfigObs "ControlGroupConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "excludeInvisible", T<bool>
                "mini", T<bool>
                "shadow", T<bool>
                "theme", Common.SwatchLetter.Type
                "type", Common.ControlGroupType.Type
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let ControlGroup =
    let p = Common.Plugin("controlgroup")
    Class "ControlGroup"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(ControlGroupConfig.Type)

            p.DefineFunc("container", T<JQuery>)
            p.DefineMethod("destroy")
            p.DefineMethod("disable")
            p.DefineMethod("enable")
            p.DefineMethod("option", T<string>)
            p.DefineFunc("option", T<obj>)
            p.DefineMethod("option", T<string>, T<obj>)
            p.DefineMethod("option", T<obj>)
        ]
