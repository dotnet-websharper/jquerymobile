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
module WebSharper.JQuery.Mobile.NavBar

open WebSharper.InterfaceGenerator
open WebSharper.JQuery

let NavBarConfig =
    Pattern.ConfigObs "NavBarConfig" {
        Required = []
        Optional =
            [
                "create", T<Events.JEvent * JQuery -> unit>

                "defaults", T<bool>
                "disabled", T<bool>
                "iconpos", Common.IconPosition.Type
            ]
        Obsolete =
            [
                "initSelector", T<string>
            ]
    }

let NavBar =
    let p = Common.Plugin("navbar")   
    Class "NavBar"
    |+> Static [
            p.DefineConstructor()
            p.DefineConstructor(NavBarConfig.Type)
        ]
