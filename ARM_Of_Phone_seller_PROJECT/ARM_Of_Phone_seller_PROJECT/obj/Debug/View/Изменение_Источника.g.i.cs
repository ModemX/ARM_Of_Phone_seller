﻿#pragma checksum "..\..\..\View\Изменение_Источника.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3C8E180D575D816085DF5D7CA8435D3AF01A62D0BC9DFE3463C41AE75B2EAF33"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ARM_Of_Phone_seller_PROJECT.View;
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


namespace ARM_Of_Phone_seller_PROJECT.View {
    
    
    /// <summary>
    /// Изменение_Источника
    /// </summary>
    public partial class Изменение_Источника : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\View\Изменение_Источника.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Accept;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\View\Изменение_Источника.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Abort;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\Изменение_Источника.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_DBName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\Изменение_Источника.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_User;
        
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
            System.Uri resourceLocater = new System.Uri("/ARM_Of_Phone_seller_PROJECT;component/view/%d0%98%d0%b7%d0%bc%d0%b5%d0%bd%d0%b5%" +
                    "d0%bd%d0%b8%d0%b5_%d0%98%d1%81%d1%82%d0%be%d1%87%d0%bd%d0%b8%d0%ba%d0%b0.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Изменение_Источника.xaml"
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
            this.Accept = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\View\Изменение_Источника.xaml"
            this.Accept.Click += new System.Windows.RoutedEventHandler(this.Accept_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Abort = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\View\Изменение_Источника.xaml"
            this.Abort.Click += new System.Windows.RoutedEventHandler(this.Abort_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBox_DBName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBox_User = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

