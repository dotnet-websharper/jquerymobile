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

let ext =
    bt.WebSharper.Extension("IntelliFactory.WebSharper.JQuery.Mobile")
    |> fun main -> main.SourcesFromProject()

let tests =
    bt.WebSharper.HtmlWebsite("IntelliFactory.WebSharper.JQuery.Mobile.Tests")
    |> fun tests ->
        tests.SourcesFromProject().References(fun r ->
            [r.Project ext])

bt.Solution [
    ext
    tests

    bt.NuGet.CreatePackage()
        .Description("WebSharper Extensions to jQuery Mobile")
        .Configure(fun cfg ->
            { cfg with
                Authors = ["IntelliFactory"]
                RequiresLicenseAcceptance = true
                LicenseUrl = Some "http://websharper.com/licensing" })
        .Add(ext)

]
|> bt.Dispatch
