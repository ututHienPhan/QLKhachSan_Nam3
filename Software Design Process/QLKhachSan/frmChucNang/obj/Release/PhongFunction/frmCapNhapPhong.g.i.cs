﻿#pragma checksum "..\..\..\PhongFunction\frmCapNhapPhong.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9660D88FA9C2ED7C6F989F4EA7F10684"
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


namespace frmChucNang.PhongFunction {
    
    
    /// <summary>
    /// frmCapNhapPhong
    /// </summary>
    public partial class frmCapNhapPhong : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Background;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbLoaiPhong;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reset;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomName;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTinhTrang;
        
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
            System.Uri resourceLocater = new System.Uri("/frmChucNang;component/phongfunction/frmcapnhapphong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
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
            
            #line 7 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
            ((frmChucNang.PhongFunction.frmCapNhapPhong)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Background = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.cbLoaiPhong = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Reset = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
            this.Reset.Click += new System.Windows.RoutedEventHandler(this.Reset_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\PhongFunction\frmCapNhapPhong.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RoomName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.cbTinhTrang = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

