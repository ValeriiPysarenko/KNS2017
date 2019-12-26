using System;
using AForge.Genetic;

namespace TSP
{
	// ������� ��� �������� TSP (������ ����������)
	public class TSPFitnessFunction : IFitnessFunction
	{
		// �����
		private int[,]	map = null;
		// �����������
		public TSPFitnessFunction( int[,] map )
		{
			this.map = map;
		}		
		// ������ ��������� - ���������� �������� �������
		public double Evaluate( IChromosome chromosome )
		{
			return 1 / ( PathLength( chromosome ) + 1 );
		}		
		// ����������� �������� � �������
		public object Translate( IChromosome chromosome )
		{
			return chromosome.ToString( );
		}		
		// ���������� ������� �����, �������������� ���������� ����������		
		public double PathLength( IChromosome chromosome )
		{
			// ���� ����������
			ushort[] path = ((PermutationChromosome) chromosome).Value;

			// �������� ������ �����
			if ( path.Length != map.GetLength( 0 ) )
			{
				throw new ArgumentException( "Invalid path specified - not all cities are visited" );
			}
			// ������� �����
			int		prev = path[0];
			int		curr = path[path.Length - 1];
			// ���������� ������ �� ������� � ������ �����
			double	dx = map[curr, 0] - map[prev, 0];
			double	dy = map[curr, 1] - map[prev, 1];
			double	pathLength = Math.Sqrt( dx * dx + dy * dy );
			// ���������� ������� ����� �� ������� ���� �� ���������� 
			for ( int i = 1, n = path.Length; i < n; i++ )
			{
				// �������� ������� ����
				curr = path[i];

				// ���������� �������
				dx = map[curr, 0] - map[prev, 0];
				dy = map[curr, 1] - map[prev, 1];
				pathLength += Math.Sqrt( dx * dx + dy * dy );

				// �������� ������� ���� �� ��������
				prev = curr;
			}

			return pathLength;
		}
	}
}
