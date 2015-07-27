namespace WebSharper.JQuery.Mobile.Tests

open WebSharper.Html.Server
open WebSharper.Sitelets

type Action =
    | App

module Skin =
    open System.IO

    type Page =
        {
            Body : list<Content.HtmlElement>
        }

    let MainTemplate =
        Content.Template<Page>("~/Main.html")
            .With("body", fun x -> x.Body)

    let WithTemplate body ctx : Async<Content<Action>> =
        Content.WithTemplate MainTemplate
            {
                Body = body
            }

module Site =
    let App = Skin.WithTemplate [ Div [ new AppControl() ] ]

[<Sealed>]
type Sample() =
    interface IWebsite<Action> with
        member this.Sitelet = Sitelet.Content "/" App Site.App
        member this.Actions = [ App ]

[<assembly: Website(typeof<Sample>)>]
do ()
