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
        private int layers_count;

        private double DerivateSigmoid(double x)
        {
            return (Math.Exp((-1.0) * x) / ((1.0 + Math.Exp((-1.0) * x)) * (1.0 + Math.Exp((-1.0) * x))));
        }

        private void DeltaDistribution()
        {
            int layers = layers_count;

            for (int i = layers_count - 2; i > 1; i--)
            {
                for (int j = 0; j < network_layers[i]; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < network_layers[i + 1]; k++)
                    {
                        sum += neural[i + 1][k].delta * neural[i + 1][k].weights[j];
                    }

                    neural[i][j].delta = sum * DerivateSigmoid(neural[i][j].input);
                }
            }
        }

        public Network(int layers, int[] size, double gamma)
        {
            learning_rate = gamma;
            network_layers = size;
            neural = new Neuron[layers][];
            layers_count = layers;
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

        public double[] Run(double[] input_data)
        {
            int len = layers_count;
            double[] return_value = new double[network_layers[len - 1]];

            for (int i = 0; i < network_layers[0]; i++)
                neural[0][i].output = input_data[i];

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < network_layers[i]; j++)
                {
                    neural[i][j].Activate();

                    if (i == len - 1)
                        return_value[j] = neural[i][j].output;
                }
            }

            return return_value;
        }

        public void Learning(double[] input_data, double[] desired_results)
        {
            Run(input_data);
            int last = layers_count - 1;
            int len = network_layers[last];

            for (int i = 0; i < len; i++)
            {
                neural[last][i].delta = desired_results[i] - neural[last][i].output;
                neural[last][i].delta *= DerivateSigmoid(neural[last][i].input);
            }

            DeltaDistribution();

            len = layers_count;

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < network_layers[i]; j++)
                    neural[i][j].WeightsChange(learning_rate);
            }
        }
    }
}
