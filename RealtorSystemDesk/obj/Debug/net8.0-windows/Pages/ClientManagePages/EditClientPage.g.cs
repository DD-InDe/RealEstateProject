﻿#pragma checksum "..\..\..\..\..\Pages\ClientManagePages\EditClientPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05326D1B49F8E47288DC6E86D910EB75E9728C65"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RealtorSystemDesk.Pages.ClientManagePages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace RealtorSystemDesk.Pages.ClientManagePages {
    
    
    /// <summary>
    /// EditClientPage
    /// </summary>
    public partial class EditClientPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 89 "..\..\..\..\..\Pages\ClientManagePages\EditClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GenderComboBox;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\Pages\ClientManagePages\EditClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RealtorSystemDesk;component/pages/clientmanagepages/editclientpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\ClientManagePages\EditClientPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\Pages\ClientManagePages\EditClientPage.xaml"
            ((RealtorSystemDesk.Pages.ClientManagePages.EditClientPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.EditClientPage_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GenderComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\..\..\..\Pages\ClientManagePages\EditClientPage.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

