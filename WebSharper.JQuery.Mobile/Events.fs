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

module WebSharper.JQuery.Mobile.Events

open WebSharper.InterfaceGenerator
open WebSharper.JQuery
type JEvent = WebSharper.JQuery.Event

let Handler0 = T<JEvent>?ev ^-> T<unit>
let Handler1 t = t ^-> T<unit>
let Handler2 t1 t2 = t1 * t2 ^-> T<unit>

let Event0 =
    let h = Handler0
    Class "Event"
    |+> Instance [
            "name" =? T<string>
            |> WithGetterInline "$this"
            "trigger" => T<JQuery>?jQ ^-> T<unit>
            |> WithInline "$jQ.trigger($this, $par)"
            "on" => T<JQuery>?jQ * h?handler ^-> T<unit>
            |> WithInline "$jQ.on($this, $handler)"
            "on" => T<JQuery>?jQ * T<string>?selector * h?handler ^-> T<unit>
            |> WithInline "$jQ.on($this, $selector, $handler)"
            "off" => T<JQuery>?jQ * h?handler ^-> T<unit>
            |> WithInline "$jQ.off($this, $handler)"
            "off" => T<JQuery>?jQ * T<string>?selector * h?handler ^-> T<unit>
            |> WithInline "$jQ.off($this, $selector, $handler)"
        ]

let Event1 =
    Generic - fun t ->
        let h = Handler1 t
        Class "Event`1"
        |+> Instance [
                "name" =? T<string>
                |> WithGetterInline "$this"
                "trigger" => T<JQuery>?jQ * t?par ^-> T<unit>
                |> WithInline "$jQ.trigger($this, $par)"
                "on" => T<JQuery>?jQ * h?handler ^-> T<unit>
                |> WithInline "$jQ.on($this, $handler)"
                "on" => T<JQuery>?jQ * T<string>?selector * h?handler ^-> T<unit>
                |> WithInline "$jQ.on($this, $selector, $handler)"
                "off" => T<JQuery>?jQ * h?handler ^-> T<unit>
                |> WithInline "$jQ.off($this, $handler)"
                "off" => T<JQuery>?jQ * T<string>?selector * h?handler ^-> T<unit>
                |> WithInline "$jQ.off($this, $selector, $handler)"
            ]

let Event2 =
    Generic -- fun t1 t2 ->
        let h = Handler2 t1 t2
        Class "Event`2"
        |+> Instance [
                "name" =? T<string>
                |> WithGetterInline "$this"
                "trigger" => T<JQuery>?jQ * t2?par ^-> T<unit>
                |> WithInline "$jQ.trigger($this, $par)"
                "on" => T<JQuery>?jQ * h?handler ^-> T<unit>
                |> WithInline "$jQ.on($this, $handler)"
                "on" => T<JQuery>?jQ * T<string>?selector * h?handler ^-> T<unit>
                |> WithInline "$jQ.on($this, $selector, $handler)"
                "off" => T<JQuery>?jQ * h?handler ^-> T<unit>
                |> WithInline "$jQ.off($this, $handler)"
                "off" => T<JQuery>?jQ * T<string>?selector * h?handler ^-> T<unit>
                |> WithInline "$jQ.off($this, $selector, $handler)"
            ]

let Define name =
    name =? Event0
     |> WithGetterInline (sprintf @"'%s'" name)

let DefineTyped name (ty: Type.Type) =
    name =? Event1.[ty]
    |> WithGetterInline (sprintf "'%s'" name)

let DefineTyped2 name (ev: Type.Type) (ty: Type.Type) =
    name =? Event2.[ev, ty]
    |> WithGetterInline (sprintf "'%s'" name)
