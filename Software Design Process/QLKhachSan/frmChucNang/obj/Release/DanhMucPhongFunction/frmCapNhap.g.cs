﻿#pragma checksum "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D7C7F0C01E7E99A1705F2A7E3550B31C"
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
    /// frmCapNhap
    /// </summary>
    public partial class frmCapNhap : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid btnThayDoi;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxDanhMucPhong;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLoaiPhong;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGia;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSoLgNg;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSoLgPg;
        
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
            System.Uri resourceLocater = new System.Uri("/frmChucNang;component/danhmucphongfunction/frmcapnhap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
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
            this.btnThayDoi = ((System.Windows.Controls.Grid)(target));
            
            #line 8 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
            this.btnThayDoi.Loaded += new System.Windows.RoutedEventHandler(this.CapNhat_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbxDanhMucPhong = ((System.Windows.Controls.ComboBox)(target));
            
            #line 9 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
            this.cbxDanhMucPhong.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxDanhMucPhong_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtLoaiPhong = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtGia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtSoLgNg = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtSoLgPg = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 19 "..\..\..\DanhMucPhongFunction\frmCapNhap.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnThayDoi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

