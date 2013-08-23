// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2012.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

module IntelliFactory.WebSharper.JQuery.Mobile.Main

open IntelliFactory.WebSharper.InterfaceGenerator

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
        Generic - Events.Event1

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

        FixedToolbar.FixedToolbarConfig
        FixedToolbar.FixedToolbar

        Footer.Footer // unnecessary class?

        Header.Header // unnecessary class?

        ListView.ListViewConfig
        ListView.ListView

        NavBar.NavBarConfig
        NavBar.NavBar

        Page.PageConfig
        Page.Page

        PageLoading.PageLoadingConfig
        PageLoading.PageLoading

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

        ColumnToggleTable.ColumnToggleTableConfig
        ColumnToggleTable.ColumnToggleTable

        ReflowTable.ReflowTableConfig
        ReflowTable.ReflowTable

        TextInput.TextInputConfig
        TextInput.TextInput

        Definition.ButtonMarkup
        Definition.PageLoadConfig
        Definition.Deferred
        Definition.PageChangeConfig
        Definition.LoadingConfig
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
    ]

let JQMAssembly =
    Assembly [
        Namespace "IntelliFactory.WebSharper.JQuery.Mobile" ClassList  
        Namespace "IntelliFactory.WebSharper.JQuery.Mobile.Resources" [
                Resource "JQueryMobileJs" "//code.jquery.com/mobile/1.3.1/jquery.mobile-1.3.1.min.js"
                |> fun r -> r.AssemblyWide()
                |> RequiresExternal [T<IntelliFactory.WebSharper.JQuery.Resources.JQuery>]
                Resource "JQueryMobileCss" "//code.jquery.com/mobile/1.3.1/jquery.mobile-1.3.1.min.css"
                |> fun r -> r.AssemblyWide()
            ]
//        Namespace "IntelliFactory.WebSharper.JQuery.Mobile.Enums" [
//            Definition.Enums.ButtonIcon
//            Definition.Enums.Theme
//        ]
    ]

open IntelliFactory.WebSharper.InterfaceGenerator

[<Sealed>]
type JQMExtension() =
    interface IExtension with
        member ext.Assembly = JQMAssembly

[<assembly: Extension(typeof<JQMExtension>)>]
do ()
