#pragma checksum "..\..\..\..\View\ExtensionToCrypt.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98CB96CF26C3F69C27F472274C8ACA21DC6C0181"
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
    /// ExtensionToCrypt
    /// </summary>
    public partial class ExtensionToCrypt : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 73 "..\..\..\..\View\ExtensionToCrypt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ExtensionToCryptFrame;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\View\ExtensionToCrypt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox falseSearch;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\View\ExtensionToCrypt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\View\ExtensionToCrypt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ascending;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\View\ExtensionToCrypt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button descending;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\View\ExtensionToCrypt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox falseTxtNewExtention;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\View\ExtensionToCrypt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNewExtention;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\View\ExtensionToCrypt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ExtentionList;
        
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
            System.Uri resourceLocater = new System.Uri("/EasySaveApp;V1.0.0.0;component/view/extensiontocrypt.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\ExtensionToCrypt.xaml"
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
            this.ExtensionToCryptFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            
            #line 78 "..\..\..\..\View\ExtensionToCrypt.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 84 "..\..\..\..\View\ExtensionToCrypt.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.BackEncryption_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.falseSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 102 "..\..\..\..\View\ExtensionToCrypt.xaml"
            this.Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ascending = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\..\View\ExtensionToCrypt.xaml"
            this.ascending.Click += new System.Windows.RoutedEventHandler(this.SortExtension);
            
            #line default
            #line hidden
            return;
            case 7:
            this.descending = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\..\View\ExtensionToCrypt.xaml"
            this.descending.Click += new System.Windows.RoutedEventHandler(this.SortExtension);
            
            #line default
            #line hidden
            return;
            case 8:
            this.falseTxtNewExtention = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtNewExtention = ((System.Windows.Controls.TextBox)(target));
            
            #line 117 "..\..\..\..\View\ExtensionToCrypt.xaml"
            this.txtNewExtention.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NewExtension_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 120 "..\..\..\..\View\ExtensionToCrypt.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddExtension_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ExtentionList = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

