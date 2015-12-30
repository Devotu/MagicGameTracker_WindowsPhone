﻿#pragma checksum "C:\Projekt\MagicGameTracker_WindowsPhone\MagicDeckManagerMVVM\Sections\PlayerPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0D52EDAB185A1785BA162FA925CAF46B"
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
    
    
    public partial class PlayerPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl adcPlayerPage;
        
        internal MagicGameTracker.View.PlayerWinrate PlayerWinrateView;
        
        internal MagicGameTracker.View.PlayerCommonColors PlayerCommonColorsView;
        
        internal MagicGameTracker.Components.ColorsUsedGraph PlayerColorsUsedGraph;
        
        internal MagicGameTracker.View.PlayerWinrate ActivePlayerWinrateView;
        
        internal MagicGameTracker.View.PlayerCommonColors ActiveCommonColorsView;
        
        internal MagicGameTracker.Components.ColorsUsedGraph ActiveColorsUsedGraph;
        
        internal MagicGameTracker.View.PlayerWinrate TodayPlayerWinrateView;
        
        internal MagicGameTracker.View.PlayerCommonColors TodayPlayerCommonColorsView;
        
        internal MagicGameTracker.Components.ColorsUsedGraph TodayColorsUsedGraph;
        
        internal MagicGameTracker.Components.ColorsUsedGraph ColorsFoundInAciveDecksGraph;
        
        internal MagicGameTracker.Components.ColorsUsedGraph ColorsFoundInAllDecksGraph;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton bHelp;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/Sections/PlayerPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.adcPlayerPage = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("adcPlayerPage")));
            this.PlayerWinrateView = ((MagicGameTracker.View.PlayerWinrate)(this.FindName("PlayerWinrateView")));
            this.PlayerCommonColorsView = ((MagicGameTracker.View.PlayerCommonColors)(this.FindName("PlayerCommonColorsView")));
            this.PlayerColorsUsedGraph = ((MagicGameTracker.Components.ColorsUsedGraph)(this.FindName("PlayerColorsUsedGraph")));
            this.ActivePlayerWinrateView = ((MagicGameTracker.View.PlayerWinrate)(this.FindName("ActivePlayerWinrateView")));
            this.ActiveCommonColorsView = ((MagicGameTracker.View.PlayerCommonColors)(this.FindName("ActiveCommonColorsView")));
            this.ActiveColorsUsedGraph = ((MagicGameTracker.Components.ColorsUsedGraph)(this.FindName("ActiveColorsUsedGraph")));
            this.TodayPlayerWinrateView = ((MagicGameTracker.View.PlayerWinrate)(this.FindName("TodayPlayerWinrateView")));
            this.TodayPlayerCommonColorsView = ((MagicGameTracker.View.PlayerCommonColors)(this.FindName("TodayPlayerCommonColorsView")));
            this.TodayColorsUsedGraph = ((MagicGameTracker.Components.ColorsUsedGraph)(this.FindName("TodayColorsUsedGraph")));
            this.ColorsFoundInAciveDecksGraph = ((MagicGameTracker.Components.ColorsUsedGraph)(this.FindName("ColorsFoundInAciveDecksGraph")));
            this.ColorsFoundInAllDecksGraph = ((MagicGameTracker.Components.ColorsUsedGraph)(this.FindName("ColorsFoundInAllDecksGraph")));
            this.bHelp = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("bHelp")));
        }
    }
}

