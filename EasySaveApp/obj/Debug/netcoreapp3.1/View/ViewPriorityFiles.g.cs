#pragma checksum "..\..\..\..\View\ViewPriorityFiles.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D3BE397E8825134B163830854A3260770DC971EF"
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
    /// ViewPriorityFiles
    /// </summary>
    public partial class ViewPriorityFiles : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\View\ViewPriorityFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame PriorityFilesFrame;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\ViewPriorityFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox falseSearch;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\View\ViewPriorityFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\View\ViewPriorityFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ascending;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\View\ViewPriorityFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button descending;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\View\ViewPriorityFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox falseTxtNewPriority;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\View\ViewPriorityFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNewPriority;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\View\ViewPriorityFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PriorityList;
        
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
            System.Uri resourceLocater = new System.Uri("/EasySaveApp;V1.0.0.0;component/view/viewpriorityfiles.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\ViewPriorityFiles.xaml"
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
            this.PriorityFilesFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            
            #line 26 "..\..\..\..\View\ViewPriorityFiles.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 32 "..\..\..\..\View\ViewPriorityFiles.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.BackPriorityFiles_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.falseSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\..\..\View\ViewPriorityFiles.xaml"
            this.Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ascending = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\View\ViewPriorityFiles.xaml"
            this.ascending.Click += new System.Windows.RoutedEventHandler(this.SortPriority);
            
            #line default
            #line hidden
            return;
            case 7:
            this.descending = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\View\ViewPriorityFiles.xaml"
            this.descending.Click += new System.Windows.RoutedEventHandler(this.SortPriority);
            
            #line default
            #line hidden
            return;
            case 8:
            this.falseTxtNewPriority = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtNewPriority = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\..\..\View\ViewPriorityFiles.xaml"
            this.txtNewPriority.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NewPriority_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 71 "..\..\..\..\View\ViewPriorityFiles.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddPriority_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.PriorityList = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

