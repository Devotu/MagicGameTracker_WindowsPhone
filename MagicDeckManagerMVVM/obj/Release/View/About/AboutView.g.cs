﻿#pragma checksum "C:\Projekt\MagicDeckManagerMVVM\MagicDeckManagerMVVM\View\About\AboutView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F9D7005350387EEBF18DC3CD3A2D31BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MagicGameTracker.Components;
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


namespace MagicGameTracker.View.About {
    
    
    public partial class AboutView : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid grAboutText;
        
        internal System.Windows.Controls.TextBlock tbAboutText1;
        
        internal System.Windows.Controls.TextBlock tbAboutText2;
        
        internal System.Windows.Controls.TextBlock tbAboutText3;
        
        internal System.Windows.Controls.TextBlock tbAboutText4;
        
        internal System.Windows.Controls.TextBlock tbAboutText5;
        
        internal MagicGameTracker.Components.EmailDeveloper EmailDeveloper;
        
        internal System.Windows.Controls.Button bShowCommentView;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/View/About/AboutView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.grAboutText = ((System.Windows.Controls.Grid)(this.FindName("grAboutText")));
            this.tbAboutText1 = ((System.Windows.Controls.TextBlock)(this.FindName("tbAboutText1")));
            this.tbAboutText2 = ((System.Windows.Controls.TextBlock)(this.FindName("tbAboutText2")));
            this.tbAboutText3 = ((System.Windows.Controls.TextBlock)(this.FindName("tbAboutText3")));
            this.tbAboutText4 = ((System.Windows.Controls.TextBlock)(this.FindName("tbAboutText4")));
            this.tbAboutText5 = ((System.Windows.Controls.TextBlock)(this.FindName("tbAboutText5")));
            this.EmailDeveloper = ((MagicGameTracker.Components.EmailDeveloper)(this.FindName("EmailDeveloper")));
            this.bShowCommentView = ((System.Windows.Controls.Button)(this.FindName("bShowCommentView")));
        }
    }
}
