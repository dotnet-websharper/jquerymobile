// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2010.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

namespace IntelliFactory.WebSharper.JQuery.Mobile

module Definition =
    open IntelliFactory.WebSharper.InterfaceGenerator

    let JQuery = 
        let JQuery = Class "MobileJQ"
        JQuery
        |+> [
            "jQuery" =? T<IntelliFactory.WebSharper.JQuery.JQuery> |> WithGetterInline "jQuery"
            
        ]
        // |=> Inherits T<IntelliFactory.WebSharper.JQuery.JQuery>
    

    let Assembly =
        Assembly [
            Namespace "IntelliFactory.WebSharper.JQuery.Mobile" [
                JQuery
            ]
        ]

