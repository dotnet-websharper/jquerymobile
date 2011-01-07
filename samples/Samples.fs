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

module SampleInternals =
   
    [<JavaScript>]
    let SimplePage () = 
        JQuery.Mobile.JQuery.UseJQueryMobile // should trigger webresource.
        let header =
            Div [HTML5.Attr.Data "role" "header"
                 H1 [Text "Page Title"] :> IPagelet
                ]
            

        let content =
            Div [HTML5.Attr.Data "role" "content"
                 P [Text "Lorem ipsum dolor sit amet, consectetur adipiscing"] :> IPagelet
                ]
            

        let footer =
            Div [HTML5.Attr.Data "role" "footer"
                 H4 [Text "Page Footer"] :> IPagelet
                ]

        let page = 
            Div [HTML5.Attr.Data "role" "page"
                 header  :> IPagelet
                 content :> IPagelet
                 footer  :> IPagelet]

        page    

    [<JavaScript>]
    let SimpleNavigation () = 
        JQuery.Mobile.JQuery.UseJQueryMobile // should trigger webresource.
        let home =
            let header =
                Div [HTML5.Attr.Data "role" "header"
                     H1 [Text "Home"] :> IPagelet                
                    ]
                
        
            let content =
                Div [HTML5.Attr.Data "role" "content"
                     P [A [Attr.HRef "#about"; Text "About this app"]] :> IPagelet
                    ]
                
        
            let page = 
                Div [Attr.Id "home"
                     HTML5.Attr.Data "role" "page"
                     header  :> IPagelet
                     content :> IPagelet]
                
            page

        let about =
            let header =
                Div [
                    HTML5.Attr.Data "role" "header"
                    H1 [Text "About This App"] :> IPagelet
                ]
                
        
            let content =
                Div [HTML5.Attr.Data "role" "content"
                     P [Text "This app rocks "
                        A [HRef "#home" 
                           Text " Go home!"] :> IPagelet
                        ] :> IPagelet
                    ]
                
        
            let page = 
                Div [Attr.Id "about"
                     HTML5.Attr.Data "role" "page"
                     header  :> IPagelet
                     content :> IPagelet]
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
                Div [HTML5.Attr.Data "role" "header"
                     H1 [Text "Ice Cream Order Form"] :> IPagelet
                    ]
        
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
                    ] :> IPagelet

                Div [
                    HTML5.Attr.Data "role" "content"
                    Form [ Action "#"
                           Method "get"
                           // Name Field
                           Div [
                              HTML5.Attr.Data "role" "fieldcontain"
                              Label [
                                Attr.For "name"
                                Text "Your name:"
                              ]  :> IPagelet
                              Input [
                                Attr.Type "text"
                                Attr.Name "name"
                                Attr.Value ""
                              ]  :> IPagelet
                           ] :> IPagelet
                           
                           // Flavour field
                           Div [
                              HTML5.Attr.Data "role" "controlgroup"
                              Legend [
                                Text "Which flavours would you like?"
                              ] :> IPagelet
                              checkbox "Vanilla"
                              checkbox "Chocolate"
                              checkbox "Strawberry"
                           ] :> IPagelet
                           // Cones Field
                           Div [
                              HTML5.Attr.Data "role" "fieldcontain"
                              Label [
                                Attr.For "quantity"
                                Text "Number of cones:"
                              ] :> IPagelet
                              Input [
                                Attr.Type "range"
                                Attr.Name "quantity"
                                Attr.Id   "quantity"
                                Attr.Value "1"
                                HTML5.Attr.Min "1" 
                                HTML5.Attr.Max "100"
                              ] :> IPagelet
                              
                           ] :> IPagelet
                           
                           // Sprinkles Field
                           Div [
                              HTML5.Attr.Data "role" "fieldcontain" 
                              Label [
                                Attr.For "sprinkles"
                                Text "Sprinkles:"
                              ] :> IPagelet
                              Select [
                                HTML5.Attr.Data "role" "slider"
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
                              ] :> IPagelet
                           ] :> IPagelet

                           // Store Field
                           Div [
                              HTML5.Attr.Data "role" "fieldcontain" 
                              Label [
                                Attr.For "store"
                                Text "Collect from store:"
                              ] :> IPagelet
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
                              ] :> IPagelet
                           ] :> IPagelet
                           
                           
                           Div [
                              Attr.Class "ui-body ui-body-b"
                              FieldSet [
                                Attr.Class "ui-grid-a"
                                Div [ 
                                    Attr.Class "ui-block-a"
                                    Button [
                                        HTML5.Attr.Data "theme" "a"
                                        Attr.Type "submit"
                                        Text "Cancel"
                                    ] :> IPagelet
                                ] :> IPagelet
                                Div [
                                    Attr.Class "ui-block-b"
                                    Button [
                                        HTML5.Attr.Data "theme" "a"
                                        Attr.Type "submit"
                                        Text "Order Ice Cream"
                                    ] :> IPagelet
                                ] :> IPagelet
                              ] :> IPagelet
                           ] :> IPagelet
                    ] :> IPagelet
                ] :> IPagelet
                
            let page = 
                Div [HTML5.Attr.Data "role" "page"
                     Attr.Id "home"
                     header  :> IPagelet
                     content]
                
            page

        home    

    [<JavaScript>]
    let EventTestPage () =
        let header =
            Div [
                HTML5.Attr.Data "role" "header" 
                H1 [Text "Tap me!"] :> IPagelet
            ]
            
        
        JQuery.Mobile.JQuery.Of(JQuery.JQuery.Of(header.Body)).Tap(
            fun _ event -> 
                JavaScript.Alert("Tapped on:" + string event.PageX + "," + string event.PageY)
            ).Base.Ignore

        let content =
            Div [
                HTML5.Attr.Data "role" "content"
                P [Text "Swipe me!"] :> IPagelet
            ]
        
        JQuery.Mobile.JQuery.Of(JQuery.JQuery.Of(content.Body)).Swipe(
            fun _ event -> 
                JavaScript.Alert("Swipped on")
            ).Base.Ignore

        let footer =
            Div [
                HTML5.Attr.Data "role" "footer"
                H4 [Text "Scroll me!"] :> IPagelet
            ]

        JQuery.Mobile.JQuery.Of(JQuery.JQuery.Of(footer.Body)).Scrollstart(
            fun _ event -> 
                JavaScript.Alert("Scrolled on")
            ).Base.Ignore

        let page = 
            Div [
                HTML5.Attr.Data "role" "page"
                header  :> IPagelet
                content :> IPagelet
                footer  :> IPagelet
            ]

        page    

    [<JavaScript>]
    let UtilsTestPage () =
        let header =
            Div [
                HTML5.Attr.Data "role" "header"
                H1 [Text "Page 1"] :> IPagelet
            ]
        
        let content =
            Div [
                HTML5.Attr.Data "role" "content"
                P [Text "Content"] :> IPagelet
            ]
        
        let page = 
            Div [
                HTML5.Attr.Data "role" "page"
                header  :> IPagelet
                content :> IPagelet
            ]
        
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

