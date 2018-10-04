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

/// See Components / Pages & Dialogs / Dialogs.
module WebSharper.JQuery.Mobile.Dialog

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let DialogConfig =
    Pattern.ConfigObs "DialogConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "closeBtn", Common.ButtonPosition.Type
                "closeBtnText", T<string>
                "corners", T<bool>
                "defaults", T<bool>
                "disabled", T<bool>
                "overlayTheme", Common.SwatchLetter.Type
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }
    |> Obsolete

let Dialog =
    let p = Common.Plugin("dialog")
    Class "Dialog"
    |+> Static [
            p.DefineConstructor()
            p.DefineMethod("close")
        ]
    |> Obsolete
