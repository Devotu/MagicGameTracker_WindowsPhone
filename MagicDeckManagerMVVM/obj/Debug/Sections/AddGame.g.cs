﻿#pragma checksum "C:\Projekt\MagicDeckManagerMVVM\MagicDeckManagerMVVM\Sections\AddGame.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2C3923CC98F27D644B716FD13B0A3175"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MagicGameTracker.View;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
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
    
    
    public partial class AddGame : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot AddGamePivot;
        
        internal Microsoft.Phone.Controls.PivotItem PivotItemAddGame;
        
        internal MagicGameTracker.View.AddGameView AddGameView;
        
        internal Microsoft.Phone.Controls.PivotItem PivotItemTrackLife;
        
        internal MagicGameTracker.View.TrackLifeView TrackLifeView;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton bHelp;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton bSave;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton bCancel;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/Sections/AddGame.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.AddGamePivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("AddGamePivot")));
            this.PivotItemAddGame = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotItemAddGame")));
            this.AddGameView = ((MagicGameTracker.View.AddGameView)(this.FindName("AddGameView")));
            this.PivotItemTrackLife = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotItemTrackLife")));
            this.TrackLifeView = ((MagicGameTracker.View.TrackLifeView)(this.FindName("TrackLifeView")));
            this.bHelp = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("bHelp")));
            this.bSave = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("bSave")));
            this.bCancel = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("bCancel")));
        }
    }
}

