﻿#pragma checksum "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "45D428486150D4FAEDA6580DC1192E85"
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


namespace frmChucNang {
    
    
    /// <summary>
    /// DanhMucPhong
    /// </summary>
    public partial class DanhMucPhong : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxDanhMucPhong;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbSL;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbDG;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTD;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridDSPhong;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Rent;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pay;
        
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
            System.Uri resourceLocater = new System.Uri("/frmChucNang;component/danhmucphongfunction/danhmucphong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
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
            
            #line 9 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DanhMucPhong_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbxDanhMucPhong = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
            this.cbxDanhMucPhong.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Doi_loai_phong);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 23 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbSL = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lbDG = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lbTD = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.DataGridDSPhong = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.ThemPhong_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Update = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
            this.Update.Click += new System.Windows.RoutedEventHandler(this.Update_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Delete = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
            this.Delete.Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Rent = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
            this.Rent.Click += new System.Windows.RoutedEventHandler(this.Rent_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Pay = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\DanhMucPhongFunction\DanhMucPhong.xaml"
            this.Pay.Click += new System.Windows.RoutedEventHandler(this.Pay_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
