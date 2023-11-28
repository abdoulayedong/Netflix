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
    public partial class EntryLabelControl : ContentView
    {
        #region Border

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(
                declaringType: typeof(EntryLabelControl),
                propertyName: nameof(BorderColor),
                returnType: typeof(Color),
                defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.OneWay);


        public float BorderRadius
        {
            get => (float)GetValue(BorderRadiusProperty);
            set => SetValue(BorderRadiusProperty, value);
        }

        public static readonly BindableProperty BorderRadiusProperty =
            BindableProperty.Create(
                declaringType: typeof(EntryLabelControl),
                propertyName: nameof(BorderRadius),
                returnType: typeof(float),
                defaultValue: default,
                defaultBindingMode: BindingMode.OneWay);


        #endregion

        #region Placeholder
        public string PlaceholderFontFamily
        {
            get { return (string)GetValue(PlaceholderFontFamilyProperty); }
            set { SetValue(PlaceholderFontFamilyProperty, value); }
        }

        public static readonly BindableProperty PlaceholderFontFamilyProperty =
            BindableProperty.Create(nameof(PlaceholderFontFamilyProperty),
                typeof(string),
                typeof(EntryLabelControl),
                "AbitareSans",
                defaultBindingMode: BindingMode.OneWay);

        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }

        public static readonly BindableProperty PlaceholderTextProperty =
            BindableProperty.Create(nameof(PlaceholderText),
                typeof(string),
                typeof(EntryLabelControl),
                string.Empty,
                defaultBindingMode: BindingMode.OneWay);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor),
                typeof(Color),
                typeof(EntryLabelControl),
                Color.Gray,
                defaultBindingMode: BindingMode.OneWay);

        public Color UnselectedPlaceholderTextColor
        {
            get { return (Color)GetValue(UnselectedPlaceholderTextColorProperty); }
            set { SetValue(UnselectedPlaceholderTextColorProperty, value); }
        }

        public static readonly BindableProperty UnselectedPlaceholderTextColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor),
                typeof(Color),
                typeof(EntryLabelControl),
                Color.Gray,
                defaultBindingMode: BindingMode.OneWay);

        public double PlaceholderSize
        {
            get { return (double)GetValue(PlaceholderSizeProperty); }
            set { SetValue(PlaceholderSizeProperty, value); }
        }

        public static readonly BindableProperty PlaceholderSizeProperty =
            BindableProperty.Create(nameof(PlaceholderSize),
                typeof(double),
                typeof(EntryLabelControl),
                0.0,
                defaultBindingMode: BindingMode.OneWay);
        #endregion

        #region Entry Text
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text),
                typeof(string),
                typeof(EntryLabelControl),
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor),
                typeof(Color),
                typeof(EntryLabelControl),
                Color.Transparent,
                defaultBindingMode: BindingMode.OneWay);

        public ReturnType ReturnTypeEntry
        {
            get { return (ReturnType)GetValue(ReturnTypeEntryProperty); }
            set { SetValue(ReturnTypeEntryProperty, value); }
        }

        public static readonly BindableProperty ReturnTypeEntryProperty =
            BindableProperty.Create(nameof(ReturnTypeEntry),
                typeof(ReturnType),
                typeof(EntryLabelControl),
                ReturnType.Next,
                defaultBindingMode: BindingMode.OneWay);

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard),
                typeof(Keyboard),
                typeof(EntryLabelControl),
                Keyboard.Default,
                defaultBindingMode: BindingMode.OneWay);

        public new bool IsFocused
        {
            get { return (bool)GetValue(IsFocusedProperty); }
            set { SetValue(IsFocusedProperty, value); }
        }

        public new static readonly BindableProperty IsFocusedProperty =
            BindableProperty.Create(nameof(IsFocused),
                typeof(bool),
                typeof(EntryLabelControl),
                false,
                defaultBindingMode: BindingMode.OneWay);
        #endregion

        #region Label Error
        public string TextError
        {
            get { return (string)GetValue(TextErrorProperty); }
            set { SetValue(TextErrorProperty, value); }
        }

        public static readonly BindableProperty TextErrorProperty =
            BindableProperty.Create(nameof(TextError),
                typeof(string),
                typeof(EntryLabelControl),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextErrorChanged);

        private static void TextErrorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entryLabelControl = (EntryLabelControl)bindable;
            if (newValue == null)
            {
                entryLabelControl.ErrorText.IsVisible = false;
                return;
            }
            if (newValue as string == "")
            {
                entryLabelControl.ErrorText.IsVisible = false;
                entryLabelControl.BorderColor = Color.Green;
            }
            else
            if (newValue as string != "")
            {
                entryLabelControl.ErrorText.IsVisible = true;
                entryLabelControl.BorderColor = Color.FromHex("D98b0000");
                entryLabelControl.ErrorText.TextColor = Color.FromHex("D98b0000");
            }
        }
        #endregion

        #region Label Warning
        public string TextWarning
        {
            get { return (string)GetValue(TextWarningProperty); }
            set { SetValue(TextWarningProperty, value); }
        }

        public static readonly BindableProperty TextWarningProperty =
            BindableProperty.Create(nameof(TextWarning),
                typeof(string),
                typeof(EntryLabelControl),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: TextWarningChanged);

        private static void TextWarningChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entryLabelControl = (EntryLabelControl)bindable;
            if (newValue == null)
            {
                entryLabelControl.WarningBar.IsVisible = false;
                entryLabelControl.WarningText.IsVisible = false;
                return;
            }
            entryLabelControl.WarningText.IsVisible = true;
            entryLabelControl.WarningBar.IsVisible = true;
        }
        #endregion

        #region Background Color
        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static new readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor),
                typeof(Color),
                typeof(EntryLabelControl),
                Color.Transparent,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: BackgroundColorPropertyChanged);

        private static void BackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (EntryLabelControl)bindable;
            control.Border.BackgroundColor = (Color)newValue;
        }

        public Color FocusedBackgroundColor
        {
            get { return (Color)GetValue(FocusedBackgroundColorProperty); }
            set { SetValue(FocusedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBackgroundColorProperty =
            BindableProperty.Create(nameof(FocusedBackgroundColor),
                typeof(Color),
                typeof(EntryLabelControl),
                Color.Transparent,
                defaultBindingMode: BindingMode.OneWay);

        #endregion

        #region Password Options
        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword),
                typeof(bool),
                typeof(EntryLabelControl),
                false,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: IsPasswordPropertyChanged);

        private static void IsPasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (EntryLabelControl)bindable;
            if ((bool)newValue)
            {
                control.Entry.IsPassword = true;
            }
        }
        #endregion

        public EntryLabelControl()
        {
            InitializeComponent();

            Border.BackgroundColor = BorderColor;
            Entry.TextColor = TextColor;
            Entry.FontSize = 17;
            Entry.VerticalOptions = LayoutOptions.Center;
            Entry.Margin = new Thickness(0);
            Entry.BackgroundColor = Color.Transparent;

            Placeholder.TextColor = UnselectedPlaceholderTextColor;

            Entry.TextChanged += Entry_TextChanged;
            Entry.Focused += Entry_Focused;
            Entry.Unfocused += Entry_Unfocused;
        }

        #region Events
        public event EventHandler EntryFocused = (e, a) => { } ;
        public event EventHandler EntryUnfocused = (e, a) => { };
        public event EventHandler EntryTextChanged = (e, a) => { };

        #endregion

        public void EntryLabelFocused()
        {
            Entry.Focus();
        }

        private async void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            var entry = (Entry)sender;
            EntryUnfocused.Invoke(entry, e);
            IsFocused = false;
            if (string.IsNullOrEmpty(entry.Text) || entry?.Text.Length == 0)
            {
                await ResizePlaceholderAnimation(Placeholder, 1, 0, 0);
                Placeholder.TextColor = UnselectedPlaceholderTextColor;
            }
            Border.BackgroundColor = BackgroundColor;
        }

        private async void Entry_Focused(object sender, FocusEventArgs e)
        {
            var entry = (Entry)sender;
            EntryFocused.Invoke(entry, e);
            IsFocused = true;
            if (Placeholder.Scale != 0.65)
                await ResizePlaceholderAnimation(Placeholder, 0.65, Placeholder.Text.Length, -20);
            Placeholder.TextColor = PlaceholderColor;
            Entry.TextColor = TextColor;

            Border.BackgroundColor = FocusedBackgroundColor;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            if (WarningText != null)
            {
                WarningBar.IsVisible = false;
                WarningText.IsVisible = false;
            }

            EntryTextChanged.Invoke(entry, e);
            if ((string.IsNullOrEmpty(entry.Text) || entry?.Text.Length == 0) && entry.IsPassword)
            {
                Visibility.IsVisible = false;
            }
            else if (entry.IsPassword)
            {
                Visibility.IsVisible = true;
            }
        }

        private async Task ResizePlaceholderAnimation(VisualElement element, double targetSize, double targetX = 0, double targetY = 0)
        {
            Task[] tasks = new Task[]
            {
               element.TranslateTo(targetX * (-1.4), targetY),
               element.ScaleTo(targetSize)
            };
            await Task.WhenAny(tasks);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Entry.IsPassword = !Entry.IsPassword;
            if (Entry.IsPassword)
            {
                Visibility.Text = "SHOW";
            }
            else
            {
                Visibility.Text = "HIDE";
            }
            Entry.CursorPosition = Entry.Text.Length;
            Entry.Focus();
        }
    }
}