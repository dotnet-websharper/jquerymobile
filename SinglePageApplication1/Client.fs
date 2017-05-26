namespace SinglePageApplication1

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.JQuery.Mobile
open WebSharper.Html.Client

[<JavaScript>]
module JQueryMobile =
    
    let IndexPage (simplePage: Element) (formTypes: Element) (eventTestPage: Element) = 
        JQuery.Mobile.Use()
        let header =
            Div [Attr.Data "role" "header"] -< [
                H1 [Text "Index"]
            ]
        let content =
            Div [Attr.Data "role" "content"] -< [
                A [Attr.Data "role" "button"] -< [
                   HRef "#simplePage" 
                   Text "Simple Page" 
                ]
                |>! OnClick (fun _ _ -> JQuery.Mobile.Instance.ChangePage(JQuery.Of(simplePage.Body)))
                A [Attr.Data "role" "button"] -< [
                   HRef "#formTypes" 
                   Text "Forms"
                ]
                |>! OnClick (fun _ _ -> JQuery.Mobile.Instance.ChangePage(JQuery.Of(formTypes.Body)))
                A [Attr.Data "role" "button"] -< [
                    HRef "#eventTest" 
                    Text "New Events"
                ]
                |>! OnClick (fun _ _ -> JQuery.Mobile.Instance.ChangePage(JQuery.Of(eventTestPage.Body)))
            ]
        let page = 
            Div [
                Id "indexPage"
                Attr.Data "role" "page"
                Attr.Data "url" "#indexPage"
                ] -< [
                header
                content
            ]
        page

    let SimplePage () = 
        JQuery.Mobile.Use()
        let header =
            Div [Attr.Data "role" "header"] -< [
                 H1 [Text "Page Title"]
            ]
        let content =
            Div [Attr.Data "role" "content"] -< [
                 P [Text "Lorem ipsum dolor sit amet, consectetur adipiscing"]
            ]
        let footer =
            Div [Attr.Data "role" "footer"] -< [
                 H4 [Text "Page Footer"]
            ]
        let page = 
            Div [
                Id "simplePage"
                Attr.Data "role" "page"
                Attr.Data "url" "#simplePage"
                ] -< [
                header
                content
                footer
            ]
        page

    let FormTypes () = 
        JQuery.Mobile.Use()
        let home =
            let header =
                Div [Attr.Data "role" "header"] -< [
                     H1 [Text "Ice Cream Order Form"]
                ]
            let content =
                let checkbox (name: string) = 
                    Input [
                        Id name
                        Name name
                        Attr.Type "checkbox"
                        Attr.Class "custom"
                        ] -< [
                        Label [Attr.For name] -< [
                            Text name
                        ]
                    ]
                Div [Attr.Data "role" "content"] -< [
                    Form [
                        Attr.Action "#"
                        Method "get"
                        ] -< [
                        // Name Field
                        Div [Attr.Data "role" "fieldcontain"] -< [
                            Label [Attr.For "name"] -< [
                                Text "Your name:"
                            ]
                            Input [
                                Name "name"
                                Attr.Type "text"
                                Attr.Value ""
                            ]
                        ]
                        // Flavour field
                        Div [Attr.Data "role" "controlgroup"] -< [
                            Legend [
                                Text "Which flavours would you like?"
                            ]
                            checkbox "Vanilla"
                            checkbox "Chocolate"
                            checkbox "Strawberry"
                        ]
                        // Cones Field
                        Div [Attr.Data "role" "fieldcontain"] -< [
                            Label [Attr.For "quantity"] -< [
                                Text "Number of cones:"
                            ]
                            Input [
                                Id   "quantity"
                                Name "quantity"
                                Attr.Type "range"
                                Attr.Value "1"
                                Attr.Min "1" 
                                Attr.Max "100"
                            ]
                        ]
                        // Sprinkles Field
                        Div [Attr.Data "role" "fieldcontain"] -< [
                            Label [Attr.For "sprinkles"] -< [
                                Text "Sprinkles:"
                            ]
                            Select [
                                Id   "sprinkles"
                                Name "sprinkles"
                                Attr.Data "role" "slider"
                                ] -< [
                                Tags.Option [
                                    Attr.Value "on"
                                    Text "Yes"
                                ]
                                Tags.Option [
                                    Attr.Value "off"
                                    Text "No"
                                ]
                            ]
                        ]
                        // Store Field
                        Div [Attr.Data "role" "fieldcontain"] -< [
                            Label [Attr.For "store"] -< [
                                Text "Collect from store:"
                            ]
                            Select [
                                Id   "store"
                                Name "store"
                                ] -< [
                                Tags.Option [Attr.Value "mainStreet"] -< [
                                    Text "Main Street"
                                ]
                                Tags.Option [Attr.Value "libertyAvenue"] -< [
                                    Text "Liberty Avenue"
                                ]
                                Tags.Option [Attr.Value "circleSquare"] -< [
                                    Text "Circle Square"
                                ]
                                Tags.Option [Attr.Value "angelRoad"] -< [
                                    Text "Angel Road"
                                ]
                            ]
                        ]
                        Div [Attr.Class "ui-body ui-body-b"] -< [
                            FieldSet [Attr.Class "ui-grid-a"] -< [
                                Div [Attr.Class "ui-block-a"] -< [
                                    Button [
                                        Attr.Type "submit"
                                        Attr.Data "theme" "a"
                                        ] -< [
                                        Text "Cancel"
                                    ]
                                ]
                                Div [Attr.Class "ui-block-b"] -< [
                                    Button [
                                        Attr.Type "submit"
                                        Attr.Data "theme" "a"
                                        ] -< [
                                        Text "Order Ice Cream"
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            let page = 
                Div [
                    Id "formTypes"
                    Attr.Data "role" "page"
                    Attr.Data "url" "#formTypes"
                    ] -< [
                    header
                    content
                ]
            page
        home

    let EventTestPage () =
        let header =
            Div [Attr.Data "role" "header"] -< [
                H1 [Text "Tap me!"]
            ]
        let content =
            Div [Attr.Data "role" "content"] -< [
                P [Text "Swipe me!"]
            ]
        let footer =
            Div [Attr.Data "role" "footer"] -< [
                H4 [Text "Scroll me!"]
            ]
        JQuery.Mobile.Events.Tap.On(JQuery.JQuery.Of(header.Body),
            fun event -> 
                "Tapped on:" + string event.PageX + "," + string event.PageY
                |> JS.Alert
            )
        JQuery.Mobile.Events.Swipe.On(JQuery.JQuery.Of(content.Body),
            fun event -> 
                JS.Alert("Swipped on")
            )
        JQuery.Mobile.Events.ScrollStart.On(JQuery.JQuery.Of(footer.Body),
            fun event -> 
                JS.Alert("Scrolled on")
            )
        let page = 
            Div [
                Id "eventTest"
                Attr.Data "role" "page"
                Attr.Data "url" "#eventTest"
                ] -< [
                header
                content
                footer
            ]
        page

    [<SPAEntryPoint>]
    let Main =
        let simplePage = SimplePage ()
        let formTypes = FormTypes ()
        let eventTestPage = EventTestPage ()
        let index = IndexPage simplePage formTypes eventTestPage
        let pages =
            [
                index
                simplePage
                formTypes
                eventTestPage
            ]
        Div pages
        |>! OnAfterRender (fun _ ->
            pages |> List.iter (fun elt ->
                JQuery.Of(elt.Body)
                |> JQuery.Mobile.JQuery.Page
                |> ignore)
            JQuery.Of(index.Body)
            |> JQuery.Mobile.Instance.ChangePage)
        |> fun s -> s.AppendTo "main"
        
