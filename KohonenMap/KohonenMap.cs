using System;

namespace KohonenMap
{
    public class KohonenMap
    {
        const int _EPOCH = 1000; // эпоха
        const double _ETA = 0.1; // скорость обучения
        readonly double _SIGMA; // начальный радиус BMU
        readonly double _LAMBDA; // постоянная времени

        double eta; // уменьшающаяся скорость обучения
        double sigma; // уменьшающийся радиус BMU
        double theta; // влияние расстояния от узла до BMU на интенсивность обучение этого узла

        public double Error { get; set; }

        private double[][] vectors;
        private double[,][] weights;

        public KohonenMap(int dimension, double[,] vectors)
        {
            int dimensionW = dimension;
            int dimensionH = dimension;
            _SIGMA = Math.Max(dimensionW, dimensionH) / 2;
            _LAMBDA = _EPOCH / Math.Log(_SIGMA);

            SetVectors(vectors);
            Random r = new Random(DateTime.Now.Millisecond);
            ArraysInitialization(dimensionW, dimensionH, r);
            Training();
        }

        private void ArraysInitialization(int dimensionW, int dimensionH, Random r)
        {
            weights = new double[dimensionH, dimensionW][];

            for (int ni = 0; ni < weights.GetLength(0); ni++)
            {
                for (int nj = 0; nj < weights.GetLength(1); nj++)
                {
                    weights[ni, nj] = new double[vectors[0].Length];
                    for (int w = 0; w < weights[ni, nj].Length; w++)
                    {
                        weights[ni, nj][w] = r.NextDouble();
                    }
                }
            }
        }

        public double[,] GetMap(int parameterNum)
        {
            if (parameterNum < 0 || parameterNum >= vectors[0].Length)
                throw new Exception("Некорректный номер параметра!");

            double[,] res = new double[weights.GetLength(0), weights.GetLength(1)];
            for (int ni = 0; ni < weights.GetLength(0); ni++)
            {
                for (int nj = 0; nj < weights.GetLength(1); nj++)
                {
                    res[ni, nj] = weights[ni, nj][parameterNum];
                }
            }
            return res;
        }


        private void Training()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int epoch = 0; epoch < _EPOCH; epoch++)
            {
                double[] targetInputVector = vectors[r.Next(0, vectors.GetLength(0))];
                Node bmu = FindBMU(targetInputVector);

                sigma = Sigma(epoch);
                eta = Eta(epoch);

                UpdateWeights(bmu, targetInputVector);
            }
            GetError();
        }

        private Node FindBMU(double[] vector)
        {
            double min = 10000;
            double distance = 0;
            Node bmu = new Node();

            for (int ni = 0; ni < weights.GetLength(0); ni++)
            {
                for (int nj = 0; nj < weights.GetLength(1); nj++)
                {
                    distance = DistBetwVectors(weights[ni, nj], vector);
                    if (distance < min)
                    {
                        min = distance;
                        bmu.X = ni;
                        bmu.Y = nj;
                    }
                }
            }
            return bmu;
        }

        private double SquaredDistBetwNodes(Node a, Node b)
        {
            return (b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y);
        }

        private double DistBetwVectors(double[] weightVector, double[] inputVector)
        {
            double distance = 0;
            for (int x = 0; x < weightVector.Length; x++)
            {
                distance += (inputVector[x] - weightVector[x]) * (inputVector[x] - weightVector[x]);
            }
            return Math.Sqrt(distance);
        }

        private void UpdateWeights(Node bmu, double[] targetInputVector)
        {
            for (int x = 0; x < weights.GetLength(0); x++)
            {
                for (int y = 0; y < weights.GetLength(1); y++)
                {
                    theta = Theta(new Node(x, y), bmu);

                    double exciteVectW, InputVectW;
                    for (int w = 0; w < weights[x, y].Length; w++)
                    {
                        exciteVectW = weights[x, y][w];
                        InputVectW = targetInputVector[w];
                        weights[x, y][w] += theta * eta * (InputVectW - exciteVectW);
                    }
                }
            }
        }

        private double Eta(int epoch)
        {
            return _ETA * Math.Exp(-(double)epoch / _EPOCH);
        }

        private double Theta(Node node, Node BMU)
        {
            return Math.Exp(-SquaredDistBetwNodes(node, BMU) / (2 * (sigma * sigma)));
        }

        private double Sigma(int epoch)
        {
            return _SIGMA * Math.Exp(-epoch / _LAMBDA);
        }

        private void GetError()
        {
            Error = 0;
            double sum = 0;
            for (int i = 0; i < vectors.GetLength(0); i++)
            {
                double[] targetInputVector = vectors[i];
                Node bmu = FindBMU(targetInputVector);
                sum += DistBetwVectors(weights[bmu.X, bmu.Y], targetInputVector);
            }
            Error = sum / vectors.GetLength(0);
        }

        private struct Node
        {
            public Node(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }
        }

        private void SetVectors(double[,] vectors)
        {
            double[][] res = new double[vectors.GetLength(0)][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new double[vectors.GetLength(1)];
                for (int j = 0; j < res[i].Length; j++)
                {
                    res[i][j] = vectors[i, j];
                }
            }
            this.vectors = res;
        }
    }
}
