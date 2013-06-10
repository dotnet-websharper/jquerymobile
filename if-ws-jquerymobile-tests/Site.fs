namespace IntelliFactory.WebSharper.JQuery.Mobile.Tests

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets

type Action = | App

module Skin =
    open System.IO
    
    type Page =
        {
            Body : list<Content.HtmlElement>
        }

    let MainTemplate =
        let path = Path.Combine(__SOURCE_DIRECTORY__, "main-template.html")
        Content.Template<Page>(path)
            .With("body", fun x -> x.Body)

    let WithTemplate body : Content<Action> =
        Content.WithTemplate MainTemplate <| fun context ->
            {
                Body =  body context
            }

module Site = 
    let App = Skin.WithTemplate <| fun ctx -> [ Div [ new AppControl() ] ]

type sampleWebsite() =     
    interface IWebsite<Action> with       
        member this.Sitelet = Sitelet.Content "/" App Site.App
        member this.Actions = [ App ]

[<assembly: WebsiteAttribute(typeof<sampleWebsite>)>]
()
