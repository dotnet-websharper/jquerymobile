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
        let generateLink name =
            aAttr [
                attr.``data-`` "role" "button"
                on.click(fun _ _ -> JS.Alert(name + " is clicked"))
            ] [text name]
        let content =
            divAttr [
                attr.``data-`` "role" "content"
            ] [
                generateLink "Simple Page"
                generateLink "Forms"
                generateLink "Events"
            ]

        divAttr [
            attr.id "mainPage"
            attr.``data-`` "role" "page"
            attr.``data-`` "url" "#indexPage"
        ] [
            header
            content
        ]

    [<SPAEntryPoint>]
    let Main =
        JQuery.Mobile.Mobile.Use()

        let indexPage = IndexPage()

        let pages =
            [
                indexPage
            ]

        let p = div (pages |> List.map (fun k -> k :> Doc))
        p.OnAfterRender(fun _ -> 
            pages
            |> List.iter (fun page ->
                JQuery.Of(page)
                |> JQuery.Mobile.Page.Init
            )
            JQuery.Of(p.Dom)
            |> ChangePage
        )
        |> Doc.RunById "main"
