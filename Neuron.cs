using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN
{
    class Neuron
    {
        private Neuron[] previous_layer;
        private double[] weights;
        public double input;
        public double output;
        public double delta;

        private double Sigmoid(double x)
        {
            return (1.0 / (1.0 + Math.Exp((-1.0) * x)));
        }

        public void Activate()
        {
            int len = previous_layer.Length;
            double sum = 0;

            for (int i = 0; i < len; i++)
                sum += weights[i] * previous_layer[i].output;

            input = sum + weights[len];
            output = Sigmoid(input);
        }

        public void WeightsChange(double gamma)
        {
            int len = previous_layer.Length;

            for (int i = 0; i < len; i++)
                weights[i] += delta * previous_layer[i].output * gamma;

            weights[len] += delta * gamma; 
        }

        public Neuron(Neuron[] layer, ref Random r)
        {
            if (layer != null)
            {
                previous_layer = layer;
                int len = layer.Length;
                weights = new double[len + 1];

                for (int i = 0; i < len + 1; i++)
                    weights[i] = r.NextDouble();
            }
            else
                weights = null;
        }
    }
}
