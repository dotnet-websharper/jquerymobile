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

/// See API / Events / Page events.
module IntelliFactory.WebSharper.JQuery.Mobile.Page

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

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

let private PLC = PageLoadConfig.Type

let Deferred =
    Class "Deferred"
    |+> Protocol [
            "resolve" => T<string> * PLC * T<JQuery> ^-> T<unit>
            "reject" => T<string> * PLC ^-> T<unit>
        ]

let PageBeforeLoadEvent =
    Class "PageBeforeLoadEvent"
    |+> Protocol [
            "url" =? T<string>
            "absUrl" =? T<string>
            "dataUrl" =? T<string>
            "deferred" =? Deferred.Type
            "options" =? PLC
        ]

let PageLoadEvent =
    Class "PageLoadEvent"
    |+> Protocol
        [
            "url" =? T<string>
            "absUrl" =? T<string>
            "dataUrl" =? T<string>
            "options" =? PLC
            "xhr" =? T<IntelliFactory.WebSharper.JQuery.JqXHR>
            "textStatus" =? T<string>
        ]

let PageLoadFailedEvent =
    Class "PageLoadFailedEvent"
    |+> Protocol
        [
            "url" =? T<string>
            "absUrl" =? T<string>
            "dataUrl" =? T<string>
            "deferred" =? Deferred.Type
            "options" =? PLC
            "xhr" =? T<IntelliFactory.WebSharper.JQuery.JqXHR>
            "textStatus" =? T<string>
            "errorThrown" =? T<obj>
        ]

let PageChangeEvent =
    Class "PageChangeEvent"
    |+> Protocol [
            "toPage" =? T<obj>
            "options" =? PLC
        ]

let PageShowEvent =
    Class "PageShowEvent"
    |+> Protocol [
            "prevPage" =? T<JQuery>
        ]

let PageHideEvent =
    Class "PageHideEvent"
    |+> Protocol [
            "nextPage" =? T<JQuery>
        ]

let Page =
    let ev1 n x y =
        Events.DefineTyped x y
        |> WithSourceName n
    let ev0 n x =
        Events.Define x
        |> WithSourceName n
    Class "Page"
    |+> [
            ev1 "BeforeLoad" "pagebeforeload" PageBeforeLoadEvent.Type
            ev1 "Load" "pageload" PageLoadEvent.Type
            ev1 "LoadFailed" "pageloadfailed" PageLoadFailedEvent.Type
            ev1 "BeforeChange" "pagebeforechange" PageChangeEvent.Type
            ev1 "Change" "pagechange" PageChangeEvent.Type
            ev1 "ChangeFailed" "pagechangefailed" PageChangeEvent.Type
            ev1 "BeforeShow" "pagebeforeshow" PageShowEvent.Type
            ev1 "Show" "pageshow" PageShowEvent.Type
            ev1 "BeforeHide" "pagebeforehide" PageHideEvent.Type
            ev1 "Hide" "pagehide" PageHideEvent.Type
            ev0 "BeforeCreate" "pagebeforecreate"
            ev0 "Create" "pagecreate"
            ev0 "Init" "pageinit"
            ev0 "Remove" "pageremove"
        ]
