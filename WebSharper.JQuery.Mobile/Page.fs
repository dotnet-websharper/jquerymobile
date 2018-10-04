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

/// See API / Events / Page events.
module WebSharper.JQuery.Mobile.Page

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let PageConfig =
    Pattern.ConfigObs "PageConfig" {
        Required = []
        Optional =
            [
                "beforecreate", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>

                "closeBtn", Common.ButtonPosition.Type
                "closeBtnText", T<string>
                "corners", T<bool>
                "defaults", T<bool>
                "dialog", T<bool>
                "disabled", T<bool>
                "domCache", T<bool>
                "overlayTheme", Common.SwatchLetter.Type
                "theme", Common.SwatchLetter.Type
            ]
        Obsolete =
            [
                "contentTheme", Common.SwatchLetter.Type
                "initSelector", T<string>
                "keepNative", T<string>
                "keepNativeDefault", T<string>
            ]
    }


let Page =
    let p = Common.Plugin("page")
    Class "Page"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(PageConfig.Type)

            p.DefineMethod("bindRemove", T<unit -> unit>)
            p.DefineFunc("keepNativeSelector", T<string>) |> Obsolete
            p.DefineMethod("removeContainerBackground") |> Obsolete 
            p.DefineMethod("setContainerBackground", Common.SwatchLetter.Type) |> Obsolete

            Events.Define "pagebeforecreate"
            |> WithSourceName "BeforeCreated"
        ]
