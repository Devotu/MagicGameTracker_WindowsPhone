﻿#pragma checksum "C:\Users\Otto\Documents\GitHub\MagicGameTracker_WindowsPhone\MagicDeckManagerMVVM\Sections\OpponentPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A88BC226793CA325E5F91A94AB01FAD6"
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
using MagicGameTracker.View;
using Microsoft.Advertising.Mobile.UI;
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
    
    
    public partial class OpponentPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl adOpponentPage;
        
        internal MagicGameTracker.View.PlayerWinrate WinrateAgainstOpponentView;
        
        internal MagicGameTracker.Components.WinrateHistoryGraphSlim WinrateAgainstOpponentGraph;
        
        internal MagicGameTracker.Components.ColorsUsedGraphSlim ColorsUsedAgainstOpponentGraph;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton bHelp;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton bDeleteGame;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/Sections/OpponentPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.adOpponentPage = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("adOpponentPage")));
            this.WinrateAgainstOpponentView = ((MagicGameTracker.View.PlayerWinrate)(this.FindName("WinrateAgainstOpponentView")));
            this.WinrateAgainstOpponentGraph = ((MagicGameTracker.Components.WinrateHistoryGraphSlim)(this.FindName("WinrateAgainstOpponentGraph")));
            this.ColorsUsedAgainstOpponentGraph = ((MagicGameTracker.Components.ColorsUsedGraphSlim)(this.FindName("ColorsUsedAgainstOpponentGraph")));
            this.bHelp = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("bHelp")));
            this.bDeleteGame = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("bDeleteGame")));
        }
    }
}

