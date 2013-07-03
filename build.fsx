#if BOOT
open Fake
module FB = Fake.Boot
FB.Prepare {
    FB.Config.Default __SOURCE_DIRECTORY__ with
        NuGetDependencies =
            let ( ! ) x = FB.NuGetDependency.Create x
            [
                !"IntelliFactory.Build"
                !"WebSharper"
            ]
}
#else
#load ".build/boot.fsx"

open System
open System.IO
open Fake
module B = IntelliFactory.Build.CommonBuildSetup
module F = IntelliFactory.Build.FileSystem
module NG = IntelliFactory.Build.NuGetUtils

let ( +/ ) a b = Path.Combine(a, b)
let RootDir = __SOURCE_DIRECTORY__
let T x f = Target x f; x
let DotBuildDir = RootDir +/ ".build"
let PackagesDir = RootDir +/ "packages"
let ToolsDir = PackagesDir +/ "tools"

module Config =

    let PackageId = "WebSharper.JQuery.Mobile"
    let AssemblyVersion = Version "2.5"
    let VersionSuffix = "alpha"
    let NuGetVersion = NG.ComputeVersion PackageId (global.NuGet.SemanticVersion(AssemblyVersion, VersionSuffix))

    let FileVersion =
        let v = NuGetVersion.Version
        let bn = environVarOrNone "BUILD_NUMBER"
        match bn with
        | None -> v
        | Some bn -> Version(v.Major, v.Minor, v.Build, int bn)

    let Company = "IntelliFactory"
    let Description = "WebSharper bindings to jQuery Mobile"
    let LicenseUrl = "http://websharper.com/licensing"
    let Tags = ["Web"; "JavaScript"; "F#"]
    let Website = "http://bitbucket.org/IntelliFactory/if-ws-jquerymobile"

let Metadata =
    let m = B.Metadata.Create()
    m.AssemblyVersion <- Some Config.AssemblyVersion
    m.Author <- Some Config.Company
    m.Description <- Some Config.Description
    m.FileVersion <- Some Config.FileVersion
    m.Product <- Some Config.PackageId
    m.VersionSuffix <- Some Config.VersionSuffix
    m.Website <- Some Config.Website
    m

[<AutoOpen>]
module Extensions =

    type B.BuildConfiguration with
        static member Release(v: B.FrameworkVersion)(deps: list<string>) : B.BuildConfiguration =
            {
                ConfigurationName = "Release"
                Debug = false
                FrameworkVersion = v
                NuGetDependencies =
                    new global.NuGet.PackageDependencySet(
                        v.ToFrameworkName(),
                        [for d in deps -> global.NuGet.PackageDependency(d)]
                    )
            }

    type B.Solution with

        static member Standard(rootDir: string, m: B.Metadata, ?prefix: string) =
            fun (ps: list<string -> B.Project>) ->
                let ps = [for p in ps -> p rootDir]
                B.Solution(rootDir, Metadata = m, Projects = ps, Prefix = prefix)

        member this.BuildSync(?opts: B.MSBuildOptions) =
            this.MSBuild(?options=opts)
            |> Async.RunSynchronously

        member this.CleanSync(?opts: B.MSBuildOptions) =
            let opts : B.MSBuildOptions =
                match opts with
                | Some opts ->
                    { opts with Targets = ["Clean"] }
                | None ->
                    {
                        BuildConfiguration = None
                        Properties = Map.empty
                        Targets = ["Clean"]
                    }
            this.MSBuild opts
            |> Async.RunSynchronously

    type B.Project with

        static member FSharp(name: string)(configs: list<B.BuildConfiguration>)(rootDir: string) : B.Project =
            {
                Name = name
                MSBuildProjectFilePath = Some (rootDir +/ name +/ (name + ".fsproj"))
                BuildConfigurations = configs
            }

        static member CSharp(name: string)(configs: list<B.BuildConfiguration>)(rootDir: string) : B.Project =
            {
                Name = name
                MSBuildProjectFilePath = Some (rootDir +/ name +/ (name + ".csproj"))
                BuildConfigurations = configs
            }

let Deps = ["WebSharper"]
let C40 = B.BuildConfiguration.Release B.Net40 Deps
let Configs = [C40]

let NuGetPackageFile =
    DotBuildDir +/ sprintf "%s.%O.nupkg" Config.PackageId Config.NuGetVersion

let ComputePublishedFiles (c: B.BuildConfiguration) =
    let config = "Release-" + c.FrameworkVersion.GetMSBuildLiteral()
    let uid = "IntelliFactory.WebSharper.JQuery.Mobile"
    let prefix = RootDir +/ uid +/ "bin" +/ config
    (!+ (prefix +/ uid + ".dll")
        ++ (prefix +/ uid + ".xml"))
    |> Scan

/// TODO: helpers for buliding packages from a solution spec.
let BuildNuGet = T "BuildNuGet" <| fun () ->
    let content =
        use out = new MemoryStream()
        let builder = new NuGet.PackageBuilder()
        builder.Id <- Config.PackageId
        builder.Version <- Config.NuGetVersion
        builder.Authors.Add(Config.Company) |> ignore
        builder.Owners.Add(Config.Company) |> ignore
        builder.LicenseUrl <- Uri(Config.LicenseUrl)
        builder.ProjectUrl <- Uri(Config.Website)
        builder.Copyright <- String.Format("Copyright (c) {0} {1}", DateTime.Now.Year, Config.Company)
        builder.Description <- Config.Description
        Config.Tags
        |> Seq.iter (builder.Tags.Add >> ignore)
        for c in Configs do
            ComputePublishedFiles c
            |> Seq.map (fun file ->
                let ppf = global.NuGet.PhysicalPackageFile()
                ppf.SourcePath <- file
                ppf.TargetPath <- "lib" +/ c.FrameworkVersion.GetNuGetLiteral() +/ Path.GetFileName(file)
                ppf)
            |> Seq.distinctBy (fun file -> file.TargetPath)
            |> Seq.iter builder.Files.Add
        builder.Save(out)
        F.Binary.FromBytes (out.ToArray())
        |> F.BinaryContent
    content.WriteFile(NuGetPackageFile)
    tracefn "Written %s" NuGetPackageFile


let MainSolution =
    B.Solution.Standard(RootDir, Metadata) [
        B.Project.FSharp "IntelliFactory.WebSharper.JQuery.Mobile" Configs
        B.Project.FSharp "IntelliFactory.WebSharper.JQuery.Mobile.Tests" Configs
        B.Project.CSharp "Web" [C40]
    ]

let BuildMain = T "BuildMain" MainSolution.BuildSync
let CleanMain = T "CleanMain" MainSolution.CleanSync

let Build = T "Build" ignore
let Clean = T "Clean" ignore

BuildMain ==> BuildNuGet ==> Build
CleanMain ==> Clean

let Prepare =
    T "Prepare" <| fun () ->
        B.Prepare (printfn "%s") RootDir

RunTargetOrDefault Build

#endif


