#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.JQueryMobile")
        .VersionFrom("WebSharper")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun fw -> fw.Net40)

let ext =
    bt.WebSharper4.Extension("WebSharper.JQuery.Mobile")
    |> fun main -> main.SourcesFromProject()

let tests =
    bt.WebSharper4.HtmlWebsite("WebSharper.JQuery.Mobile.Tests")
    |> fun tests ->
        tests.SourcesFromProject().References(fun r ->
            [
                r.NuGet("WebSharper.Html").Latest(true).ForceFoundVersion().Reference()
                r.Project ext
            ])

let sample =
    bt.WebSharper4.BundleWebsite("WebSharper.JQuery.Mobile.StandaloneTest")
    |> fun st ->
        st.SourcesFromProject().References(fun r ->
            [
                r.NuGet("WebSharper.UI.Next").Latest(true).Reference()
                r.Project(ext)
            ]
        )

bt.Solution [
    ext
    sample
//    tests

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper.JQueryMobile-1.5.0-alpha"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/websharper.jquerymobile"
                Description = "WebSharper Extensions for JQuery Mobile 1.5.0-alpha"
                RequiresLicenseAcceptance = true })
        .Add(ext)

]
|> bt.Dispatch
