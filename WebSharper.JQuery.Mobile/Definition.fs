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

module WebSharper.JQuery.Mobile.Definition

open WebSharper.InterfaceGenerator
open WebSharper.JavaScript.Dom
open WebSharper.JQuery

let ButtonMarkup =
    Class "ButtonMarkup"
    |+> Instance [
            "hoverDelay" =@ T<int> |> Obsolete
        ]

let DegradeInputs =
    Class "DegradeInputs"
    |+> Instance [
            "color"          =@ T<bool> + T<string>
            "date"           =@ T<bool> + T<string>
            "datetime"       =@ T<bool> + T<string>
            "datetime-local" =@ T<bool> + T<string>
            "email"          =@ T<bool> + T<string>
            "month"          =@ T<bool> + T<string>
            "number"         =@ T<bool> + T<string>
            "range"          =@ T<bool> + T<string>
            "search"         =@ T<bool> + T<string>
            "tel"            =@ T<bool> + T<string>
            "time"           =@ T<bool> + T<string>
            "url"            =@ T<bool> + T<string>
            "week"           =@ T<bool> + T<string>
        ]                               

let Special =
    let s c x t =
        x =@ t
        |> WithGetterInline (sprintf "jQuery.event.special.%s.%s" c x)
        |> WithSetterInline (sprintf "jQuery.event.special.%s.%s = $value" c x)
    Class "Special"
    |+> Static [
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
    |+> Instance [
            "orientation" =? Orientation
            "event" =? T<WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let PageChangeEventArgs =
    Class "PageChangeEventArgs"
    |+> Instance [
            "toPage" =? T<JQuery> + T<string>
            "options"  =? PageContainer.PageChangeConfig.Type
        ]

let PageBeforeLoadEventArgs =
    Class "PageBeforeLoadEventArgs"
    |+> Instance [
            "url" =? T<string>
            "absUrl" =? T<string>
            "dataUrl" =? T<string>
            "deferred" =? T<Deferred>
            "options" =? PageContainer.PageLoadConfig.Type
        ]

let PageLoadEventArgs =
    Class "PageLoadEventArgs"
    |+> Instance [
            "url" =? T<string>
            "absUrl" =? T<string>
            "dataUrl" =? T<string>
            "options" =? PageContainer.PageLoadConfig.Type
            "xhr" =? T<WebSharper.JQuery.JqXHR>
            "textStatus" =? T<string>
        ]

let PageLoadFailedEventArgs =
    Class "PageLoadFailedEventArgs"
    |+> Instance [
            "url" =? T<string>
            "absUrl" =? T<string>
            "dataUrl" =? T<string>
            "deferred" =? T<Deferred>
            "options" =? PageContainer.PageLoadConfig.Type
            "xhr" =? T<WebSharper.JQuery.JqXHR>
            "textStatus" =? T<string>
            "errorThrown" =? T<obj> + T<string>
        ]

let PageHideEventArgs =
    Class "PageHideEventArgs"
    |+> Instance [
            "nextPage" =? T<JQuery>
        ]

let PageShowEventArgs =
    Class "PageShowEventArgs"
    |+> Instance [
            "prevPage" =? T<JQuery>
        ]

let VMouseEventArgs =
    Class "VMouseEventArgs"
    |+> Instance [
            "screenX" =? T<int>
            "screenY" =? T<int>
            "clientX" =? T<int>
            "clientY" =? T<int>
            "event" =? T<WebSharper.JQuery.Event>
            |> WithGetterInline "$this"
        ]

let Events =
    let ev0 name = Events.Define name
    let ev1 name ty = Events.DefineTyped name ty
    let ev2 name ty = Events.DefineTyped name (T<WebSharper.JQuery.Event> * ty)
    Class "Events"
    |+> Static [
            ev0 "hashchange" |> WithSourceName "HashChange"
            ev0 "mobileinit" |> WithSourceName "MobileInit"
            ev2 "navigate" T<obj> |> WithSourceName "Navigate" 
            ev1 "orientationchange" OrientationChangeEventArgs.Type |> WithSourceName "OrientationChange"
            ev2 "pagebeforechange" PageChangeEventArgs.Type |> WithSourceName "PageBeforeChange"
            ev0 "pagebeforecreate" |> WithSourceName "PageBeforeCreate"
            ev2 "pagebeforehide" PageHideEventArgs.Type |> WithSourceName "PageBeforeHide"
            ev2 "pagebeforeload" PageBeforeLoadEventArgs.Type |> WithSourceName "PageBeforeLoad"
            ev2 "pagebeforeshow" PageShowEventArgs.Type |> WithSourceName "PageBeforeShow"
            ev2 "pagechange" PageChangeEventArgs.Type |> WithSourceName "PageChange"
            ev2 "pagechangefailed" PageChangeEventArgs.Type |> WithSourceName "PageChangeFailed"
            ev0 "pagecreate" |> WithSourceName "PageCreate"
            ev2 "pagehide" PageHideEventArgs.Type |> WithSourceName "PageHide"
            ev0 "pageinit" |> WithSourceName "PageInit"
            ev2 "pageload" PageLoadEventArgs.Type |> WithSourceName "PageLoad"
            ev2 "pageloadfailed" PageLoadFailedEventArgs.Type |> WithSourceName "PageLoadFailed"
            ev0 "pageremove" |> WithSourceName "PageRemove"    
            ev2 "pageshow" PageShowEventArgs.Type |> WithSourceName "PageShow"    
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
    |+> Instance
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
    |+> Instance
        [
            "parseUrl" => T<string> ^-> URL
            "makePathAbsolute" => T<string>?relPath * T<string>?absPath ^-> T<string>
            "makeUrlAbsolute" => T<string>?relUrl * T<string>?absUrl ^-> T<string>
            "isSameDomain" => T<string> * T<string> ^-> T<bool>
            "isRelativeUrl" => T<string> ^-> T<bool>
            "isAbsoluteUrl" => T<string> ^-> T<bool>
            "get" => T<string> ^-> T<string>
        ]

let TransitionFallbacks =
    Class "TransitionFallbacks"
    |+> Instance
        [
            "fade" =? Common.Transition.Type    
            "flip" =? Common.Transition.Type  
            "flow" =? Common.Transition.Type  
            "pop"  =? Common.Transition.Type  
            "slide" =? Common.Transition.Type  
            "slidedown" =? Common.Transition.Type  
            "slidefade" =? Common.Transition.Type  
            "slideup" =? Common.Transition.Type  
            "turn" =? Common.Transition.Type  
        ]

let Mobile =
    let self = Type.New()
    Class "Mobile"
    |=> self
    |+> Static [
            "Instance" =? self
            |> WithGetterInline "jQuery.mobile"

            "Use" => T<unit->unit>
            |> WithInline "undefined"
        ]
    |+> Instance
        [

            // Configuration Defaults

            "activeBtnClass" =@ T<string> |> Obsolete
            "activePageClass" =@ T<string> |> Obsolete
            "ajaxEnabled" =@ T<bool>
            "allowCrossdomainPages" =@ T<bool>
            "autoInitializePage" =@ T<bool>
            "buttonMarkup" =? ButtonMarkup
            "defaultDialogTransition" =@ T<string> |> Obsolete
            "defaultPageTransition" =@ T<string>
            "degradeInputs" =@ DegradeInputs
            "dynamicBaseEnabled" =@ T<bool>
            "focusClass" =@ T<string> |> Obsolete
            "getMaxScrollForTransition" =@ T<int>
            "gradeA" =@ T<unit -> bool>
            "hasListeningEnabled" =@ T<bool>
            "ignoreContentEnabled" =@ T<bool>
            "keepNative" =@ T<string>
            "linkBindingEnabled" =@ T<bool>
            "maxTransitionWidth" =@ T<int> + T<bool> 
            "minScrollBack" =@ T<int> |> Obsolete
            "ns" =@ T<string>
            "pageLoadErrorMessage" =@ T<string>
            "pageLoadErrorMessageTheme" =@ T<string>
            "phonegapNavigationEnabled" =@ T<bool>
            "pushStateEnabled" =@ T<bool>
            "subPageUrlKey" =@ T<string> |> Obsolete
            "transitionFallbacks" =? TransitionFallbacks

            // Methods and utilities

            "changePage" => (T<JQuery> + T<string>)?``to`` * !? PageContainer.PageChangeConfig?``options`` ^-> T<unit> |> Obsolete
            "degradeInputsWithin" => T<Element>?target ^-> T<unit>
            "getInheritedTheme" => T<JQuery>?el * Common.SwatchLetter?defaultTheme ^-> Common.SwatchLetter
            "loadPage" => (T<string> + T<obj>)?url * !? PageContainer.PageLoadConfig?``options`` ^-> T<unit> |> Obsolete
            "navigate" => (T<string> + T<obj>)?url * !? T<obj>?``data`` ^-> T<unit>
            
            "path" =? Path
            "silentScroll" => !?T<int>?yPos ^-> T<unit>
            "activePage" =? T<JQuery>
            "showPageLoadingMsg" => !?T<string>?theme * !?T<string>?msgText * !?T<bool>?textonly ^-> T<unit>
            "hidePageLoadingMsg" => T<unit> ^-> T<unit>
        ]

let JQuery =
    Class "JQuery"
    |+> Static [

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