﻿#pragma checksum "..\..\VentanaJugarCarta.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "397A15536F4C5A8E6CF5FEC1F50F6CD4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Entrega3;
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


namespace Entrega3 {
    
    
    /// <summary>
    /// VentanaJugarCarta
    /// </summary>
    public partial class VentanaJugarCarta : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\VentanaJugarCarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelMano;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\VentanaJugarCarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListMano;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\VentanaJugarCarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListTablero;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\VentanaJugarCarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTablero;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\VentanaJugarCarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelInstrucciones;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\VentanaJugarCarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CartaAJugar;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\VentanaJugarCarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonJugarCarta;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\VentanaJugarCarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonMenu;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\VentanaJugarCarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonEnorme;
        
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
            System.Uri resourceLocater = new System.Uri("/Entrega3;component/ventanajugarcarta.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VentanaJugarCarta.xaml"
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
            this.LabelMano = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.ListMano = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.ListTablero = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.LabelTablero = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.LabelInstrucciones = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.CartaAJugar = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\VentanaJugarCarta.xaml"
            this.CartaAJugar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BotonJugarCarta = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\VentanaJugarCarta.xaml"
            this.BotonJugarCarta.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BotonMenu = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\VentanaJugarCarta.xaml"
            this.BotonMenu.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BotonEnorme = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\VentanaJugarCarta.xaml"
            this.BotonEnorme.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
