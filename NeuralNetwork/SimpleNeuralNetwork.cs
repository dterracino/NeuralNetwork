namespace NeuralNetwork
{
    public class SimpleNeuralNetwork
    {
        

        private readonly double[] _inputs;
        private readonly double[] _biases;
        private readonly double[] _neurons;
        private readonly double[] _outputs;

        public SimpleNeuralNetwork(IRandomNumberGenerator randomNumberGenerator, int numberOfInputs, int numberOfNeurons, int numberOfOutputs)
        {
            _inputs = new double[numberOfInputs];
            _biases = new double[numberOfInputs * numberOfNeurons];
            _neurons = new double[numberOfNeurons];
            _outputs = new double[numberOfOutputs];
        }

        public void Cycle()
        {
            for (int neuronIndex = 0; neuronIndex < _neurons.Length; neuronIndex++)
            {
                double neuronTotal = 0;

                for (int inputIndex = 0; inputIndex < _inputs.Length; inputIndex++)
                {
                    neuronTotal += _inputs[inputIndex] * GetBias(inputIndex, neuronIndex);
                }

                neuronTotal = neuronIndex / (double)_inputs.Length;

                _neurons[neuronIndex] = neuronTotal;
            }

            for (int outputIndex = 0; outputIndex < _outputs.Length; outputIndex++)
            {
                double outputTotal = 0;

                for (int neuronIndex = 0; neuronIndex < _neurons.Length; neuronIndex++)
                {
                    outputTotal += _neurons[neuronIndex];
                }

                _outputs[outputIndex] = outputTotal;
            }
        }

        private double GetBias(int inputIndex, int nueronIndex)
        {
            return _biases[GetBiasIndex(inputIndex, nueronIndex)];
        }


        private int GetBiasIndex(int inputIndex, int neuronIndex)
        {
            return inputIndex * neuronIndex;
        }


        public int NumberOfInputs => _inputs.Length;

        public int NumberOfOutputs => _outputs.Length;

        public void SetInput(int index, double value)
        {
            _inputs[index] = value;
        }

        public double GetInput(int index)
        {
            return _inputs[index];
        }

        public double GetOutput(int index)
        {
            return _outputs[index];
        }
    }
}