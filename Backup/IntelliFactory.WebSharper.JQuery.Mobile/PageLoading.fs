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
module IntelliFactory.WebSharper.JQuery.Mobile.PageLoading

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let PageLoadingConfig =
    Pattern.Config "PageLoadingConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "html", T<bool>
                "text", T<string>
                "textVisible", T<bool>
                "textonly", T<bool>
                "theme", Common.SwatchLetter.Type
            ]
    }

let PageLoading =
    let p = Common.Plugin("pageloading")  
    Class "PageLoading"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(PageLoadingConfig.Type)
            p.DefineMethod("checkLoaderPosition")
            p.DefineMethod("fakeFixLoader")
            p.DefineMethod("hide")
            p.DefineMethod("loading")
            p.DefineMethod("resetHtml")
            p.DefineMethod("show")
        ]