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

let PageLoadConfig =
    Pattern.Config "PageLoadConfig" {
        Required = []
        Optional =
            [
                "data", T<obj> + T<string>
                "loadMsgDelay", T<int>
                "pageContainer", T<JQuery>
                "reloadPage", T<bool>
                "role", T<string>
                "showLoadMsg", T<bool>
                "type", T<string>
            ]
    }

let Deferred =
    Class "Deferred"
    |+> Protocol [
            "resolve" => T<string> * PageLoadConfig.Type * T<JQuery> ^-> T<unit>
            "reject" => T<string> * PageLoadConfig.Type ^-> T<unit>
        ]

let PageChangeConfig =
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
            s "swipe" "scrollSupressionThreshold" T<int>
            s "swipe" "durationThreshold" T<int>
            s "swipe" "horizontalDistanceThreshold" T<int>
            s "swipe" "verticalDistanceThreshold" T<int>
            s "vmouse" "moveDistanceThreshold" T<int>
            s "vmouse" "clickDistanceThreshold" T<int>
            s "vmouse" "resetTimerDuration" T<int>
        ]

let Orientation =
    Pattern.EnumStrings "Orientation" ["portrait"; "landscape"]

let OrientationChangeEventArgs =
    Class "OrientationChangeEventArgs"
    |+> Protocol [
            "orientation" =? Orientation
            "event" =? T<IntelliFactory.WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let PageChangeEventArgs =
    Class "PageChangeEventArgs"
    |+> Protocol [
            "toPage" =? T<JQuery>
            "options"  =? PageChangeConfig.Type
            "event" =? T<IntelliFactory.WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let PageBeforeLoadEventArgs =
    Class "PageBeforeLoadEventArgs"
    |+> Protocol [
            "url" =? T<string>
            "absUrl" =? T<string>
            "dataUrl" =? T<string>
            "deferred" =? T<Deferred>
            "options" =? PageLoadConfig.Type
            "event" =? T<IntelliFactory.WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let PageLoadEventArgs =
    Class "PageLoadEventArgs"
    |+> Protocol [
            "url" =? T<string>
            "absUrl" =? T<string>
            "dataUrl" =? T<string>
            "options" =? PageLoadConfig.Type
            "xhr" =? T<IntelliFactory.WebSharper.JQuery.JqXHR>
            "textStatus" =? T<string>
            "event" =? T<IntelliFactory.WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let PageLoadFailedEventArgs =
    Class "PageLoadFailedEventArgs"
    |+> Protocol [
            "url" =? T<string>
            "absUrl" =? T<string>
            "dataUrl" =? T<string>
            "deferred" =? T<Deferred>
            "options" =? PageLoadConfig.Type
            "xhr" =? T<IntelliFactory.WebSharper.JQuery.JqXHR>
            "textStatus" =? T<string>
            "errorThrown" =? T<string> // object
            "event" =? T<IntelliFactory.WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let PageHideEventArgs =
    Class "PageHideEventArgs"
    |+> Protocol [
            "nextPage" =? T<JQuery>
            "event" =? T<IntelliFactory.WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let PageShowEventArgs =
    Class "PageShowEventArgs"
    |+> Protocol [
            "prevPage" =? T<JQuery>
            "event" =? T<IntelliFactory.WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let VMouseEventArgs =
    Class "VMouseEventArgs"
    |+> Protocol [
            "screenX" =? T<int>
            "screenY" =? T<int>
            "clientX" =? T<int>
            "clientY" =? T<int>
            "event" =? T<IntelliFactory.WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let Events =
    let ev0 name = Events.Define name
    let ev1 name ty = Events.DefineTyped name ty
    Class "Events"
    |+> [
            ev0 "hashchange" |> WithSourceName "HashChange"
            ev0 "navigate" |> WithSourceName "Navigate"
            ev1 "orientationchange" OrientationChangeEventArgs.Type |> WithSourceName "OrientationChange"
            ev1 "pagebeforechange" PageChangeEventArgs.Type |> WithSourceName "PageBeforeChange"
            ev0 "pagebeforecreate" |> WithSourceName "PageBeforeCreate"
            ev1 "pagebeforehide" PageHideEventArgs.Type |> WithSourceName "PageBeforeHide"
            ev1 "pagebeforeload" PageBeforeLoadEventArgs.Type |> WithSourceName "PageBeforeLoad"
            ev1 "pagebeforeshow" PageShowEventArgs.Type |> WithSourceName "PageBeforeShow"
            ev1 "pagechange" PageChangeEventArgs.Type |> WithSourceName "PageChange"
            ev1 "pagechangefailed" PageChangeEventArgs.Type |> WithSourceName "PageChangeFailed"
            ev0 "pagecreate" |> WithSourceName "PageCreate"
            ev1 "pagehide" PageHideEventArgs.Type |> WithSourceName "PageHide"
            ev0 "pageinit" |> WithSourceName "PageInit"
            ev1 "pageload" PageLoadEventArgs.Type |> WithSourceName "PageLoad"
            ev0 "scrollstart" |> WithSourceName "ScrollStart"
            ev0 "scrollstop" |> WithSourceName "ScrollStop"
            ev0 "swipe" |> WithSourceName "Swipe"
            ev0 "swipeleft" |> WithSourceName "SwipeLeft"
            ev0 "swiperight" |> WithSourceName "SwipeRight"
            ev0 "tap" |> WithSourceName "Tap"
            ev0 "taphold" |> WithSourceName "TapHold"
            ev0 "throttledresize" |> WithSourceName "ThrottledResize"
            ev0 "updatelayout" |> WithSourceName "UpdateLayout"
            ev1 "vclick" VMouseEventArgs.Type |> WithSourceName "VClick"
            ev1 "vmousecancel" VMouseEventArgs.Type |> WithSourceName "VMouseCancel"
            ev1 "vmousedown" VMouseEventArgs.Type |> WithSourceName "VMouseDown"
            ev1 "vmousemove" VMouseEventArgs.Type |> WithSourceName "VMouseMove"
            ev1 "vmouseout" VMouseEventArgs.Type |> WithSourceName "VMouseOut"
            ev1 "vmouseover" VMouseEventArgs.Type |> WithSourceName "VMouseOver"
            ev1 "vmouseup" VMouseEventArgs.Type |> WithSourceName "VMouseUp"
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

            "changePage" => (T<JQuery> + T<string>)?``to`` * !? PageChangeConfig?``options`` ^-> T<unit>
            "loadPage" => (T<string> + T<obj>)?url * !? PageLoadConfig?``options`` ^-> T<unit>
            "loading" => T<string> * !? LoadingConfig ^-> T<unit>
            "navigate" => (T<string> + T<obj>)?url * !? T<obj>?``data`` ^-> T<unit>
            
            "path" =? Path
            "silentScroll" => !?T<int>?yPos ^-> T<unit>
            "activePage" =? T<JQuery>
            "showPageLoadingMsg" => !?T<string>?theme * !?T<string>?msgText * !?T<bool>?textonly ^-> T<unit>
            "hidePageLoadingMsg" => T<unit> ^-> T<unit>
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

//module Enums =
//
//    let ButtonIcon = 
//        Class "ButtonIcon"
//        |+> [
//            "LeftArrow"=? T<string> |> WithGetterInline "'arrow-l'"
//            "RightArrow"=? T<string> |> WithGetterInline "'arrow-r'"
//            "UpArrow"=? T<string> |> WithGetterInline "'arrow-u'"
//            "DownArrow"=? T<string> |> WithGetterInline "'arrow-d'"
//            "Delete"=? T<string> |> WithGetterInline "'delete'"
//            "Plus"=? T<string> |> WithGetterInline "'plus'"
//            "Minus"=? T<string> |> WithGetterInline "'minus'"
//            "Check"=? T<string> |> WithGetterInline "'check'"
//            "Gear"=? T<string> |> WithGetterInline "'gear'"
//            "Refresh"=? T<string> |> WithGetterInline "'refresh'"
//            "Forward"=? T<string> |> WithGetterInline "'forward'"
//            "Back"=? T<string> |> WithGetterInline "'back'"
//            "Grid"=? T<string> |> WithGetterInline "'grid'"
//            "Star"=? T<string> |> WithGetterInline "'star'"
//            "Alert"=? T<string> |> WithGetterInline "'alert'"
//            "Info"=? T<string> |> WithGetterInline "'info'"
//        ]
//    
//    let Theme = 
//        Class "Theme"
//        |+> [
//            "a" =? T<string>
//            |> WithGetterInline "'a'"
//            "b" =? T<string>
//            |> WithGetterInline "'b'"
//            "c" =? T<string>
//            |> WithGetterInline "'c'"
//            "d" =? T<string>
//            |> WithGetterInline "'d'"
//            "e" =? T<string>
//            |> WithGetterInline "'e'"
//        ]
