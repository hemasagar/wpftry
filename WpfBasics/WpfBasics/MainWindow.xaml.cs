using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBasics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The value of the text is {this.DescriptionText.Text}");
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.WeldCheckbox.IsChecked = this.AssemblyCheckbox.IsChecked = this.PlasmaCheckbox.IsChecked =
                this.LaserCheckbox.IsChecked =
                    this.PurchaseCheckbox.IsChecked = this.LatheCheckbox.IsChecked = this.DrillCheckbox.IsChecked =
                        this.FoldCheckbox.IsChecked =
                            this.RollCheckbox.IsChecked = this.SawCheckbox.IsChecked = false;
        }

        private void Checkbox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.LengthText.Text += ((CheckBox) sender).Content;
        }

        private void Checkbox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var checkValue = (string)((CheckBox) sender).Content;
            var length = checkValue.Length;
            var pos = this.LengthText.Text.IndexOf(checkValue, StringComparison.CurrentCultureIgnoreCase);
            this.LengthText.Text = this.LengthText.Text.Remove(pos, length);
        }

        private void FinishDropdown_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.NoteText == null)
                return;

            var combo = (ComboBox) sender;
            var value = (ComboBoxItem) combo.SelectedValue;
            this.NoteText.Text = (string)value.Content;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            FinishDropdown_OnSelectionChanged(this.FinishDropdown, null);
        }

        private void SupplierNameText_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //this.MassText.Text = ((TextBox) sender).Text;
            this.MassText.Text = this.SupplierNameText.Text;
        }
    }
}
