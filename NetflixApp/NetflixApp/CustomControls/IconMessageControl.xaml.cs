using NetflixApp.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetflixApp.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconMessageControl : ContentView
    {
        #region Icon

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static BindableProperty SourceProperty = BindableProperty.Create(
            nameof(Source), typeof(string), typeof(IconMessageControl),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        #endregion

        #region Text

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text), typeof(string), typeof(IconMessageControl),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TextPropertyChanged);

        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var iconMessageControl = (IconMessageControl)bindable;
            switch(iconMessageControl.MessageType)
            {
                case MessageType.Success:
                    iconMessageControl.frame.BackgroundColor = Color.FromHex("#6eaf8f");
                    iconMessageControl.icon.Text = IconFont.CheckboxMarkedCircle;
                    iconMessageControl.icon.TextColor = Color.Black;
                    iconMessageControl.message.TextColor = Color.Black;
                    break;
                case MessageType.Warning:
                    iconMessageControl.frame.BackgroundColor = Color.Orange;
                    iconMessageControl.icon.Text = IconFont.Alert;
                    iconMessageControl.icon.TextColor = Color.White;
                    iconMessageControl.message.TextColor = Color.White;
                    break;
                case MessageType.Error:
                    iconMessageControl.frame.BackgroundColor = Color.FromHex("#fbe9e7");
                    iconMessageControl.icon.Text = IconFont.Alert;
                    iconMessageControl.icon.TextColor = Color.FromHex("#ca3c48");
                    iconMessageControl.message.TextColor = Color.FromHex("#ca3c48");
                    break;
                case MessageType.Information:
                    iconMessageControl.frame.BackgroundColor = Color.Blue;
                    iconMessageControl.icon.Text = IconFont.Alert;
                    iconMessageControl.icon.TextColor = Color.White;
                    iconMessageControl.message.TextColor = Color.White;
                    break;
            }
            
            if(string.IsNullOrEmpty(newValue as string) || string.IsNullOrWhiteSpace(newValue as string))
            {
                iconMessageControl.IsVisible = false;
                iconMessageControl.message.Text = "";
            }
            else
            {
                iconMessageControl.message.Text = newValue as string;
            }
        }
        #endregion

        #region TypeOfMessage
        public MessageType MessageType
        {
            get => (MessageType)GetValue(MessageTypeProperty);
            set => SetValue(MessageTypeProperty, value);
        }

        public static BindableProperty MessageTypeProperty = BindableProperty.Create(
            nameof(MessageType), typeof(MessageType), typeof(IconMessageControl),
            defaultValue:null,
            defaultBindingMode:BindingMode.OneWay);
        #endregion

        #region Visibity 
        public new bool IsVisible
        {
            get => (bool)GetValue(IsVisibleProperty);
            set => SetValue(IsVisibleProperty, value);
        }

        public static new BindableProperty IsVisibleProperty = BindableProperty.Create(
            nameof(IsVisible), typeof(bool), typeof(IconMessageControl),
            defaultValue:true,
            defaultBindingMode:BindingMode.TwoWay,
            propertyChanged: IsVisibleChanged);

        private static void IsVisibleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var iconMessageControl = (IconMessageControl)bindable;
            iconMessageControl.@this.IsVisible = (bool)newValue;
        }
        #endregion

        public IconMessageControl()
        {
            InitializeComponent();
            IsVisible = false;
        }
    }

    public enum MessageType
    {
        Success,
        Warning,
        Error,
        Information
    }
}