namespace WebSharper.JQuery.Mobile.StandaloneTest

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.JQuery.Mobile
open WebSharper.UI
open WebSharper.UI.Html
open WebSharper.UI.Client

[<JavaScript>]
module Client =

    [<SPAEntryPoint>]
    let Main =
        // To trigger the dependency
        Mobile.Use()
