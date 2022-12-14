#pragma checksum "..\..\..\..\View\ViewSettings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20746B14A63E980CC256379EDDF115EC7B35F77F"
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
    /// ViewSettings
    /// </summary>
    public partial class ViewSettings : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\View\ViewSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Settings;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\View\ViewSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton fr;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\ViewSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton en;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\View\ViewSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image zh;
        
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
            System.Uri resourceLocater = new System.Uri("/EasySaveApp;V1.0.0.0;component/view/viewsettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\ViewSettings.xaml"
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
            this.Settings = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.fr = ((System.Windows.Controls.RadioButton)(target));
            
            #line 28 "..\..\..\..\View\ViewSettings.xaml"
            this.fr.Click += new System.Windows.RoutedEventHandler(this.LanguageButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.en = ((System.Windows.Controls.RadioButton)(target));
            
            #line 34 "..\..\..\..\View\ViewSettings.xaml"
            this.en.Click += new System.Windows.RoutedEventHandler(this.LanguageButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 52 "..\..\..\..\View\ViewSettings.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ExtensionToCrypt_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 67 "..\..\..\..\View\ViewSettings.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ExtensionLogFile_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 84 "..\..\..\..\View\ViewSettings.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Business_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 100 "..\..\..\..\View\ViewSettings.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.PriorityFiles_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 116 "..\..\..\..\View\ViewSettings.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.InputFileSize_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.zh = ((System.Windows.Controls.Image)(target));
            
            #line 129 "..\..\..\..\View\ViewSettings.xaml"
            this.zh.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.EasterEgg);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

