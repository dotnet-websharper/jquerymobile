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
    let ev2 name ty = Events.DefineTyped2 name T<WebSharper.JQuery.Event> ty
    Class "Events"
    |+> Static [
            ev0 "hashchange" |> WithSourceName "HashChange"
            ev0 "mobileinit" |> WithSourceName "MobileInit"
            ev2 "navigate" T<obj> |> WithSourceName "Navigate" 
            ev1 "orientationchange" OrientationChangeEventArgs.Type |> WithSourceName "OrientationChange"
            ev2 "pagebeforechange" PageChangeEventArgs.Type |> WithSourceName "PageBeforeChange" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerbeforechange event instead"
            ev0 "pagebeforecreate" |> WithSourceName "PageBeforeCreate"
            ev2 "pagebeforehide" PageHideEventArgs.Type |> WithSourceName "PageBeforeHide" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerbeforehide event instead"
            ev2 "pagebeforeload" PageBeforeLoadEventArgs.Type |> WithSourceName "PageBeforeLoad" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerbeforeload event instead"
            ev2 "pagebeforeshow" PageShowEventArgs.Type |> WithSourceName "PageBeforeShow" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerbeforeshow event instead"
            ev2 "pagechange" PageChangeEventArgs.Type |> WithSourceName "PageChange" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerchange event instead"
            ev2 "pagechangefailed" PageChangeEventArgs.Type |> WithSourceName "PageChangeFailed" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerchangefailed event instead"
            ev0 "pagecreate" |> WithSourceName "PageCreate" 
            ev2 "pagehide" PageHideEventArgs.Type |> WithSourceName "PageHide" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerhide event instead"
            ev0 "pageinit" |> WithSourceName "PageInit" |> ObsoleteWithMessage "Use the pagecreate event"
            ev2 "pageload" PageLoadEventArgs.Type |> WithSourceName "PageLoad" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerload event instead"
            ev2 "pageloadfailed" PageLoadFailedEventArgs.Type |> WithSourceName "PageLoadFailed" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerloadfailed event instead"
            ev0 "pageremove" |> WithSourceName "PageRemove" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainerremove event instead"
            ev2 "pageshow" PageShowEventArgs.Type |> WithSourceName "PageShow" |> ObsoleteWithMessage "Use the pagecontainer's pagecontainershow event instead"
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

            // widget related events
            ev2 "buttoncreate" T<obj> |> WithSourceName "ButtonCreate"
            
            ev2 "checkbocradiocreate" T<obj> |> WithSourceName "CheckboxRadioCreate"

            ev2 "collapsiblesetcreate" T<obj> |> WithSourceName "CollapsibleSetCreate"

            ev2 "controlgroupcreate" T<obj> |> WithSourceName "ControlGroupCreate"

            ev2 "dialogcreate" T<obj> |> WithSourceName "DialogCreate" |> ObsoleteWithMessage "Use the Page.Dialog extension's event or implement your dialog using the Popups widget"

            ev2 "flipswitchcreate" T<obj> |> WithSourceName "FlipSwitchCreate"

            ev2 "listviewcreate" T<obj> |> WithSourceName "ListViewCreate"

            ev2 "loadingcreate" T<obj> |> WithSourceName "LoadingCreate"

            ev2 "navbarcreate" T<obj> |> WithSourceName "NavBarCreate"

            ev2 "pagecontainerbeforechange" T<obj> |> WithSourceName "PageContainerBeforeChange"
            ev2 "pagecontainerbeforehide" T<obj> |> WithSourceName "PageContainerBeforeHide"
            ev2 "pagecontainerbeforeload" T<obj> |> WithSourceName "PageContainerBeforeLoad"
            ev2 "pagecontainerbeforeshow" T<obj> |> WithSourceName "PageContainerBeforeShow"
            ev2 "pagecontainerbeforetransition" T<obj> |> WithSourceName "PageContainerBeforeTransition"
            ev2 "pagecontainerchange" T<obj> |> WithSourceName "PageContainerChange"
            ev2 "pagecontainerchangefailed" T<obj> |> WithSourceName "PageContainerChangeFailed"
            ev2 "pagecontainercreate" T<obj> |> WithSourceName "PageContainerCreate"
            ev2 "pagecontainerhide" T<obj> |> WithSourceName "PageContainerHide"
            ev2 "pagecontainerload" T<obj> |> WithSourceName "PageContainerLoad"
            ev2 "pagecontainerloadfailed" T<obj> |> WithSourceName "PageContainerLoadFailed"
            ev2 "pagecontainerremove" T<obj> |> WithSourceName "PageContainerRemove"
            ev2 "pagecontainershow" T<obj> |> WithSourceName "PageContainerShow"
            ev2 "pagecontainertransition" T<obj> |> WithSourceName "PageContainerTransition"

            ev2 "panelbeforeclose" T<obj> |> WithSourceName "PanelBeforeClose"
            ev2 "panelbeforeopen" T<obj> |> WithSourceName "PanelBeforeOpen"
            ev2 "panelclose" T<obj> |> WithSourceName "PanelClose"
            ev2 "panelcreate" T<obj> |> WithSourceName "PanelCreate"
            ev2 "panelopen" T<obj> |> WithSourceName "PanelOpen"

            ev2 "popupafterclose" T<obj> |> WithSourceName "PopupAfterClose"
            ev2 "popupafteropen" T<obj> |> WithSourceName "PopupAfterOpen"
            ev2 "popupbeforeposition" T<obj> |> WithSourceName "PopupBeforePosition"
            ev2 "popupcreate" T<obj> |> WithSourceName "PopupCreate"

            ev2 "rangeslidercreate" T<obj> |> WithSourceName "RangeSliderCreate"
            ev2 "rangeslidernormalize" T<obj> |> WithSourceName "RangeSliderNormalize"

            ev2 "selectcreate" T<obj> |> WithSourceName "SelectMenuCreate"

            ev2 "slidercreate" T<obj> |> WithSourceName "SliderCreate"
            ev2 "sliderstart" T<obj> |> WithSourceName "SliderStart"
            ev2 "sliderstop" T<obj> |> WithSourceName "SliderStop"

            ev2 "tablecreate" T<obj> |> WithSourceName "TableCreate"

            ev2 "tabsactivate" T<obj> |> WithSourceName "TabsActivate"
            ev2 "tabsbeforeactivate" T<obj> |> WithSourceName "TabsBeforeActivate"
            ev2 "tabsbeforeload" T<obj> |> WithSourceName "TabsBeforeLoad"
            ev2 "tabscreate" T<obj> |> WithSourceName "TabsCreate"
            ev2 "tabsload" T<obj> |> WithSourceName "TabsLoad"

            ev2 "textinputcreate" T<obj> |> WithSourceName "TextInputCreate"

            ev2 "toolbarcreate" T<obj> |> WithSourceName "ToolbarCreate"
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

            "getDocumentBase" => T<bool> ^-> T<string>
            "getDocumentUrl" => T<bool> ^-> T<string>
            "getLocation" => T<unit> ^-> T<string>
            "parseLocation" => T<unit> ^-> URL
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
    Class "Mobile"
    |+> Static [
            "Instance" =? TSelf
            |> WithGetterInline "jQuery.mobile"

            "Use" => T<unit->unit>
            |> WithInline "undefined"

            "enhanceWithin" => T<JQuery>?j ^-> T<unit>
            |> WithInline "$j.enhanceWithin()"
        ]
    |+> Instance
        [

            // Configuration Defaults

            "activeBtnClass" =@ T<string> |> Obsolete
            "activePageClass" =@ T<string> |> Obsolete
            "ajaxEnabled" =@ T<bool>
            "allowCrossdomainPages" =@ T<bool>
            "autoInitializePage" =@ T<bool>
            "buttonMarkup" =? ButtonMarkup |> Obsolete
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

            "initializePage" => T<unit> ^-> T<unit>
            "resetActivePageHeight" => T<unit> ^-> T<unit>

            // Methods and utilities

            "changePage" => (T<JQuery> + T<string>)?``to`` * !? PageContainer.PageChangeConfig?``options`` ^-> T<unit> |> ObsoleteWithMessage "Use the pagecontainer widget's change method instead."
            "degradeInputsWithin" => T<Element>?target ^-> T<unit>
            "getDocumentBase" => T<bool> ^-> T<string> |> ObsoleteWithMessage "Use the Path.GetDocumentBase function instead"
            "getDocumentUrl" => T<bool> ^-> T<string> |> ObsoleteWithMessage "Use the Path.GetDocumentUrl function instead"
            "getInheritedTheme" => T<JQuery>?el * Common.SwatchLetter?defaultTheme ^-> Common.SwatchLetter
            "loadPage" => (T<string> + T<obj>)?url * !? PageContainer.PageLoadConfig?``options`` ^-> T<Promise> |> ObsoleteWithMessage "Use the pagecontainer widget's load function instead"
            "navigate" => (T<string> + T<obj>)?url * !? T<obj>?``data`` ^-> T<unit>
            
            "path" =? Path
            "silentScroll" => !?T<int>?yPos ^-> T<unit>
            "activePage" =? T<JQuery> |> ObsoleteWithMessage "Use the pagecontainer widget's getActivePage function instead"
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
