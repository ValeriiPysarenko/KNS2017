using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static bool countMax = true;

        static string path = "test.txt";

        static string max = "";
        static string min = "";

        static Random random = new Random();
        static void Main(string[] args)
        {
            Run_Click();
            Console.WriteLine("Result");
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.ReadKey();
        }



        private static void Run_Click()
        {


            countMax = true;
            calculate();
            countMax = false;
            calculate();

            File.Delete(path);
        }

        static void calculate()
        {
            File.Delete(path);

            FileStream f = File.Create(path);
            f.Close();

            Population p;
            StreamWriter file = new StreamWriter(path);
            int population = 100;
            p = new Population(file, population);

            int gen = 0;
            while (gen <= 1000)
            {
                p.evolve(file);
                ++gen;
            }
            file.Close();

            int lineRead = 0;

            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                int value = Convert.ToInt32(line.Split(';')[3].Split(' ')[2]);
                lineRead++;

                if (countMax)
                {
                    if (lineRead < 9)
                    {

                        Console.WriteLine(line + "\n");
                    }
                    else
                    {
                        Console.WriteLine(lines[lines.Length - 1] + "\n\n");
                        max = "Max: " + lines[lines.Length - 1];
                        value = Convert.ToInt32(lines[lines.Length - 1].Split(';')[3].Split(' ')[2]);

                        break;
                    }
                }
                else
                {
                    if (lineRead < 9)
                    {
                        Console.WriteLine(line + "\n");
                    }
                    else
                    {

                        Console.WriteLine(lines[lines.Length - 1] + "\n\n");
                        min = "Min: " + lines[lines.Length - 1];

                        value = Convert.ToInt32(lines[lines.Length - 1].Split(';')[3].Split(' ')[2]);
                        break;
                    }
                }
            }
        }

        public static double GetRandomNumber(double min, double max)
        {
            return (random.NextDouble() * (max - min)) + min;
        }

        public class Genotype
        {
            public int[] genes;

            public Genotype()
            {
                this.genes = new int[3];
                for (int i = 0; i < genes.Length; i++)
                {
                    this.genes[i] = (int)GetRandomNumber(-10, 53);
                }
            }

            public void mutate()
            {
                for (int i = 0; i < genes.Length; i++)
                {
                    if (GetRandomNumber(0.0, 100) < 5)
                    {
                        this.genes[i] = (int)GetRandomNumber(-10, 53);
                    }
                }
            }
        }

        static Genotype crossover(Genotype a, Genotype b)
        {
            Genotype c = new Genotype();
            for (int i = 0; i < c.genes.Length; i++)
            {
                if (GetRandomNumber(0.0, 1) < 0.5)
                {
                    c.genes[i] = a.genes[i];
                }
                else
                {
                    c.genes[i] = b.genes[i];
                }
            }
            return c;
        }

        public class Phenotype
        {
            double i_x;
            double i_x2;
            double i_x3;

            public Phenotype(Genotype g)
            {
                this.i_x = g.genes[0];
                this.i_x2 = g.genes[1];
                this.i_x3 = g.genes[2];
            }

            public double evaluate(System.IO.StreamWriter file)
            {
                double fitness = 0;

                if (countMax)
                    fitness -= 12 - 8 * i_x - 40 * i_x2 + 3 * i_x3;
                else
                    fitness += 12 - 8 * i_x - 40 * i_x2 + 3 * i_x3;

                file.WriteLine("x: " + i_x + "; x2: " + i_x2 + "; x3: " + i_x3 + "; func: " + fitness);
                return fitness;
            }
        }

        public class Individual : IComparable<Individual>
        {
            public Genotype i_genotype;
            public Phenotype i_phenotype;
            double i_fitness;

            public Individual()
            {
                this.i_genotype = new Genotype();
                this.i_phenotype = new Phenotype(i_genotype);
                this.i_fitness = 0.0;
            }

            public void evaluate(System.IO.StreamWriter file)
            {
                this.i_fitness = i_phenotype.evaluate(file);
            }

            int IComparable<Individual>.CompareTo(Individual objI)
            {
                Individual iToCompare = (Individual)objI;
                if (i_fitness < iToCompare.i_fitness)
                {
                    return -1;
                }
                else if (i_fitness > iToCompare.i_fitness)
                {
                    return 1;
                }
                return 0;
            }
        }

        public static Individual breed(Individual a, Individual b)
        {
            Individual c = new Individual();
            c.i_genotype = crossover(a.i_genotype, b.i_genotype);
            c.i_genotype.mutate();
            c.i_phenotype = new Phenotype(c.i_genotype);
            return c;
        }

        public class Population
        {
            Individual[] pop;
            public Population(System.IO.StreamWriter file, int populationNum)
            {
                this.pop = new Individual[populationNum];

                for (int i = 0; i < populationNum; i++)
                {
                    this.pop[i] = new Individual();
                    this.pop[i].evaluate(file);
                }
                Array.Sort(pop);
            }

            public void evolve(System.IO.StreamWriter file)
            {
                Individual a = select(100),
                            b = select(100),
                            x = breed(a, b);

                if (countMax)
                    this.pop[0] = x;
                else
                    this.pop[this.pop.Length - 1] = x;

                x.evaluate(file);
                Array.Sort(pop);
            }

            Individual select(int popNum)
            {
                int which = 0;

                which = (int)Math.Floor(((float)popNum - 1E-6) * (1.0 - Math.Pow(GetRandomNumber(0.0, 1.0), 2)));

                return pop[which];
            }
        }
    }





}
