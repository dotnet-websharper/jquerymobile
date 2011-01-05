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
    let SetAttr attr value elem =
        elem
        |>! OnAfterRender (fun elem ->
                JQuery.JQuery.Of(elem.Body).Attr(attr, value).Ignore)

    [<JavaScript>]
    let AddDataRole role elem = SetAttr "data-role" role elem
        
    [<JavaScript>]
    let SimplePage () = 
        JQuery.Mobile.JQuery.UseJQueryMobile // should trigger webresource.
        let header =
            Div [H1 [Text "Page Title"]]
            |> AddDataRole "header"

        let content =
            Div [P [Text "Lorem ipsum dolor sit amet, consectetur adipiscing"]]
            |> AddDataRole "content"

        let footer =
            Div [H4 [Text "Page Footer"]]
            |> AddDataRole "footer"

        let page = 
            Div [header
                 content
                 footer]
            |> AddDataRole "page"

        page    

    [<JavaScript>]
    let SimpleNavigation () = 
        JQuery.Mobile.JQuery.UseJQueryMobile // should trigger webresource.
        let home =
            let header =
                Div [H1 [Text "Home"]]
                |> AddDataRole "header"
        
            let content =
                Div [P [A [Attr.HRef "#about"; Text "About this app"]]]
                |> AddDataRole "content"
        
            let page = 
                Div [Attr.Id "home"
                     header  :> IPagelet
                     content :> IPagelet]
                |> AddDataRole "page"

            page

        let about =
            let header =
                Div [H1 [Text "About This App"]]
                |> AddDataRole "header"
        
            let content =
                Div [P [Text "This app rocks "
                        A [HRef "#home" 
                           Text " Go home!"] :> IPagelet
                        ]
                    ]
                |> AddDataRole "content"
        
            let page = 
                Div [Attr.Id "about"
                     header  :> IPagelet
                     content :> IPagelet]
                |> AddDataRole "page"
            page
        
        Div [
            home
            about
        ]
        
        
    [<JavaScript>]
    let FormTypes () = 
        JQuery.Mobile.JQuery.UseJQueryMobile // should trigger webresource.
        let home =
            let header =
                Div [H1 [Text "Ice Cream Order Form"]]
                |> AddDataRole "header"
        
            let content =
                let checkbox (name: string) = 
                    Input [
                        Attr.Type "checkbox" 
                        Name name
                        Id name
                        Attr.Class "custom"
                    ]
                    -- 
                    Label [
                        Attr.For name
                        Text name
                    ]

                Div [
                    Form [ Action "#"
                           Method "get"
                           // Name Field
                           Div [
                              Label [
                                Attr.For "name"
                                Text "Your name:"
                              ]
                              Input [
                                Attr.Type "text"
                                Attr.Name "name"
                                Attr.Value ""
                              ] 
                           ] |> AddDataRole "fieldcontain" :> IPagelet
                           
                           // Flavour field
                           Div [
                              Legend [
                                Text "Which flavours would you like?"
                              ]
                              checkbox "Vanilla"
                              checkbox "Chocolate"
                              checkbox "Strawberry"
                           ] |> AddDataRole "controlgroup" :> IPagelet
                           // Cones Field
                           Div [
                              Label [
                                Attr.For "quantity"
                                Text "Number of cones:"
                              ]
                              Input [
                                Attr.Type "range"
                                Attr.Name "quantity"
                                Attr.Id   "quantity"
                                Attr.Value "1"
                              ] 
                              |> SetAttr "min" "1" 
                              |> SetAttr "max" "100" 
                           ] |> AddDataRole "fieldcontain" :> IPagelet
                           
                           // Sprinkles Field
                           Div [
                              Label [
                                Attr.For "sprinkles"
                                Text "Sprinkles:"
                              ]
                              Select [
                                Attr.Name "sprinkles"
                                Attr.Id   "sprinkles"
                                Default.Tags.Option [
                                    Attr.Value "on"
                                    Text "Yes"
                                ] :> IPagelet
                                Default.Tags.Option [
                                    Attr.Value "off"
                                    Text "No"
                                ] :> IPagelet
                              ] |> AddDataRole "slider"
                              
                           ] |> AddDataRole "fieldcontain" :> IPagelet

                           // Store Field
                           Div [
                              Label [
                                Attr.For "store"
                                Text "Collect from store:"
                              ]
                              Select [
                                Attr.Name "store"
                                Attr.Id   "store"
                                Default.Tags.Option [
                                    Attr.Value "mainStreet"
                                    Text "Main Street"
                                ] :> IPagelet
                                Default.Tags.Option [
                                    Attr.Value "libertyAvenue"
                                    Text "Liberty Avenue"
                                ] :> IPagelet
                                Default.Tags.Option [
                                    Attr.Value "circleSquare"
                                    Text "Circle Square"
                                ] :> IPagelet
                                Default.Tags.Option [
                                    Attr.Value "angelRoad"
                                    Text "Angel Road"
                                ] :> IPagelet
                              ]
                              
                           ] |> AddDataRole "fieldcontain" :> IPagelet
                           
                           
                           Div [
                              Attr.Class "ui-body ui-body-b"
                              FieldSet [
                                Attr.Class "ui-grid-a"
                                Div [ 
                                    Attr.Class "ui-block-a"
                                    Button [
                                        Attr.Type "submit"
                                        Text "Cancel"
                                    ] |> SetAttr "data-theme" "a" :> IPagelet
                                ] :> IPagelet
                                Div [
                                    Attr.Class "ui-block-b"
                                    Button [
                                        Attr.Type "submit"
                                        Text "Order Ice Cream"
                                    ] |> SetAttr "data-theme" "a" :> IPagelet
                                ] :> IPagelet
                              ] :> IPagelet
                           ] :> IPagelet
                    ]
                ] |> AddDataRole "content" :> IPagelet
                
            let page = 
                Div [Attr.Id "home"
                     header  :> IPagelet
                     content]
                |> AddDataRole "page"
            page

        home    

    [<JavaScript>]
    let EventTestPage () =
        let header =
            Div [H1 [Text "Tap me!"]]
            |> AddDataRole "header"
        
        JQuery.Mobile.JQuery.Of(JQuery.JQuery.Of(header.Body)).Tap(
            fun _ event -> 
                JavaScript.Alert("Tapped on:" + string event.PageX + "," + string event.PageY)
            ).Base.Ignore

        let content =
            Div [P [Text "Swipe me!"]]
            |> AddDataRole "content"
        
        JQuery.Mobile.JQuery.Of(JQuery.JQuery.Of(content.Body)).Swipe(
            fun _ event -> 
                JavaScript.Alert("Swipped on")
            ).Base.Ignore

        let footer =
            Div [H4 [Text "Scroll me!"]]
            |> AddDataRole "footer"

        JQuery.Mobile.JQuery.Of(JQuery.JQuery.Of(footer.Body)).Scrollstart(
            fun _ event -> 
                JavaScript.Alert("Scrolled on")
            ).Base.Ignore

        let page = 
            Div [header
                 content
                 footer]
            |> AddDataRole "page"

        page    

    [<JavaScript>]
    let UtilsTestPage () =
        let header =
            Div [H1 [Text "Page 1"]]
            |> AddDataRole "header"
        
        let content =
            Div [P [Text "Content"]]
            |> AddDataRole "content"
        
        let page = 
            Div [header
                 content]
            |> AddDataRole "page"

        
        JavaScript.Alert(JQuery.Mobile.JQuery.Mobile.DefaultTransition)
        JavaScript.Alert(JQuery.Mobile.JQuery.Mobile.LoadingMessage)

        page    



type Samples() = 
    inherit Web.Control()

    [<JavaScript>]
    override this.Body = 
        // SampleInternals.SimplePage () :> IPagelet
        // SampleInternals.SimpleNavigation () :> IPagelet
        // SampleInternals.FormTypes () :> IPagelet
        // SampleInternals.EventTestPage() :> IPagelet
        SampleInternals.UtilsTestPage() :> IPagelet

