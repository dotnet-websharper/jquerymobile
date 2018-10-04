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

/// Common type definitions.
module WebSharper.JQuery.Mobile.Common

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let Positioning =
    Class "Positioning"
    |+> Static [
            "jQuerySelector" => T<string>?s ^-> TSelf
            |> WithInline "$s"
            "origin" =? TSelf
            |> WithGetterInline "'origin'"
            "window" =? TSelf
            |> WithGetterInline "'window'"
        ]

let Relation =
    Pattern.EnumStrings "Relation" [
        "back"
        "dialog"
        "external"
        "popup"
    ]

let Tolerance =
    Class "Tolerance"
    |+> Static [
            "create" => T<int>?top * T<int>?right * T<int>?bottom * T<int>?left ^-> TSelf
            |> WithInline "[$top,$right,$bottom,$left].join(',')"
        ]

let Transition =
    Pattern.EnumStrings "Transition" [
        "fade"         
        "flip"
        "flow"
        "pop"
        "slide"
        "slidedown"
        "slidefade"
        "slideup"
        "turn"
        "none"
    ]

let IconPosition =
    Pattern.EnumStrings "IconPosition" [
        "left"
        "right"
        "top"
        "bottom"
        "none"
        "notext"
    ]

let Icon =
    Pattern.EnumInlines "Icon" [     
        "Action", "'action'"
        "Alert", "'alert'"
        "DownArrow", "'arrow-d'"
        "DownLeftArrow", "'arrow-d-l'"
        "DownRightArrow", "'arrow-d-r'"
        "LeftArrow", "'arrow-l'"
        "RightArrow", "'arrow-r'"
        "UpArrow", "'arrow-u'"
        "UpLeftArrow", "'arrow-u-l'"
        "UpRightArrow", "'arrow-u-r'"
        "Audio", "'audio'"
        "Back", "'back'"
        "Bars", "'bars'"
        "Bullets", "'bullets'"
        "Calendar", "'calendar'"
        "Camera", "'camera'"
        "CaratDown", "'carat-d'"
        "CaratLeft", "'carat-l'"
        "CaratRight", "'carat-r'"
        "CaratUp", "'carat-u'"
        "Check", "'check'"
        "Clock", "'clock'"
        "Cloud", "'cloud'"
        "Comment", "'comment'"
        "Delete", "'delete'"
        "Edit", "'edit'"
        "Eye", "'eye'"
        "Forbidden", "'forbidden'"
        "Forward", "'forward'"
        "Gear", "'gear'"
        "Grid", "'grid'"
        "Heart", "'heart'"
        "Home", "'home'"
        "Info", "'info'"
        "Location", "'location'"
        "Lock", "'lock'"
        "Mail", "'mail'"
        "Minus", "'minus'"
        "Navigation", "'navigation'"
        "Phone", "'phone'"
        "Plus", "'plus'"
        "Power", "'power'"
        "Recycle", "'recycle'"
        "Refresh", "'refresh'"
        "Search", "'search'"
        "Shop", "'shop'"
        "Star", "'star'"
        "Tag", "'tag'"
        "User", "'user'"
        "Video", "'video'"
    ]

let PanelPosition =
    Pattern.EnumStrings "PanelPosition" [
        "left"
        "right"
    ]

let ButtonPosition =
    Pattern.EnumStrings "ButtonPosition" [
        "left"
        "right"
        "none"
    ]

let ControlGroupType = 
    Pattern.EnumStrings "ControlGroupType" [
        "vertical"
        "horizontal"
    ]

let SwatchLetter =
    Pattern.EnumStrings "SwatchLetter"
        (seq { 'a' .. 'z' } |> Seq.map string)

[<Sealed>]
type Plugin(plugin: string) =
    let getSharpName (jsName: string) =
        jsName.Substring(0, 1).ToUpper() +
        jsName.Substring(1)

    member this.DefineConstructor() =
        "Init" => T<JQuery>?j ^-> T<unit>
        |> WithInline (sprintf "$j.%s()" plugin)

    member this.DefineConstructor(config: Type.Type) =
        "Init" => T<JQuery>?j * config?cfg ^-> T<unit>
        |> WithInline (sprintf "$j.%s($cfg)" plugin)

    member this.DefineFunc(jsName, retTy) =
        getSharpName jsName => T<JQuery>?j ^-> retTy
        |> WithInline (sprintf "$j.%s('%s')" plugin jsName)

    member this.DefineFunc(jsName, arg: Type.Type, retTy) =
        getSharpName jsName => T<JQuery>?j * arg?c ^-> retTy
        |> WithInline (sprintf "$j.%s('%s', $c)" plugin jsName)

    member this.DefineFunc(jsName, arg1: Type.Type, arg2: Type.Type, retTy) =
        getSharpName jsName => T<JQuery>?j * arg1?c1 * arg2?c2 ^-> retTy
        |> WithInline (sprintf "$j.%s('%s', $c1, $c2)" plugin jsName)

//    member this.DefineFunc(jsName, sharpName, retTy) =
//        sharpName => T<JQuery>?j ^-> retTy
//        |> WithInline (sprintf "$j.%s('%s')" plugin jsName)

    member this.DefineMethod(jsName: string) =
        getSharpName jsName => T<JQuery>?j ^-> T<unit>
        |> WithInline (sprintf "$j.%s('%s')" plugin jsName)

    member this.DefineMethod(jsName: string, arg: Type.Type) =
        getSharpName jsName => T<JQuery>?j * arg?c ^-> T<unit>
        |> WithInline (sprintf "$j.%s('%s', $c)" plugin jsName)

    member this.DefineMethod(jsName: string, arg1: Type.Type, arg2: Type.Type) =
        getSharpName jsName => T<JQuery>?j * arg1?c1 * arg2?c2 ^-> T<unit>
        |> WithInline (sprintf "$j.%s('%s', $c1, $c2)" plugin jsName)


        //this.DefineMethod(jsName, getSharpName jsName, arg)

//    member this.DefineMethod(jsName, sharpName) =
//        sharpName => T<JQuery>?j ^-> T<unit>
//        |> WithInline (sprintf "$j.%s('%s')" plugin jsName)
//
//    member this.DefineMethod(jsName, sharpName, arg: Type.Type) =
//        sharpName => T<JQuery>?j * arg?c ^-> T<unit>
//        |> WithInline (sprintf "$j.%s('%s', $c)" plugin jsName)

