﻿#pragma checksum "C:\Users\Otto\Documents\GitHub\MagicGameTracker_WindowsPhone\MagicDeckManagerMVVM\Sections\ExportPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5CA612F25888B9E3C68A7C679083DBD8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MagicGameTracker.View;
using Microsoft.Phone.Controls;
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


namespace MagicGameTracker.Sections {
    
    
    public partial class ExportPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ExportPanel;
        
        internal MagicGameTracker.View.ExportView ExportView;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/Sections/ExportPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ExportPanel = ((System.Windows.Controls.Grid)(this.FindName("ExportPanel")));
            this.ExportView = ((MagicGameTracker.View.ExportView)(this.FindName("ExportView")));
        }
    }
}
