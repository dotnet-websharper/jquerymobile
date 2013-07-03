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

/// See API / Widgets / Header
module IntelliFactory.WebSharper.JQuery.Mobile.Header

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

let Header =
    let p = Common.Plugin("header")   
    Class "Header"
    |+> [
            p.DefineConstructor()
        ]
