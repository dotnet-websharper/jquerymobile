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
module WebSharper.JQuery.Mobile.Loader

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let LoaderConfig =
    Pattern.Config "LoaderConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "defaults", T<bool>
                "disabled", T<bool>
                "html", T<bool>
                "text", T<string>
                "textVisible", T<bool>
                "textonly", T<bool>
                "theme", Common.SwatchLetter.Type
            ]
    }

let Loader =
    let p = Common.Plugin("loader")  
    Class "Loader"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(LoaderConfig.Type)
            
            p.DefineMethod("checkLoaderPosition")
            p.DefineMethod("fakeFixLoader")
            p.DefineMethod("hide")
            p.DefineMethod("loading")
            p.DefineMethod("resetHtml")
            p.DefineMethod("show")
        ]
