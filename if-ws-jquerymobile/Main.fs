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

let ClassList : list<CodeModel.TypeDeclaration> =
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
        Definition.OrientationChangeEvent
        Definition.Path
        Definition.Special
        Definition.URL
    ]

let Assembly =
    Assembly [Namespace "IntelliFactory.WebSharper.JQuery.Mobile" ClassList]

Compiler.Compile stdout Assembly
