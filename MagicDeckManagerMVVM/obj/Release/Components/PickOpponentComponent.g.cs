﻿#pragma checksum "C:\Users\Otto\Documents\GitHub\MagicGameTracker_WindowsPhone\MagicDeckManagerMVVM\Components\PickOpponentComponent.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "19ED602A8BAFF99C23ABAEB7C27F5CCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace MagicGameTracker.Components {
    
    
    public partial class PickOpponentComponent : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock lblOpponentToPick;
        
        internal System.Windows.Controls.Button bShowOpponents;
        
        internal System.Windows.Controls.ListBox lbOpponentsToPick;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/Components/PickOpponentComponent.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.lblOpponentToPick = ((System.Windows.Controls.TextBlock)(this.FindName("lblOpponentToPick")));
            this.bShowOpponents = ((System.Windows.Controls.Button)(this.FindName("bShowOpponents")));
            this.lbOpponentsToPick = ((System.Windows.Controls.ListBox)(this.FindName("lbOpponentsToPick")));
        }
    }
}

