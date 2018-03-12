namespace NeuralNetwork
{
    public class Synapse : IOutput
    {
        private readonly IOutput _input;
        private readonly double _weight;
        private double _value;

        public Synapse(IOutput input, double weight)
        {
            _input = input;
            _weight = weight;
        }

        public void Propogate()
        {
            _value = _input.GetValue() * _weight;
        }

        public double GetValue()
        {
            return _value;
        }
    }
}