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

let PageConfig =
    Pattern.Config "PageConfig" {
        Required = []
        Optional =
            [
                "beforecreate", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>

                "domCache", T<bool>
                "keepNativeDefault", T<string>
                "theme", Common.SwatchLetter.Type
            ]
    }


let Page =
    let p = Common.Plugin("page")
    Class "Page"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(PageConfig.Type)
            p.DefineFunc("keepNativeSelector", T<string>)
            p.DefineMethod("removeContainerBackground")
            p.DefineMethod("setContainerBackground", Common.SwatchLetter.Type)

            Events.Define "beforecreate"
            |> WithSourceName "BeforeCreated"
        ]
