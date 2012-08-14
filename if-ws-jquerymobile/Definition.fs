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

module IntelliFactory.WebSharper.JQuery.Mobile.Definition

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.Dom
open IntelliFactory.WebSharper.JQuery

let ButtonMarkup =
    Class "ButtonMarkup"
    |+> Protocol [
            "hoverDelay" =@ T<int>
        ]

let ChangePageConfig =
    Pattern.Config "ChangePageConfig" {
        Required = []
        Optional =
        [
            "allowSamePageTransition", T<bool>
            "changeHash", T<bool>
            "data", T<obj>
            "dataUrl", T<string>
            "pageContainer", T<JQuery>
            "reloadPage", T<bool>
            "reverse", T<bool>
            "role", T<string>
            "showLoadMsg", T<bool>
            "transition", T<string>
            "type", T<string>
        ]
    }

let LoadingConfig =
    Pattern.Config "LoadingConfig" {
        Required = []
        Optional =
        [
            "html", T<string>
            "theme", T<string>
            "text", T<string>
            "textonly", T<bool>
            "textVisible", T<bool>
        ]
    }

let Special =
    let s c x t =
        x =@ t
        |> WithGetterInline (sprintf "jQuery.event.special.%s.%s" c x)
        |> WithSetterInline (sprintf "jQuery.event.special.%s.%s = $value" c x)
    Class "Special"
    |+> [
            s "tap" "tapholdThreshold" T<int>
            s "swipe" "scrollSupressionThreshold " T<int>
            s "swipe" "durationThreshold" T<int>
            s "swipe" "horizontalDistanceThreshold" T<int>
            s "swipe" "verticalDistanceThreshold" T<int>
            s "vmouse" "moveDistanceThreshold" T<int>
            s "vmouse" "clickDistanceThreshold" T<int>
            s "vmouse" "resetTimerDuration" T<int>
        ]

let Orientation =
    Pattern.EnumStrings "Orientation" ["portrait"; "landscape"]

let OrientationChangeEvent =
    Class "OrientationChangeEvent"
    |+> Protocol [
            "orientation" =? Orientation
        ]

let Events =
    let ev0 name = Events.Define name
    let ev1 name ty = Events.DefineTyped name ty
    Class "Events"
    |+> [
            ev0 "tap"
            ev0 "taphold"
            ev0 "swipe"
            ev0 "swipeleft"
            ev0 "swiperight"
            ev0 "vmouseover"
            ev0 "vmouseout"
            ev0 "vmousedown"
            ev0 "vmousemove"
            ev0 "vmouseup"
            ev0 "vclick"
            ev0 "vmousecancel"
            ev1 "orientationchange" OrientationChangeEvent.Type
            ev0 "scrollstart"
            ev0 "scrollstop"
            ev0 "updatelayout"
        ]

let URL =
    Class "URL"
    |+> Protocol
        [
            "hash" =? T<string>
            "host" =? T<string>
            "hostname" =? T<string>
            "href" =? T<string>
            "pathname" =? T<string>
            "port" =? T<string>
            "protocol" =? T<string>
            "search" =? T<string>
            "authority" =? T<string>
            "directory" =? T<string>
            "domain" =? T<string>
            "filename" =? T<string>
            "hrefNoHash" =? T<string>
            "hrefNoSearch" =? T<string>
            "password" =? T<string>
            "username" =? T<string>
        ]

let Path =
    Class "Path"
    |+> Protocol
        [
            "parseUrl" => T<string> ^-> URL
            "makePathAbsolute" => T<string>?relPath * T<string>?absPath ^-> T<string>
            "makeUrlAbsolute" => T<string>?relUrl * T<string>?absUrl ^-> T<string>
            "isSameDomain" => T<string> * T<string> ^-> T<bool>
            "isRelativeUrl" => T<string> ^-> T<bool>
            "isAbsoluteUrl" => T<string> ^-> T<bool>
            "get" => T<string> ^-> T<string>
        ]

let Mobile =
    let self = Type.New()
    Class "Mobile"
    |=> self
    |+> [
            "Instance" =? self
            |> WithGetterInline "jQuery.mobile"

            "Use" => T<unit->unit>
            |> WithInline "undefined"
        ]
    |+> Protocol
        [

            // Configuration Defaults

            "activeBtnClass" =@ T<string>
            "activePageClass" =@ T<string>
            "ajaxEnabled" =@ T<bool>
            "allowCrossdomainPages" =@ T<bool>
            "autoInitializePage" =@ T<bool>
            "buttonMarkup" =? ButtonMarkup
            "defaultDialogTransition" =@ T<string>
            "defaultPageTransition" =@ T<string>
            "gradeA" =@ T<unit -> bool>
            "hasListeningEnabled" =@ T<bool>
            "ignoreContentEnabled" =@ T<bool>
            "linkBindingEnabled" =@ T<bool>
            "minScrollBack" =@ T<int>
            "ns" =@ T<string>
            "pageLoadErrorMessage" =@ T<string>
            "pageLoadErrorMessageTheme" =@ T<string>
            "pushStateEnabled" =@ T<bool>
            "subPageUrlKey" =@ T<string>

            // Methods and utilities

            "changePage" => (T<JQuery> + T<string>)?``to`` * !? ChangePageConfig?``options`` ^-> T<unit>
            "loadPage" => (T<string> + T<obj>)?url * !? Page.PageLoadConfig?``options`` ^-> T<unit>
            "loading" => T<string> * !? LoadingConfig ^-> T<unit>
            "path" =? Path
            "silentScroll" => !?T<int>?yPos ^-> T<unit>
            "activePage" =? T<JQuery>
        ]

let JQuery =
    Class "JQuery"
    |+> [

            // Events

            "animationComplete" => T<JQuery>?jQuery * T<unit->unit>?h ^-> T<unit>
            |> WithInline "$jQuery.animationComplete($h)"

            // Methods and utilities

            "jqmData" => T<JQuery>?jQuery * T<string>?key ^-> T<obj>
            |> WithInline "$jQuery.jqmData($key)"

            "jqmData" => T<JQuery>?jQuery * T<string>?key * T<obj>?value ^-> T<unit>
            |> WithInline "$jQuery.jqmData($key, $value)"

            "jqmRemoveData" => T<JQuery>?jQuery * T<string>?key ^-> T<unit>
            |> WithInline "$jQuery.jqmRemoveData($key)"

            "jqmEnhanceable" => T<JQuery>?jQuery ^-> T<bool>
            |> WithInline "$jQuery.jqmEnhanceable()"

            "jqmHijackable" => T<JQuery>?jQuery ^-> T<bool>
            |> WithInline "$jQuery.jqmHijackable()"

            "page" => T<JQuery>?jQuery ^-> T<JQuery>
            |> WithInline "$jQuery.page()"
        ]

