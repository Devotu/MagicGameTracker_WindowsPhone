﻿#pragma checksum "C:\Projekt\MagicGameTracker_WindowsPhone\MagicDeckManagerMVVM\View\NewDeckView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8A7A00A97AF46C45C2B8A5BF18A4B97D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MagicGameTracker.Components;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MagicGameTracker.View {
    
    
    public partial class NewDeckView : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock lblName;
        
        internal System.Windows.Controls.TextBox tbName;
        
        internal MagicGameTracker.Components.PickFormatComponent FormatPicker;
        
        internal System.Windows.Controls.Grid ColorPanel;
        
        internal MagicGameTracker.Components.ColorPicker ColorPicker;
        
        internal System.Windows.Controls.TextBlock lblTheme;
        
        internal System.Windows.Controls.TextBox tbTheme;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/View/NewDeckView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.lblName = ((System.Windows.Controls.TextBlock)(this.FindName("lblName")));
            this.tbName = ((System.Windows.Controls.TextBox)(this.FindName("tbName")));
            this.FormatPicker = ((MagicGameTracker.Components.PickFormatComponent)(this.FindName("FormatPicker")));
            this.ColorPanel = ((System.Windows.Controls.Grid)(this.FindName("ColorPanel")));
            this.ColorPicker = ((MagicGameTracker.Components.ColorPicker)(this.FindName("ColorPicker")));
            this.lblTheme = ((System.Windows.Controls.TextBlock)(this.FindName("lblTheme")));
            this.tbTheme = ((System.Windows.Controls.TextBox)(this.FindName("tbTheme")));
        }
    }
}

