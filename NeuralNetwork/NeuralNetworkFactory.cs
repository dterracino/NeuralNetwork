using System;

namespace NeuralNetwork
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class NeuralNetworkFactory
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public NeuralNetworkFactory(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException(nameof(randomNumberGenerator));
        }

        public NeuralNetwork CreateNetwork(int numberOfInputs, int numberOfHidden, int numberOfOutputs)
        {
            NetworkInput[] inputs = Enumerable.Range(0, numberOfHidden)
                .Select(i => new NetworkInput())
                .ToArray();

            Layer[] neuronLayers = CreateNeurons(inputs.Cast<IOutput>().ToArray(), numberOfHidden);

            Layer[] outputLayers = CreateOutputs(neuronLayers.Last().Outputs, numberOfOutputs);

            var allLayers = new List<Layer>(neuronLayers.Length + outputLayers.Length + 1);

            allLayers.Add(new Layer(inputs.Cast<IPropagate>().ToArray(), inputs.Cast<IOutput>().ToArray()));

            allLayers.AddRange(neuronLayers);
            allLayers.AddRange(outputLayers);
          
            return new NeuralNetwork(inputs, allLayers.Last().Outputs, allLayers.ToArray());
        }

        private Layer[] CreateNeurons(IOutput[] outputs, int numberOfNeurons)
        {
            //These will all form a layer
            List<Synapse> allSynapses = new List<Synapse>(numberOfNeurons * outputs.Length);
            
            //These will form another layer
            Neuron[] neurons = new Neuron[numberOfNeurons];

            for (int neuronIndex = 0; neuronIndex < numberOfNeurons; neuronIndex++)
            {
                Synapse[] synapses = outputs
                    .Select(o => new Synapse(o, _randomNumberGenerator.Next()))
                    .ToArray();

                allSynapses.AddRange(synapses);

                neurons[neuronIndex] = new Neuron(synapses.Cast<IOutput>().ToArray(), _randomNumberGenerator.Next());
            }

            return new Layer[]
            {
                new Layer( allSynapses.Cast<IPropagate>().ToArray(), allSynapses.Cast<IOutput>().ToArray()),
                new Layer( neurons.Cast<IPropagate>().ToArray(), neurons.Cast<IOutput>().ToArray()), 
            };
        }

        private Layer[] CreateOutputs(IOutput[] sourceOutputs, int numberOfNeurons)
        {
            //These will all form a layer
            List<Synapse> allSynapses = new List<Synapse>(numberOfNeurons * sourceOutputs.Length);

            //These will form another layer
            NetworkOutput[] outputs = new NetworkOutput[numberOfNeurons];

            for (int neuronIndex = 0; neuronIndex < numberOfNeurons; neuronIndex++)
            {
                Synapse[] synapses = outputs
                    .Select(o => new Synapse(o, _randomNumberGenerator.Next()))
                    .ToArray();

                allSynapses.AddRange(synapses);

                outputs[neuronIndex] = new NetworkOutput(synapses.Cast<IOutput>().ToArray());
            }

            return new Layer[]
            {
                new Layer( allSynapses.Cast<IPropagate>().ToArray(), allSynapses.Cast<IOutput>().ToArray()),
                new Layer( outputs.Cast<IPropagate>().ToArray(), outputs.Cast<IOutput>().ToArray()),
            };
        }
    }
}
