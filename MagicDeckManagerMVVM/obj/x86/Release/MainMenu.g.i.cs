﻿#pragma checksum "C:\Users\Otto\Documents\GitHub\MagicGameTracker_WindowsPhone\MagicDeckManagerMVVM\MainMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DBE8EC39C94605BD9CEFE97C6D82323A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace MagicGameTracker {
    
    
    public partial class MainMenu : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button bGoToDeckList;
        
        internal System.Windows.Controls.Button bGoToPlayerStatistics;
        
        internal System.Windows.Controls.Button bGoToOpponents;
        
        internal System.Windows.Controls.Button bGoToExport;
        
        internal System.Windows.Controls.TextBlock tbNews;
        
        internal System.Windows.Controls.Button bAbout;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/MainMenu.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.bGoToDeckList = ((System.Windows.Controls.Button)(this.FindName("bGoToDeckList")));
            this.bGoToPlayerStatistics = ((System.Windows.Controls.Button)(this.FindName("bGoToPlayerStatistics")));
            this.bGoToOpponents = ((System.Windows.Controls.Button)(this.FindName("bGoToOpponents")));
            this.bGoToExport = ((System.Windows.Controls.Button)(this.FindName("bGoToExport")));
            this.tbNews = ((System.Windows.Controls.TextBlock)(this.FindName("tbNews")));
            this.bAbout = ((System.Windows.Controls.Button)(this.FindName("bAbout")));
        }
    }
}

