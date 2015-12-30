﻿#pragma checksum "C:\Projekt\MagicDeckManagerMVVM\MagicDeckManagerMVVM\View\GameDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "48A335E279D4E08B709CFDFB3A56F91E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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
    
    
    public partial class GameDetails : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock lblResult;
        
        internal System.Windows.Controls.TextBlock txtResult;
        
        internal System.Windows.Controls.TextBlock lblOpponent;
        
        internal System.Windows.Controls.TextBlock txtOpponent;
        
        internal System.Windows.Controls.TextBlock lblOpponentColors;
        
        internal System.Windows.Controls.Grid grOpponentColors;
        
        internal System.Windows.Controls.Image imBlack;
        
        internal System.Windows.Controls.Image imWhite;
        
        internal System.Windows.Controls.Image imRed;
        
        internal System.Windows.Controls.Image imBlue;
        
        internal System.Windows.Controls.Image imGreen;
        
        internal System.Windows.Controls.TextBlock tbPerformanceRating;
        
        internal System.Windows.Controls.Slider slPerformanceRating;
        
        internal System.Windows.Controls.TextBlock lblComment;
        
        internal System.Windows.Controls.TextBlock txtComment;
        
        internal System.Windows.Controls.TextBlock lblGameNumber;
        
        internal System.Windows.Controls.TextBlock txtGameNumber;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/View/GameDetails.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.lblResult = ((System.Windows.Controls.TextBlock)(this.FindName("lblResult")));
            this.txtResult = ((System.Windows.Controls.TextBlock)(this.FindName("txtResult")));
            this.lblOpponent = ((System.Windows.Controls.TextBlock)(this.FindName("lblOpponent")));
            this.txtOpponent = ((System.Windows.Controls.TextBlock)(this.FindName("txtOpponent")));
            this.lblOpponentColors = ((System.Windows.Controls.TextBlock)(this.FindName("lblOpponentColors")));
            this.grOpponentColors = ((System.Windows.Controls.Grid)(this.FindName("grOpponentColors")));
            this.imBlack = ((System.Windows.Controls.Image)(this.FindName("imBlack")));
            this.imWhite = ((System.Windows.Controls.Image)(this.FindName("imWhite")));
            this.imRed = ((System.Windows.Controls.Image)(this.FindName("imRed")));
            this.imBlue = ((System.Windows.Controls.Image)(this.FindName("imBlue")));
            this.imGreen = ((System.Windows.Controls.Image)(this.FindName("imGreen")));
            this.tbPerformanceRating = ((System.Windows.Controls.TextBlock)(this.FindName("tbPerformanceRating")));
            this.slPerformanceRating = ((System.Windows.Controls.Slider)(this.FindName("slPerformanceRating")));
            this.lblComment = ((System.Windows.Controls.TextBlock)(this.FindName("lblComment")));
            this.txtComment = ((System.Windows.Controls.TextBlock)(this.FindName("txtComment")));
            this.lblGameNumber = ((System.Windows.Controls.TextBlock)(this.FindName("lblGameNumber")));
            this.txtGameNumber = ((System.Windows.Controls.TextBlock)(this.FindName("txtGameNumber")));
        }
    }
}

