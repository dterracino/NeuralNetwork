namespace NeuralNetwork.WPF.ViewModel
{
    using System.Windows;
    using GalaSoft.MvvmLight;

    public class NodeViewModel : ViewModelBase
    {
        private Point _position;

        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                RaisePropertyChanged();
            }
        }
    }
}