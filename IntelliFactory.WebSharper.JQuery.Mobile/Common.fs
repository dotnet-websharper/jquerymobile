// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2012.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

/// Common type definitions.
module IntelliFactory.WebSharper.JQuery.Mobile.Common

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let Positioning =
    let self = Type.New()
    Class "Positioning"
    |=> self
    |+> Static [
            "jQuerySelector" => T<string>?s ^-> self
            |> WithInline "$s"
            "origin" =? self
            |> WithGetterInline "'origin'"
            "window" =? self
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
    let self = Type.New()
    Class "Tolerance"
    |=> self
    |+> Static [
            "create" => T<int>?top * T<int>?right * T<int>?bottom * T<int>?left ^-> self
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

