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

/// See API / Widgets / Footer
module IntelliFactory.WebSharper.JQuery.Mobile.Footer

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let Footer =
    let p = Common.Plugin("footer")   
    Class "Footer"
    |+> [
            p.DefineConstructor()
        ]
