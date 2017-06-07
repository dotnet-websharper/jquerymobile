#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("Zafir.JQueryMobile")
        .VersionFrom("Zafir")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun fw -> fw.Net40)

let ext =
    bt.Zafir.Extension("WebSharper.JQuery.Mobile")
    |> fun main -> main.SourcesFromProject()

let tests =
    bt.Zafir.HtmlWebsite("WebSharper.JQuery.Mobile.Tests")
    |> fun tests ->
        tests.SourcesFromProject().References(fun r ->
            [
                r.NuGet("Zafir.Html").Latest(true).ForceFoundVersion().Reference()
                r.Project ext
            ])

let sample =
    bt.Zafir.BundleWebsite("WebSharper.JQuery.Mobile.StandaloneTest")
    |> fun st ->
        st.SourcesFromProject().References(fun r ->
            [
                r.NuGet("Zafir.UI.Next").Latest(true).Reference()
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
                Title = Some "Zafir.JQueryMobile-1.5.0-alpha"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/websharper.jquerymobile"
                Description = "Zafir Extensions for JQuery Mobile 1.5.0-alpha"
                RequiresLicenseAcceptance = true })
        .Add(ext)

]
|> bt.Dispatch
