namespace NeuralNetwork
{
    using System.Linq;

    public class Neuron : IOutput, IPropagate
    {
        private readonly IOutput[] _inputs;
        private readonly double _activationValue;

        private double _value;

        public Neuron(IOutput[] inputs, double activationValue)
        {
            _inputs = inputs;
            _activationValue = activationValue;
        }

        public void Propagate()
        {
            var sum = _inputs.Sum(i => i.GetValue());

            if (sum > _activationValue)
            {
                _value = 1;
            }
            else
            {
                _value = 0;
            }
        }

        public double GetValue()
        {
            return _value;
        }
    }
}