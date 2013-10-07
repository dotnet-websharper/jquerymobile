# Overview

This extension provides WebSharper bindings to the [jQuery
Mobile](http://jquerymobile.com) library, version 1.3.1, that provides
support for mobile web development.  The library targets any of the
following platforms:

  * iOS
  * Android
  * BlackBerry
  * Bada
  * Windows Phone
  * Palm Web OS
  * Symbian
  * Meego

With the WebSharper.JQuery.Mobile you can develop WebSharper apps that
use jQuery Mobile.

## Usage

TODO: update documentation.

### Creating Pages

[JQuery Mobile](http://jquerymobile.com) uses the `data-*` Html5
attributes to mark each of the elements in the page.  It automatically
adds CSS classes in order to make them more suitable for mobile
development.

One of the most important data attributes is the "role" attribute. The
following values are used commonly

  * `page`: Create pseudo-pages in the same page. This avoids 
    long refreshing times.
  * `header`: Top part of the page.
  * `content`: Middle part of the page.
  * `footer`: Bottom of the page.
  * `button`: Transforms a link into a button that is easier to target in a 
    touch based application.
  * `collapsible`: A collapsible element that can be minimized in order to 
    save space
  
Writing a simple page can be done by simply setting this attributes in
the page.

First, some helpers to set the custom attributes to an element:

```fsharp
[<JavaScript>]
let SetAttr attr value elem =
    elem
    |>! OnAfterRender (fun elem ->
            JQuery.JQuery.Of(elem.Body).Attr(attr, value).Ignore)

[<JavaScript>]
let AddDataRole role elem = SetAttr "data-role" role elem
```
        
Then it is a matter of adding the right attributes to each of the
parts of the website. Since JQuery Mobile works automatically, it is
sometimes better to make sure the resource is added to the page. The
dummy `UseJQueryMobile` will force the static analyzer to add the
reference of the JQuery Mobile extension.

```fsharp
[<JavaScript>]
let SimplePage () = 
    JQuery.Mobile.JQuery.UseJQueryMobile // should trigger webresource.
    let header =
        Div [H1 [Text "Page Title"]]
        |> AddDataRole "header"

    let content =
        Div [P [Text "Lorem ipsum dolor sit amet, consectetur adipiscing"]]
        |> AddDataRole "content"

    let footer =
        Div [H4 [Text "Page Footer"]]
        |> AddDataRole "footer"

    let page = 
        Div [header
             content
             footer]
        |> AddDataRole "page"

  page    
```

### Using the jQuery Mobile object

JQuery also exposes some additional events and configuration
properties documented in [their
website](http://jquerymobile.com/demos/1.0a2). To get access, build
the jQuery object under the `Mobile` namespace. Is possible to build
it from any jQuery object as it's shown in the following example:

```fsharp
JQuery.Mobile.JQuery.Of(JQuery.JQuery.Of(header.Body)).Tap(
    fun _ event -> 
        JavaScript.Alert("Tapped on: " + string event.PageX + "," + string event.PageY)
    ).Base.Ignore
```

### Configuration properties and utilities

They jQuery Mobile also provides different utilities and configuration
values. These are available under the `Mobile` property. For example:

```fsharp
JQuery.Mobile.JQuery.Mobile.DefaultTransition
```

