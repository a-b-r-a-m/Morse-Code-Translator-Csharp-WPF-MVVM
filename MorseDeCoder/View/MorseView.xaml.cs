using System.Text.RegularExpressions;
//using System.Windows;
using System.Windows.Controls;
//using System.Windows.Data;
using System.Windows.Input;

namespace MorseDeCoder.View
{
    public partial class MorseView : UserControl
    {
        public MorseView()
        {
            InitializeComponent();
            this.DataContext = new MorseDeCoder.ViewModel.MorseViewModel(); //this;
        }

        private void MorseValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^.-]");
            e.Handled = regex.IsMatch(e.Text);
        }

       // private void BtnConvert_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
            //a ovi BtnConvert daa, za nimljivo, i NEDA KADJE U ITEMSCONTROL
            //FrameworkElement fe = sender as FrameworkElement;
            //TextBox tb = sender as TextBox;

            //BindingExpression be = fe.GetBindingExpression(TextBox.TextProperty);

            //be.UpdateSource();

            //BindingExpression binding = TmpTxt.GetBindingExpression(TextBox.TextProperty);
            //binding.UpdateSource();
        //}
    }
}
