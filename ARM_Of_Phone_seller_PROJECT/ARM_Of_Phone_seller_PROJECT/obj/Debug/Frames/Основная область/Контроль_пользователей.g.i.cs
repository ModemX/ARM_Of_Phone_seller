﻿#pragma checksum "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "979AC9DAC89F2E94FBF1278CDD3A6E57B00DD8383521BE4886CFB512EE78A5E7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ARM_Of_Phone_seller_PROJECT.Frames.Основная_область;
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


namespace ARM_Of_Phone_seller_PROJECT.Frames.Основная_область {
    
    
    /// <summary>
    /// Контроль_пользователей
    /// </summary>
    public partial class Контроль_пользователей : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid UsersGrid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddUser_Button;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditUser_Button;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteUser_Button;
        
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
            System.Uri resourceLocater = new System.Uri(@"/ARM_Of_Phone_seller_PROJECT;component/frames/%d0%9e%d1%81%d0%bd%d0%be%d0%b2%d0%bd%d0%b0%d1%8f%20%d0%be%d0%b1%d0%bb%d0%b0%d1%81%d1%82%d1%8c/%d0%9a%d0%be%d0%bd%d1%82%d1%80%d0%be%d0%bb%d1%8c_%d0%bf%d0%be%d0%bb%d1%8c%d0%b7%d0%be%d0%b2%d0%b0%d1%82%d0%b5%d0%bb%d0%b5%d0%b9.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml"
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
            this.UsersGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml"
            this.UsersGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UsersGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddUser_Button = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml"
            this.AddUser_Button.Click += new System.Windows.RoutedEventHandler(this.AddUser_Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditUser_Button = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml"
            this.EditUser_Button.Click += new System.Windows.RoutedEventHandler(this.EditUser_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeleteUser_Button = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\Frames\Основная область\Контроль_пользователей.xaml"
            this.DeleteUser_Button.Click += new System.Windows.RoutedEventHandler(this.DeleteUser_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

