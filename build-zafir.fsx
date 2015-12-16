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
                r.NuGet("Zafir.Html").Reference()
                r.Project ext
            ])

bt.Solution [
    ext
//    tests

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "Zafir.JQueryMobile-1.4.2"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/websharper.jquerymobile"
                Description = "Zafir Extensions for JQuery Mobile 1.4.2"
                RequiresLicenseAcceptance = true })
        .Add(ext)

]
|> bt.Dispatch
