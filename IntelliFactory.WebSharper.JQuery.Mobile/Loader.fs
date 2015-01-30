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
module IntelliFactory.WebSharper.JQuery.Mobile.Loader

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let LoaderConfig =
    Pattern.Config "LoaderConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "defaults", T<bool>
                "disabled", T<bool>
                "html", T<bool>
                "text", T<string>
                "textVisible", T<bool>
                "textonly", T<bool>
                "theme", Common.SwatchLetter.Type
            ]
    }

let Loader =
    let p = Common.Plugin("loader")  
    Class "Loader"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(LoaderConfig.Type)
            
            p.DefineMethod("checkLoaderPosition")
            p.DefineMethod("fakeFixLoader")
            p.DefineMethod("hide")
            p.DefineMethod("loading")
            p.DefineMethod("resetHtml")
            p.DefineMethod("show")
        ]