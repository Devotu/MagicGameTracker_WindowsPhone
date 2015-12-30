﻿#pragma checksum "C:\Projekt\MagicDeckManagerMVVM\MagicDeckManagerMVVM\Sections\OpponentPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "23023961B26AE9F1104AB60D6B2091F0"
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
        
        internal Microsoft.Advertising.Mobile.UI.AdControl adcOpponentPage;
        
        internal MagicGameTracker.View.PlayerWinrate PlayerWinrateAgainstOpponentView;
        
        internal MagicGameTracker.View.PlayerCommonColors PlayerColorsAgainstOpponentView;
        
        internal System.Windows.Controls.TextBlock StatisticsExplanation;
        
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
            this.adcOpponentPage = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("adcOpponentPage")));
            this.PlayerWinrateAgainstOpponentView = ((MagicGameTracker.View.PlayerWinrate)(this.FindName("PlayerWinrateAgainstOpponentView")));
            this.PlayerColorsAgainstOpponentView = ((MagicGameTracker.View.PlayerCommonColors)(this.FindName("PlayerColorsAgainstOpponentView")));
            this.StatisticsExplanation = ((System.Windows.Controls.TextBlock)(this.FindName("StatisticsExplanation")));
            this.bHelp = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("bHelp")));
            this.bDeleteGame = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("bDeleteGame")));
        }
    }
}

