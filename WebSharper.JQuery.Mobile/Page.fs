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

            p.DefineFunc("bindRemove", T<unit -> unit>)
            p.DefineFunc("keepNativeSelector", T<string>) |> Obsolete
            p.DefineMethod("removeContainerBackground") |> Obsolete 
            p.DefineMethod("setContainerBackground", Common.SwatchLetter.Type) |> Obsolete

            Events.Define "beforecreate"
            |> WithSourceName "BeforeCreated"
        ]
