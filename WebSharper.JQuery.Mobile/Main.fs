// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

module WebSharper.JQuery.Mobile.Main

open WebSharper.InterfaceGenerator

let ClassList : list<CodeModel.NamespaceEntity> =
    [
        Common.Positioning
        Common.Relation
        Common.Tolerance
        Common.Transition
        Common.IconPosition
        Common.Icon
        Common.PanelPosition
        Common.ButtonPosition
        Common.ControlGroupType
        Common.SwatchLetter

        Events.Event0
        Events.Event1
        Events.Event2

        Button.ButtonConfig
        Button.Button

        CheckBoxRadio.CheckBoxRadioConfig
        CheckBoxRadio.CheckBoxRadio

        Collapsible.CollapsibleConfig
        Collapsible.Collapsible

        CollapsibleSet.CollapsibleSetConfig
        CollapsibleSet.CollapsibleSet

        ControlGroup.ControlGroupConfig
        ControlGroup.ControlGroup

        Dialog.DialogConfig
        Dialog.Dialog

        Filterable.FilterableConfig
        Filterable.Filterable

        FlipSwitch.FlipSwitchConfig
        FlipSwitch.FlipSwitch

        ListView.ListViewConfig
        ListView.ListView

        Loader.LoaderConfig
        Loader.Loader

        NavBar.NavBarConfig
        NavBar.NavBar

        Page.PageConfig
        Page.Page

        PageContainer.PageContainerConfig
        PageContainer.PageLoadConfig
        PageContainer.PageChangeConfig
        PageContainer.PageContainer

        Panel.Cl
        Panel.PanelConfig
        Panel.Panel

        Popup.PopupConfig
        Popup.PopupOpenConfig
        Popup.Popup

        RangeSlider.RangeSliderConfig
        RangeSlider.RangeSlider

        SelectMenu.SelectMenuConfig
        SelectMenu.SelectMenu

        Slider.SliderConfig
        Slider.Slider

        Table.TableConfig
        Table.Table
        Table.CL

        ColumnToggleTable.ColumnToggleTableConfig
        ColumnToggleTable.ColumnToggleTable
        ColumnToggleTable.CL

        ReflowTable.ReflowTableConfig
        ReflowTable.ReflowTable
        ReflowTable.CL

        Tabs.TabsConfig
        Tabs.Tabs

        Toolbar.ToolbarConfig
        Toolbar.Toolbar

        TextInput.TextInputConfig
        TextInput.TextInput

        Definition.ButtonMarkup
        Definition.DegradeInputs
        Definition.Special
        Definition.Orientation
        Definition.OrientationChangeEventArgs
        Definition.PageChangeEventArgs
        Definition.PageBeforeLoadEventArgs
        Definition.PageLoadEventArgs
        Definition.PageLoadFailedEventArgs
        Definition.PageHideEventArgs
        Definition.PageShowEventArgs
        Definition.VMouseEventArgs
        Definition.Events
        Definition.URL
        Definition.Path
        Definition.Mobile
        Definition.JQuery
        Definition.TransitionFallbacks
    ]

let JQMAssembly =
    Assembly [
        Namespace "WebSharper.JQuery.Mobile" ClassList  
        Namespace "WebSharper.JQuery.Mobile.Resources" [
                Resource "JQueryMobileJs" "//code.jquery.com/mobile/1.5.0-alpha.1/jquery.mobile-1.5.0-alpha.1.min.js"
                |> fun r -> r.AssemblyWide()
                |> RequiresExternal [T<WebSharper.JQuery.Resources.JQuery>]
                Resource "JQueryMobileCss" "//code.jquery.com/mobile/1.5.0-alpha.1/jquery.mobile-1.5.0-alpha.1.min.css"
                |> fun r -> r.AssemblyWide()
            ]
//        Namespace "WebSharper.JQuery.Mobile.Enums" [
//            Definition.Enums.ButtonIcon
//            Definition.Enums.Theme
//        ]
    ]

open WebSharper.InterfaceGenerator

[<Sealed>]
type JQMExtension() =
    interface IExtension with
        member ext.Assembly = JQMAssembly

[<assembly: Extension(typeof<JQMExtension>)>]
do ()
