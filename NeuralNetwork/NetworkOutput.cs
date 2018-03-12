namespace NeuralNetwork
{
    using System.Linq;

    public class NetworkOutput : IOutput, IPropagate
    {
        private readonly IOutput[] _outputs;

        private double _value;

        public NetworkOutput(IOutput[] outputs)
        {
            _outputs = outputs;
        }

        public void Propagate()
        {
            _value = _outputs.Sum(o => o.GetValue());
        }

        public double GetValue()
        {
            return _value;
        }
    }
}