﻿#pragma checksum "..\..\..\..\View\ExtensionLogFile.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7F328E33F87B222AA0C71B027351D7587DAF3F34"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EasySaveApp.Properties.Langs;
using EasySaveApp.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace EasySaveApp.View {
    
    
    /// <summary>
    /// ExtensionLogFile
    /// </summary>
    public partial class ExtensionLogFile : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\View\ExtensionLogFile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ExtensionLogFileFrame;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\View\ExtensionLogFile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgJsonRadioButton;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\View\ExtensionLogFile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgXmlRadioButton;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\View\ExtensionLogFile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton JsonRadioButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\View\ExtensionLogFile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton XmlRadioButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EasySaveApp;V1.0.0.0;component/view/extensionlogfile.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\ExtensionLogFile.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ExtensionLogFileFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            
            #line 22 "..\..\..\..\View\ExtensionLogFile.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ConfirmExtensionLogFile_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 28 "..\..\..\..\View\ExtensionLogFile.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.BackExtensionLogFile_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imgJsonRadioButton = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.imgXmlRadioButton = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.JsonRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 53 "..\..\..\..\View\ExtensionLogFile.xaml"
            this.JsonRadioButton.Checked += new System.Windows.RoutedEventHandler(this.CheckedExtension);
            
            #line default
            #line hidden
            return;
            case 7:
            this.XmlRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 60 "..\..\..\..\View\ExtensionLogFile.xaml"
            this.XmlRadioButton.Checked += new System.Windows.RoutedEventHandler(this.CheckedExtension);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

