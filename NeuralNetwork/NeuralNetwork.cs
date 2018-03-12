namespace NeuralNetwork
{
    public class NeuralNetwork : IPropagate
    {
        private readonly NetworkInput[] _inputs;
        private readonly IOutput[] _outputs;
        private readonly Layer[] _layers;

        public NeuralNetwork(NetworkInput[] inputs, IOutput[] outputs, Layer[] layers)
        {
            _inputs = inputs;
            _outputs = outputs;
            _layers = layers;
        }

        public NetworkInput[] Inputs
        {
            get { return _inputs; }
        }

        public IOutput[] Outputs
        {
            get { return _outputs; }
        }

        public void Propagate()
        {
            foreach (var layer in _layers)
            {
                layer.Propagate();
            }
        }
    }
}