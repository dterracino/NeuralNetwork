namespace NeuralNetwork.WPF.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using GalaSoft.MvvmLight;

    public class MainViewModel
    {
        private readonly ObservableCollection<NodeViewModel> _nodes = new ObservableCollection<NodeViewModel>();
        private readonly ObservableCollection<ConnectionViewModel> _connections = new ObservableCollection<ConnectionViewModel>();

        private readonly Random _random = new Random();

        public MainViewModel()
        {
            var node1 = AddNode(100, 100);
            var node2 = AddNode(100, 200);
            

            var node1_1 = AddNode(200, 50);
            var node1_2 = AddNode(200, 150);
            var node1_3 = AddNode(200, 250);

            var node2_1 = AddNode(300, 100);
            var node2_2 = AddNode(300, 200);
            

            Connect(node1, node1_1);
            Connect(node1, node1_2);
            Connect(node1, node1_3);

            Connect(node2, node1_1);
            Connect(node2, node1_2);
            Connect(node2, node1_3);


            Connect(node1_1, node2_1);
            Connect(node1_2, node2_1);
            Connect(node1_3, node2_1);

            Connect(node1_1, node2_2);
            Connect(node1_2, node2_2);
            Connect(node1_3, node2_2);

        }

        private NodeViewModel AddNode(double x, double y)
        {
            var node= new NodeViewModel()
            {
                Position = new Point(x, y)
            };

            Nodes.Add(node);

            return node;
        }

        private void Connect(NodeViewModel source, NodeViewModel target)
        {
            Connections.Add(new ConnectionViewModel
            {
                Source = source,
                Target = target,
                Bias = _random.NextDouble()
            });
        }


        public ObservableCollection<NodeViewModel> Nodes
        {
            get { return _nodes; }
        }

        public ObservableCollection<ConnectionViewModel> Connections
        {
            get { return _connections; }
        }
    }
}