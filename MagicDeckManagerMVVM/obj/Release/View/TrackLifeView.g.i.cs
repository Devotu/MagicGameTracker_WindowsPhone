﻿#pragma checksum "C:\Users\Otto\Documents\GitHub\MagicGameTracker_WindowsPhone\MagicDeckManagerMVVM\View\TrackLifeView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1606F6D2067D9B2C97615F19DF4BECE3"
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
using Microsoft.Advertising.Mobile.UI;
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
    
    
    public partial class TrackLifeView : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal MagicGameTracker.View.LifeCounterView OpponentLifeCounterView;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl adLifeTrackerView;
        
        internal MagicGameTracker.View.LifeCounterView PlayerLifeCounterView;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/View/TrackLifeView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.OpponentLifeCounterView = ((MagicGameTracker.View.LifeCounterView)(this.FindName("OpponentLifeCounterView")));
            this.adLifeTrackerView = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("adLifeTrackerView")));
            this.PlayerLifeCounterView = ((MagicGameTracker.View.LifeCounterView)(this.FindName("PlayerLifeCounterView")));
        }
    }
}

