namespace WebSharper.JQuery.Mobile.StandaloneTest

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Html
open WebSharper.UI.Next.Client

[<JavaScript>]
module Client =

    [<SPAEntryPoint>]
    let Main =
        // To trigger the dependency
        JQuery.Mobile.Mobile.Use()
