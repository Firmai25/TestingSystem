﻿#pragma checksum "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "62BDBE9487CF4B4B9D7B6885B3EADFCDE0E2B54F9C98DEB65B4836B51BE89C45"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using TestingSystem.Pages.Teachers;


namespace TestingSystem.Pages.Teachers {
    
    
    /// <summary>
    /// AutorizationTeacherPage
    /// </summary>
    public partial class AutorizationTeacherPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbLogin;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TbPassword;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbPassword;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAutorization;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
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
            System.Uri resourceLocater = new System.Uri("/TestingSystem;component/pages/teachers/autorizationteacherpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml"
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
            this.TbLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TbPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 74 "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml"
            this.TbPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.TbPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lbPassword = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.BtnAutorization = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml"
            this.BtnAutorization.Click += new System.Windows.RoutedEventHandler(this.Autorization_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\..\Pages\Teachers\AutorizationTeacherPage.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.Back_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

