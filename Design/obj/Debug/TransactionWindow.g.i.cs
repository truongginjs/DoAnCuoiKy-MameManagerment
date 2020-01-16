﻿#pragma checksum "..\..\TransactionWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "737A077C8D4D925F3C202C3401788FCAEE30017A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Design;
using Design.myUC;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Design {
    
    
    /// <summary>
    /// TransactionWindow
    /// </summary>
    public partial class TransactionWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 99 "..\..\TransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbSales;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\TransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSubT;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\TransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSales;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\TransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTotal;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\TransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImport;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\TransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
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
            System.Uri resourceLocater = new System.Uri("/Design;component/transactionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TransactionWindow.xaml"
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
            
            #line 86 "..\..\TransactionWindow.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbbPlance_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbbSales = ((System.Windows.Controls.ComboBox)(target));
            
            #line 99 "..\..\TransactionWindow.xaml"
            this.cbbSales.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbbSales_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtSubT = ((System.Windows.Controls.TextBox)(target));
            
            #line 132 "..\..\TransactionWindow.xaml"
            this.txtSubT.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtSubT_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtSales = ((System.Windows.Controls.TextBox)(target));
            
            #line 135 "..\..\TransactionWindow.xaml"
            this.txtSales.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtSales_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtTotal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 176 "..\..\TransactionWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnImport = ((System.Windows.Controls.Button)(target));
            
            #line 195 "..\..\TransactionWindow.xaml"
            this.btnImport.Click += new System.Windows.RoutedEventHandler(this.BtnImport_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

