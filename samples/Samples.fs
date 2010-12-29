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

namespace IntelliFactory.WebSharper.JQuery.Mobile.Samples

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.EcmaScript
open IntelliFactory.WebSharper.JQuery.Mobile
open IntelliFactory.WebSharper.JavaScript

open IntelliFactory.WebSharper.Html

module SampleInternals =
    
    [<JavaScript>]
    let SimplePage () = 
        let jq = JQuery.Mobile.MobileJQ.JQuery // should trigger webresource.
        let header =
            Div [H1 [Text "Page Title"]]
            |>! OnAfterRender (fun elem ->
                JQuery.JQuery.Of(elem.Body).Attr("data-role", "header").Ignore)
        let content =
            Div [P [Text "Lorem ipsum dolor sit amet, consectetur adipiscing"]]
            |>! OnAfterRender (fun elem ->
                JQuery.JQuery.Of(elem.Body).Attr("data-role", "content").Ignore)
        let footer =
            Div [H4 [Text "Page Footer"]]
            |>! OnAfterRender (fun elem ->
                JQuery.JQuery.Of(elem.Body).Attr("data-role", "footer").Ignore)
        
        let page = 
            Div [header
                 content
                 footer]
            |>! OnAfterRender (fun elem ->
                JQuery.JQuery.Of(elem.Body).Attr("data-role", "page").Ignore)
        page    

    [<JavaScript>]
    let SimpleNavigation () = 
        let jq = JQuery.Mobile.MobileJQ.JQuery // should trigger webresource.
        let home =
            let header =
                Div [H1 [Text "Home"]]
                |>! OnAfterRender (fun elem ->
                    JQuery.JQuery.Of(elem.Body).Attr("data-role", "header").Ignore)
        
            let content =
                Div [P [A [Attr.HRef "#about"; Text "About this app"]]]
                |>! OnAfterRender (fun elem ->
                    JQuery.JQuery.Of(elem.Body).Attr("data-role", "content").Ignore)
        
            let page = 
                Div [Attr.Id "home"
                     header  :> IPagelet
                     content :> IPagelet]
                |>! OnAfterRender (fun elem ->
                    JQuery.JQuery.Of(elem.Body).Attr("data-role", "page").Ignore)
            page

        let about =
            let header =
                Div [H1 [Text "About This App"]]
                |>! OnAfterRender (fun elem ->
                    JQuery.JQuery.Of(elem.Body).Attr("data-role", "header").Ignore)
        
            let content =
                Div [P [Text "This app rocks"
                        A [HRef "#home" 
                           Text "Go home!"] :> IPagelet
                        ]
                    ]
                |>! OnAfterRender (fun elem ->
                    JQuery.JQuery.Of(elem.Body).Attr("data-role", "content").Ignore)
        
            let page = 
                Div [Attr.Id "about"
                     header  :> IPagelet
                     content :> IPagelet]
                |>! OnAfterRender (fun elem ->
                    JQuery.JQuery.Of(elem.Body).Attr("data-role", "page").Ignore)
            page
        
        Div [
            home
            about
        ]
        
            

type Samples() = 
    inherit Web.Control()

    [<JavaScript>]
    override this.Body = 
        // SampleInternals.SimplePage () :> IPagelet
        SampleInternals.SimpleNavigation () :> IPagelet
