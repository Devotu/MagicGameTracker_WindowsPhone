﻿#pragma checksum "C:\Users\Otto\Documents\GitHub\MagicGameTracker_WindowsPhone\MagicDeckManagerMVVM\View\DeckDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9C46796753DACBF9C2AD21A947F5248F"
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


namespace MagicGameTracker.View {
    
    
    public partial class DeckDetails : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock lblDeckColors;
        
        internal System.Windows.Controls.Grid grColors;
        
        internal System.Windows.Controls.Image imBlack;
        
        internal System.Windows.Controls.Image imWhite;
        
        internal System.Windows.Controls.Image imRed;
        
        internal System.Windows.Controls.Image imBlue;
        
        internal System.Windows.Controls.Image imGreen;
        
        internal System.Windows.Controls.TextBlock lblActive;
        
        internal System.Windows.Controls.TextBlock txtActive;
        
        internal System.Windows.Controls.TextBlock lblFormat;
        
        internal System.Windows.Controls.TextBlock txtFormat;
        
        internal System.Windows.Controls.TextBlock lblDeckTheme;
        
        internal System.Windows.Controls.TextBlock txtTheme;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/View/DeckDetails.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.lblDeckColors = ((System.Windows.Controls.TextBlock)(this.FindName("lblDeckColors")));
            this.grColors = ((System.Windows.Controls.Grid)(this.FindName("grColors")));
            this.imBlack = ((System.Windows.Controls.Image)(this.FindName("imBlack")));
            this.imWhite = ((System.Windows.Controls.Image)(this.FindName("imWhite")));
            this.imRed = ((System.Windows.Controls.Image)(this.FindName("imRed")));
            this.imBlue = ((System.Windows.Controls.Image)(this.FindName("imBlue")));
            this.imGreen = ((System.Windows.Controls.Image)(this.FindName("imGreen")));
            this.lblActive = ((System.Windows.Controls.TextBlock)(this.FindName("lblActive")));
            this.txtActive = ((System.Windows.Controls.TextBlock)(this.FindName("txtActive")));
            this.lblFormat = ((System.Windows.Controls.TextBlock)(this.FindName("lblFormat")));
            this.txtFormat = ((System.Windows.Controls.TextBlock)(this.FindName("txtFormat")));
            this.lblDeckTheme = ((System.Windows.Controls.TextBlock)(this.FindName("lblDeckTheme")));
            this.txtTheme = ((System.Windows.Controls.TextBlock)(this.FindName("txtTheme")));
        }
    }
}

