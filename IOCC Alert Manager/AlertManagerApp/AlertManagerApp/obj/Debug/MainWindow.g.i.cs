﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CB160F862ABB26D6C28585059A32FF24CD92261061754B721A821F509FA4D087"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AlertManagerApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace AlertManagerApp {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Critical_ID;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Critical_AlertDT;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Critical_AlertTypeName;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Critical_Responses;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Critical_FacilityName;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Critical_ReportedBy;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Critical_FacilityType;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Critical_FirstViewed;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AlertManagerApp;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Critical_ID = ((System.Windows.Controls.ComboBox)(target));
            
            #line 41 "..\..\MainWindow.xaml"
            this.Critical_ID.KeyUp += new System.Windows.Input.KeyEventHandler(this.Critical_ID_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Critical_AlertDT = ((System.Windows.Controls.ComboBox)(target));
            
            #line 51 "..\..\MainWindow.xaml"
            this.Critical_AlertDT.KeyUp += new System.Windows.Input.KeyEventHandler(this.Critical_ID_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Critical_AlertTypeName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 61 "..\..\MainWindow.xaml"
            this.Critical_AlertTypeName.KeyUp += new System.Windows.Input.KeyEventHandler(this.Critical_ID_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Critical_Responses = ((System.Windows.Controls.ComboBox)(target));
            
            #line 71 "..\..\MainWindow.xaml"
            this.Critical_Responses.KeyUp += new System.Windows.Input.KeyEventHandler(this.Critical_ID_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Critical_FacilityName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 81 "..\..\MainWindow.xaml"
            this.Critical_FacilityName.KeyUp += new System.Windows.Input.KeyEventHandler(this.Critical_ID_KeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Critical_ReportedBy = ((System.Windows.Controls.ComboBox)(target));
            
            #line 91 "..\..\MainWindow.xaml"
            this.Critical_ReportedBy.KeyUp += new System.Windows.Input.KeyEventHandler(this.Critical_ID_KeyUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Critical_FacilityType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 101 "..\..\MainWindow.xaml"
            this.Critical_FacilityType.KeyUp += new System.Windows.Input.KeyEventHandler(this.Critical_ID_KeyUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Critical_FirstViewed = ((System.Windows.Controls.ComboBox)(target));
            
            #line 111 "..\..\MainWindow.xaml"
            this.Critical_FirstViewed.KeyUp += new System.Windows.Input.KeyEventHandler(this.Critical_ID_KeyUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

