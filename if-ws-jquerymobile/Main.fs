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
        Common.Icon
        Common.IconPosition
        Common.Positioning
        Common.Relation
        Common.Tolerance
        Common.Transition
        Events.Event0
        Generic - Events.Event1
        Page.Deferred
        Page.Page
        Page.PageBeforeLoadEvent
        Page.PageChangeEvent
        Page.PageHideEvent
        Page.PageLoadConfig
        Page.PageLoadEvent
        Page.PageLoadFailedEvent
        Page.PageShowEvent
        Dialog.Dialog
        FixedToolbar.FixedToolbar
        FixedToolbar.FixedToolbarConfig
        Button.Button
        Button.ButtonConfig
        Popup.Popup
        Popup.PopupConfig
        Popup.PopupOpenConfig
        Collapsible.Collapsible
        Collapsible.CollapsibleConfig
        Accordion.Accordion
        Accordion.AccordionConfig
        TextInput.TextInput
        TextInput.TextInputConfig
        Slider.Slider
        Slider.SliderConfig
        CheckBoxRadio.CheckBoxRadio
        CheckBoxRadio.CheckBoxRadioConfig
        SelectMenu.SelectMenu
        SelectMenu.SelectMenuConfig
        ListView.ListView
        ListView.ListViewConfig
        Definition.ButtonMarkup
        Definition.ChangePageConfig
        Definition.Events
        Definition.JQuery
        Definition.LoadingConfig
        Definition.Mobile
        Definition.Orientation
        Definition.OrientationChangeEventArgs
        Definition.Path
        Definition.Special
        Definition.URL
        Definition.VMouseEventArgs
    ]

let Assembly =
    Assembly [
        Namespace "IntelliFactory.WebSharper.JQuery.Mobile" ClassList
        Namespace "IntelliFactory.WebSharper.JQuery.Mobile.Enums" [
            Definition.Enums.ButtonIcon
            Definition.Enums.Theme
        ]
    ]

Compiler.Compile stdout Assembly
