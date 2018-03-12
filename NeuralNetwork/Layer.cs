namespace NeuralNetwork
{
    public class Layer : IPropagate
    {
        private readonly IPropagate[] _items;
        private readonly IOutput[] _outputs;

        public Layer(IPropagate[] items, IOutput[] outputs)
        {
            _items = items;
            _outputs = outputs;
        }

        public IOutput[] Outputs
        {
            get { return _outputs; }
        }

        public void Propagate()
        {
            foreach (var item in _items)
            {
                item.Propagate();
            }
        }

    }
}