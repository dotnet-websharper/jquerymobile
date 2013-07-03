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

/// See API / Widgets / Navbar
module IntelliFactory.WebSharper.JQuery.Mobile.NavBar

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let NavBarConfig =
    Pattern.Config "NavBarConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "iconpos", Common.IconPosition.Type
            ]
    }

let NavBar =
    let p = Common.Plugin("navbar")   
    Class "NavBar"
    |+> [
            p.DefineConstructor()
            p.DefineConstructor(NavBarConfig.Type)
        ]
