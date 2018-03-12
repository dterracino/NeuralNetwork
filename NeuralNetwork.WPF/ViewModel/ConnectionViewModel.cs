namespace NeuralNetwork.WPF.ViewModel
{
    using GalaSoft.MvvmLight;
    public class ConnectionViewModel : ViewModelBase
    {
        public ConnectionViewModel()
        {

        }

        public ConnectionViewModel(NodeViewModel source, NodeViewModel target)
        {
            Source = source;
            Target = target;
        }

        public double Bias { get; set; }

        public NodeViewModel Source { get; set; }

        public NodeViewModel Target { get; set; }
    }
}