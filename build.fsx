#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.JQueryMobile", "2.5").References(fun r ->
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
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper.JQueryMobile-1.3.1"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/websharper.jquerymobile"
                Description = "WebSharper Extensions for JQuery Mobile 1.3.1"
                RequiresLicenseAcceptance = true })
        .Add(ext)

]
|> bt.Dispatch
