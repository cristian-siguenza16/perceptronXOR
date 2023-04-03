using System;

namespace PerceptronXOR
{   // Compuerta logica XOR
    class Program
    {
        static void Main(string[] args)
        {
            const double e = 2.71828;
            double sigmoide(double x)
            {
                return 1 / (1 + Math.Pow(e, -x));
            }
            Console.WriteLine("Aprendiendo...");
            //const double e = 2.71828; 
            //int[,] datos = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 1, 1 }, { 0, 0, 0 } };
            int[,] datos = { { 0, 0, 0 }, { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };
            Random aleatorio = new Random();

            double[] peso = { aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble() };
            double[] bias = { aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble() };
            bool apredizaje = true;
            int salidaInt, epocas =0;
            while (apredizaje)
            {
                apredizaje = false;
                for (int i = 0; i < 4; i++)
                {
                    double salidaDoub1 = (datos[i, 0] * peso[0]) + (datos[i, 1] * peso[1]) + bias[0];
                    double salidaDoub2 = (datos[i, 0] * peso[2]) + (datos[i, 1] * peso[3]) + bias[1];

                    salidaDoub1 = sigmoide(salidaDoub1);
                    salidaDoub2 = sigmoide(salidaDoub2);

                    double salidaDoub = (salidaDoub1 * peso[4]) + (salidaDoub2 * peso[5]) + bias[2];
                    if (salidaDoub > 0) salidaInt = 1;
                    else salidaInt = 0;
                    if (salidaInt != datos[i, 2])
                    {

                        peso[0] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        peso[1] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        bias[0] = aleatorio.NextDouble() - aleatorio.NextDouble();

                        peso[2] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        peso[3] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        bias[1] = aleatorio.NextDouble() - aleatorio.NextDouble();

                        peso[4] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        peso[5] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        bias[2] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        apredizaje = true;
                    }
                }
                epocas++;
            }
            // FIN del aprendizaje
            // Verificación de las salidas

            for (int i = 0; i < 4; i++)
            {
                double salidaDoub1 = (datos[i, 0] * peso[0]) + (datos[i, 1] * peso[1]) + bias[0];
                double salidaDoub2 = (datos[i, 0] * peso[2]) + (datos[i, 1] * peso[3]) + bias[1];

                salidaDoub1 = sigmoide(salidaDoub1);
                salidaDoub2 = sigmoide(salidaDoub2);

                double salidaDoub = (salidaDoub1 * peso[4]) + (salidaDoub2 * peso[5]) + bias[2];
                if (salidaDoub > 0) salidaInt = 1;
                else salidaInt = 0;

                Console.WriteLine("Entrada: " + datos[i, 0].ToString() + " XOR " + datos[i, 1].ToString() + " = " + datos[i, 2].ToString() + " | Perceptron: " + salidaInt);
            }
            Console.WriteLine("X1 Pesos W1 = " + peso[0].ToString() + " W2 " + peso[1].ToString() + " bias1 " + bias[0].ToString());
            Console.WriteLine("X2 Pesos W3 = " + peso[2].ToString() + " W4 " + peso[3].ToString() + " bias2 " + bias[1].ToString());
            Console.WriteLine("H1 Pesos W5 = " + peso[4].ToString() + " W6 " + peso[5].ToString() + " bias3 " + bias[2].ToString());
            Console.WriteLine("Epocas: " + epocas);
        }
    }

}
