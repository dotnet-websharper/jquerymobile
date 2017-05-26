namespace WebSharper.JQuery.Mobile.StandaloneTest

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Html
open WebSharper.UI.Next.Client

[<JavaScript>]
module Client =

    [<Inline "$.mobile.pageContainer(\"change\", $to, null)">]
    let ChangePage ``to`` = X<unit>

    let IndexPage () =
        JQuery.Mobile.Mobile.Use()
        let header =
            divAttr [
                attr.``data-`` "role" "header"
            ] [
                h1 [text "Main page"]
            ]
        let generateLink name id =
            aAttr [
                attr.``data-`` "role" "button"
                attr.href id
            ] [text name]
        let content =
            divAttr [
                attr.``data-`` "role" "content"
            ] [
                generateLink "Simple Page" "#simplePage"
                generateLink "Forms" "#formTypes"
                generateLink "Events" "" 
            ]

        divAttr [
            attr.id "indexPage"
            attr.``data-`` "role" "page"
            attr.``data-`` "url" "#indexPage"
        ] [
            header
            content
        ]

    let SimplePage () = 
        JQuery.Mobile.Mobile.Use()
        let header =
            divAttr [
                attr.``data-`` "role" "header"
            ] [
                h1 [text "Simple page"]
            ]
        let content =
            divAttr [attr.``data-`` "role" "content"] [
                 p [text "Lorem ipsum dolor sit amet, consectetur adipiscing"]
            ]
        let footer =
            divAttr [attr.``data-`` "role" "footer"] [
                 h4 [text "Page Footer"]
            ]
        let page = 
            divAttr [
                attr.id "simplePage"
                attr.``data-`` "role" "page"
                attr.``data-`` "url" "#simplePage"
            ] [
                aAttr [
                    attr.``data-`` "role" "button"
                    attr.href "#indexPage" 
                ] [
                    text "Back"
                ]
                header
                content
                footer
            ]
        page

    let FormTypes () = 
        JQuery.Mobile.Mobile.Use()
        let home =
            let header =
                divAttr [attr.``data-`` "role" "header"] [
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

                divAttr [attr.``data-`` "role" "content"] [
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
                        divAttr [Attr.Class "ui-body ui-body-b"] [
                            fieldsetAttr [Attr.Class "ui-grid-a"] [
                                divAttr [] [
                                    buttonAttr [
                                        attr.``data-`` "theme" "a"
                                        on.click (fun _ ev -> ev.PreventDefault(); JS.Alert("Order sent"))
                                    ] [
                                        text "Order Ice Cream"
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
                    aAttr [
                        attr.``data-`` "role" "button"
                        attr.href "#indexPage" 
                    ] [
                        text "Back"
                    ]
                    header
                    content
                ]
            page
        home

    [<SPAEntryPoint>]
    let Main =
        JQuery.Mobile.Mobile.Use()

        let simplePage = SimplePage()
        let formPage = FormTypes()
        let indexPage = IndexPage()

        let pages =
            [
                indexPage
                simplePage
                formPage
            ]

        let p = div (pages |> List.map (fun k -> k :> Doc))
        p.OnAfterRender(fun _ -> 
            pages
            |> List.iter (fun page ->
                JQuery.Of(page)
                |> JQuery.Mobile.Page.Init
            )
        )
        |> Doc.RunById "main"
