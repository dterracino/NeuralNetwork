namespace NeuralNetwork
{
    public class NetworkInput : IInput, IPropagate
    {
        private double _value;

        public void SetValue(double value)
        {
            _value = value;
        }

        public double GetValue()
        {
            return _value;
        }

        public void Propagate()
        {
        }
    }
}