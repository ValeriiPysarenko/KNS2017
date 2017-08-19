using System;
using AForge.Genetic;

namespace TSP
{
	// функція для завдання TSP (задача комівояжера)
	public class TSPFitnessFunction : IFitnessFunction
	{
		// карта
		private int[,]	map = null;
		// конструктор
		public TSPFitnessFunction( int[,] map )
		{
			this.map = map;
		}		
		// Оцінка хромосоми - обчислення значення функції
		public double Evaluate( IChromosome chromosome )
		{
			return 1 / ( PathLength( chromosome ) + 1 );
		}		
		// Переведення генотипу у фенотип
		public object Translate( IChromosome chromosome )
		{
			return chromosome.ToString( );
		}		
		// Обчислення довжини шляху, представленого зазначеною хромосомою		
		public double PathLength( IChromosome chromosome )
		{
			// шлях комівояжера
			ushort[] path = ((PermutationChromosome) chromosome).Value;

			// перевірка розміру шляху
			if ( path.Length != map.GetLength( 0 ) )
			{
				throw new ArgumentException( "Invalid path specified - not all cities are visited" );
			}
			// довжина шляху
			int		prev = path[0];
			int		curr = path[path.Length - 1];
			// обчислення відстані між останнім і першим містом
			double	dx = map[curr, 0] - map[prev, 0];
			double	dy = map[curr, 1] - map[prev, 1];
			double	pathLength = Math.Sqrt( dx * dx + dy * dy );
			// обчислення довжини шляху від першого міста до останнього 
			for ( int i = 1, n = path.Length; i < n; i++ )
			{
				// отримати поточне місто
				curr = path[i];

				// вирахувати відстань
				dx = map[curr, 0] - map[prev, 0];
				dy = map[curr, 1] - map[prev, 1];
				pathLength += Math.Sqrt( dx * dx + dy * dy );

				// помістити поточне місто як попереднє
				prev = curr;
			}

			return pathLength;
		}
	}
}
