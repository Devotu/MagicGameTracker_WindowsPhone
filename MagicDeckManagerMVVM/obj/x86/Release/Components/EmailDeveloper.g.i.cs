﻿#pragma checksum "C:\Projekt\MagicGameTracker_WindowsPhone\MagicDeckManagerMVVM\Components\EmailDeveloper.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "79C16C114806E0E4F8C9A4848F256B63"
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
    
    
    public partial class EmailDeveloper : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox tbSubject;
        
        internal System.Windows.Controls.TextBox tbCommentsToSend;
        
        internal System.Windows.Controls.Button bSendEmail;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MagicDeckManagerMVVM;component/Components/EmailDeveloper.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.tbSubject = ((System.Windows.Controls.TextBox)(this.FindName("tbSubject")));
            this.tbCommentsToSend = ((System.Windows.Controls.TextBox)(this.FindName("tbCommentsToSend")));
            this.bSendEmail = ((System.Windows.Controls.Button)(this.FindName("bSendEmail")));
        }
    }
}

