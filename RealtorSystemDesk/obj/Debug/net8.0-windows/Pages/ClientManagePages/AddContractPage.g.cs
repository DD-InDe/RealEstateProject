﻿#pragma checksum "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "073F8D1EDC8C4F2CC0F0AC12C39AD591E9A843AC"
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
    /// AddContractPage
    /// </summary>
    public partial class AddContractPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ObjectPanel;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ObjectTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ApartmentPanel;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClassComboBox;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel HousePanel;
        
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
            System.Uri resourceLocater = new System.Uri("/RealtorSystemDesk;component/pages/clientmanagepages/addcontractpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
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
            
            #line 9 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
            ((RealtorSystemDesk.Pages.ClientManagePages.AddContractPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.AddContractPage_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 69 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
            this.TypeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TypeComboBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ObjectPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.ObjectTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 165 "..\..\..\..\..\Pages\ClientManagePages\AddContractPage.xaml"
            this.ObjectTypeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ObjectTypeComboBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ApartmentPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.ClassComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.HousePanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

