namespace WebSharper.JQuery.Mobile.StandaloneTest

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Html
open WebSharper.UI.Next.Client

[<JavaScript>]
module Client =

    let ChangeToPage (href: string) =
        JQuery.Mobile.PageContainer.Change(JQuery.Of(":mobile-pagecontainer"), href, new JQuery.Mobile.ChangePageConfig())

    let IndexPage () =
        JQuery.Mobile.Mobile.Use()
        let header =
            divAttr [
                attr.``data-`` "role" "toolbar"
                attr.``data-`` "type" "header"
            ] [
                h1 [text "Main page"]
            ]
        let generateLink name id =
            aAttr [
                attr.``data-`` "role" "button"
                on.click(fun _ _ -> ChangeToPage id)
            ] [text name]
        let content =
            divAttr [
                attr.``data-`` "role" "content"
                Attr.Class "ui-content"
            ] [
                generateLink "Simple Page" "#simplePage"
                generateLink "Forms" "#formTypes"
                generateLink "Events" "#eventTest" 
            ]

        divAttr [
            attr.id "indexPage"
            attr.``data-`` "role" "page"
            attr.``data-`` "url" "#indexPage"
            on.afterRender(fun el ->
                JQuery.Mobile.Mobile.EnhanceWithin(JQuery.Of(el))
                let tcfg = 
                    JQuery.Mobile.ToolbarConfig()
                JQuery.Mobile.Toolbar.Init(JQuery.Of(el).Find("[data-role=header]"), tcfg)
                JQuery.Mobile.Toolbar.Init(JQuery.Of(el).Find("[data-role=footer]"), tcfg)
                JQuery.Mobile.Mobile.Instance.ResetActivePageHeight()
            )
        ] [
            header
            content
        ]

    let SimplePage () = 
        JQuery.Mobile.Mobile.Use()
        let header =
            divAttr [
                attr.``data-`` "role" "toolbar"
                attr.``data-`` "type" "header"
                attr.``data-`` "position" "fixed"
                attr.``data-`` "fullscreen" "true"
            ] [
                h1 [text "Simple page"]
            ]
        let content =
            divAttr [attr.``data-`` "role" "content"; Attr.Class "ui-content"] [
                p [text "Lorem ipsum dolor sit amet, consectetur adipiscing"] 
                aAttr [
                    attr.``data-`` "role" "button"
                    attr.href "#indexPage" 
                ] [
                    text "Back"
                ]
            ]
        let footer =
            divAttr [
                attr.``data-`` "role" "toolbar"
                attr.``data-`` "type" "footer"
                attr.``data-`` "position" "fixed"
                on.afterRender(fun el ->
                    JQuery.Of(el) |> JQuery.Mobile.Toolbar.Init
                )
            ] [
                h4 [text "Page Footer"]
            ]
        let page = 
            divAttr [
                attr.id "simplePage"
                attr.``data-`` "role" "page"
                attr.``data-`` "url" "#simplePage"
            ] [
                header
                content
                footer
            ]
        page

    let FormTypes () = 
        JQuery.Mobile.Mobile.Use()
        let home =
            let header =
                divAttr [
                    attr.``data-`` "role" "toolbar"
                    attr.``data-`` "type" "header"
                    attr.``data-`` "position" "fixed"
                    attr.``data-`` "fullscreen" "true"
                    attr.``data-`` "theme" "b"
                    Attr.Create "role" "header"
                ] [
                     h1 [text "Ice Cream Order Form"]
                ]
            let content =
                let checkbox (name: string) =
                    let rvVar = Var.Create ""
                    divAttr [] [
                        labelAttr [attr.``for`` name] [
                            text name
                        ]
                        Doc.Input [
                            attr.id name
                            attr.name name
                            attr.``type`` "checkbox"
                            Attr.Class "custom"
                        ]  rvVar
                    ]

                let optionList =
                    [
                        "Main Street"
                        "Liberty Avenue"
                        "Circle Square"
                        "Angel Road"
                    ]

                divAttr [attr.``data-`` "role" "content"; Attr.Class "ui-content"] [
                    formAttr [
                        attr.action "#"
                    ] [
                        // Name Field
                        divAttr [attr.``data-`` "role" "fieldcontain"] [
                            labelAttr [attr.``for`` "name"] [
                                text "Your name:"
                            ]
                            Doc.Input [
                                attr.name "name"
                                attr.``type`` "text"
                            ] (Var.Create "")
                        ]
                        // Flavour field
                        divAttr [attr.``data-`` "role" "controlgroup"] [
                            legend [
                                text "Which flavours would you like?"
                            ]
                            checkbox "Vanilla"
                            checkbox "Chocolate"
                            checkbox "Strawberry"
                        ]
                        // Cones Field
                        divAttr [attr.``data-`` "role" "fieldcontain"] [
                            labelAttr [attr.``for`` "quantity"] [
                                text "Number of cones:"
                            ]
                            Doc.Input [
                                attr.id   "quantity"
                                attr.name "quantity"
                                attr.``type`` "range"
                                attr.min "1" 
                                attr.max "100"
                            ] (Var.Create "1")
                        ]
                        // Store Field
                        divAttr [attr.``data-`` "role" "fieldcontain"] [
                            labelAttr [attr.``for`` "store"] [
                                text "Collect from store:"
                            ]
                            Doc.Select [
                                attr.id   "store"
                                attr.name "store"
                            ] id optionList (Var.Create "Main Street")

                        ]
                        divAttr [Attr.Class "ui-body ui-body-a"] [
                            fieldsetAttr [Attr.Class "ui-grid-a"] [
                                divAttr [] [
                                    buttonAttr [
                                        on.click (fun _ ev -> ev.PreventDefault(); JS.Alert("Order sent"))
                                    ] [
                                        text "Order Ice Cream"
                                    ]
                                ]
                                divAttr [] [                
                                    aAttr [
                                        attr.``data-`` "role" "button"
                                        attr.href "#indexPage" 
                                    ] [
                                        text "Back"
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            let page = 
                divAttr [
                    attr.id "formTypes"
                    attr.``data-`` "role" "page"
                    attr.``data-`` "url" "#formTypes"
                ] [
                    header
                    content
                ]
            page
        home

    let EventTestPage () =
        let header =
            divAttr [
                attr.``data-`` "role" "toolbar"
                attr.``data-`` "type" "header"
            ] [
                h1 [text "Tap me!"]
            ]
        let content =
            divAttr [attr.``data-`` "role" "content"; Attr.Class "ui-content"] [
                p [text "Swipe me!"]
                aAttr [
                    attr.``data-`` "role" "button"
                    attr.href "#indexPage" 
                ] [
                    text "Back"
                ]
            ]
        let footer =
            divAttr [
                attr.``data-`` "role" "toolbar"
                attr.``data-`` "type" "footer"
            ] [
                h4 [text "Scroll me!"]
            ]
        JQuery.Mobile.Events.Tap.On(JQuery.JQuery.Of(header.Dom),
            fun event -> 
                "Tapped on:" + string event.PageX + "," + string event.PageY
                |> JS.Alert
            )
        JQuery.Mobile.Events.Swipe.On(JQuery.JQuery.Of(content.Dom),
            fun event -> 
                JS.Alert("Swipped on")
            )
        JQuery.Mobile.Events.ScrollStart.On(JQuery.JQuery.Of(footer.Dom),
            fun event -> 
                JS.Alert("Scrolled on")
            )
        let page = 
            divAttr [
                attr.id "eventTest"
                attr.``data-`` "role" "page"
                attr.``data-`` "url" "#eventTest"
            ] [
                header
                content
                footer
            ]
        page

    [<SPAEntryPoint>]
    let Main =
        JQuery.Mobile.Mobile.Use()

        let simplePage = SimplePage()
        let formPage = FormTypes()
        let eventPage = EventTestPage()
        let indexPage = IndexPage()

        let pages =
            [
                indexPage
                simplePage
                formPage
                eventPage
            ]

        let p = div (pages |> List.map (fun k -> k :> Doc))
        p.OnAfterRender(fun _ -> 
            pages
            |> List.iter (fun page ->
                JQuery.Of(page)
                |> JQuery.Mobile.Page.Init
            )
        )
        |> Doc.RunReplaceById "main"
