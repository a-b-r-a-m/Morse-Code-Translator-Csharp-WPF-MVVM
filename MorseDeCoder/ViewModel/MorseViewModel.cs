using MorseDeCoder.Model;
using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System;

namespace MorseDeCoder.ViewModel
{

    public class MorseViewModel //: INotifyPropertyChanged
    {
        //public MyICommand ClickCommand { get; set; }

        public MorseViewModel()
        {
            LoadData();
            //MorseModel Mm = new MorseModel
            //{
            //    Latin = "haha",
            //    Morse = ".... .- .... .-"
            //};
           // ClickCommand = new MyICommand(OnClick, CanClick);
        }

        public ObservableCollection<MorseModel> Data
        {
            get; set;
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        public void LoadData()
        {
            ObservableCollection<MorseModel> data = new ObservableCollection<MorseModel>
            {
                new MorseModel
                {
                    Latin = "Enter the text in Latin alphabet and it will be converted to Morse code, and vice-versa."
                }
            };
            Data = data;
        }


        //public void BtnConvert_Click(object sender, RoutedEventArgs e)
        //{
        //    //BindingExpression binding = GetBindingExpression(TextBox.TextProperty);
        //    //binding.UpdateSource();
        //    //MorseModel.RaisePropertyChanged("Latin");

        //}

        //public void OnClick()
        //{
        //    //BindingExpression binding  = getb
        //    // Students.Remove(SelectedStudent);
            
        //}

        //private bool CanClick()
        //{
        //    return true;
        //}
    }

}
