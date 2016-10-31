using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN
{
    class Network
    {
        private double learning_rate;
        private int[] network_layers;
        private Neuron[][] neural;
        private Random generator;

        public Network(int layers, int[] size, double gamma)
        {
            learning_rate = gamma;
            network_layers = size;
            neural = new Neuron[layers][];
            generator = new Random();

            for (int i = 0; i < layers; i++)
            {
                neural[i] = new Neuron[size[i]];

                for (int j = 0; j < size[i]; j++)
                {
                    if (i == 0)
                        neural[i][j] = new Neuron(null, ref generator);
                    else
                        neural[i][j] = new Neuron(neural[i - 1], ref generator);
                }
            }
        }
    }
}
