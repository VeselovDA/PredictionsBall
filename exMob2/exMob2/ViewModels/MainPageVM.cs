using exMob2.Models;
using exMob2.Views.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace exMob2.ViewModels
{
    class MainPageVM : BaseVM
    {
        string labelProgres;
        string labelPrediction;
        double progress = 0;
        bool isVisible = false;
        int i = 9;


        predictionGetter predictionGetter;
        public ICommand ClickCommand { get; private set; }
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                NotifyPropertyChanged(nameof(IsVisible));
            }
        }
        public ImageSource Sourse
        {
            get { return ImageSource.FromResource("exMob2.Views.ball.jpg");}
        }
        public double Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                NotifyPropertyChanged(nameof(Progress));
            }
        }
        public string LabelPrediction
        {
            get { return labelPrediction; }
            set
            {
                labelPrediction = value;
                NotifyPropertyChanged(nameof(LabelPrediction));
            }
        }
        public string LabelProgres
        {
            get { return labelProgres; }
            set
            {
                labelProgres = value;
                NotifyPropertyChanged(nameof(LabelProgres));

            }
        }

        public MainPageVM()
        {
            ClickCommand = new Command(onButtonClick);
            predictionGetter = new predictionGetter();
        }

        private void onButtonClick()
        {

            IsVisible = true;
            Device.StartTimer(TimeSpan.FromSeconds(0.03), OnTimerTick);
            


        }
        private bool OnTimerTick()
        {
            Progress += 0.01;
            if (Progress*100 >i)
            { LabelProgres = predictionGetter.Process; i +=10; }
            if (Progress >0.95)
            {
                i = 9;
                Progress = 0;
                IsVisible = false;
                App.Current.MainPage.DisplayAlert("Ваше предсказание",  predictionGetter.Prediction, "Ok");
              
                return false;
            }

            return true;

        }
      

    }
}

