#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("IntelliFactory.WebSharper.JQuery.Mobile", "2.5").References(fun r ->
        [
            r.Assembly "System.Runtime.Serialization"
            r.Assembly "System.ServiceModel.Web"
            r.Assembly "System.Web"
            r.Assembly "System.Xml"
        ])

let main =
    bt.WebSharper.Extension("IntelliFactory.WebSharper.JQuery.Mobile")
    |> FSharpConfig.BaseDir.Custom("IntelliFactory.WebSharper.JQuery.Mobile")
    |> fun main -> main.SourcesFromProject()

let tests =
    bt.WebSharper.Library("IntelliFactory.WebSharper.JQuery.Mobile.Tests")
    |> FSharpConfig.BaseDir.Custom("IntelliFactory.WebSharper.JQuery.Mobile.Tests")
    |> fun tests ->
        tests.SourcesFromProject().References(fun r ->
            [r.Project main])

let web =
    bt.WebSharper.HostWebsite("Web")
        .References(fun r ->
            [
                r.Project main
                r.Project tests
                r.NuGet("WebSharper").At(["/tools/net45/IntelliFactory.Xml.dll"]).Reference()
            ])

bt.Solution [

    main
    tests
    web

    bt.NuGet.CreatePackage()
        .Description("Bindings to JQuery mobile")
        .Add(main)

]
|> bt.Dispatch
