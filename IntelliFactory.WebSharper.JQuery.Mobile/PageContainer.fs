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

/// See API / Widgets / PageContainer
module IntelliFactory.WebSharper.JQuery.Mobile.PageContainer

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let PageContainerConfig =
    Pattern.ConfigObs "PageContainerConfig" {
        Required = []
        Optional =
            [
                "beforehide", T<Events.JEvent * JQuery -> unit>
                "beforeload", T<Events.JEvent * JQuery -> unit>
                "beforeshow", T<Events.JEvent * JQuery -> unit>
                "beforetransition", T<Events.JEvent * JQuery -> unit>
                "changefailed", T<Events.JEvent * JQuery -> unit>
                "create", T<Events.JEvent * JQuery -> unit>
                "hide", T<Events.JEvent * JQuery -> unit>
                "load", T<Events.JEvent * JQuery -> unit>
                "loadfailed", T<Events.JEvent * JQuery -> unit>
                "show", T<Events.JEvent * JQuery -> unit>
                "transition", T<Events.JEvent * JQuery -> unit>

                "defaults", T<bool>
                "disabled", T<bool>
                "theme", Common.SwatchLetter.Type
            ]
        Obsolete =
            [
            ]
    }

let PageContainer =
    let p = Common.Plugin("pagecontainer")  
    Class "PageContainer"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(PageContainerConfig.Type)

            p.DefineMethod("change", T<string * obj>)
            p.DefineFunc("getActivePage", T<JQuery>)
            p.DefineFunc("load", T<string * obj>, T<Promise>)
        ]