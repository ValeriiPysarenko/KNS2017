
using System;
using AForge.Genetic;

namespace TSP
{
	public class TSPChromosome : PermutationChromosome
	{
		private int[,] map = null;
		public TSPChromosome( int[,] map ) : base( map.GetLength( 0 ) )
		{
			this.map = map;
		}

		protected TSPChromosome( TSPChromosome source ) : base( source )
		{
			this.map = source.map;
		}

		//��������� ����(���������) ���������
		public override IChromosome CreateOffspring( )
		{
			return new TSPChromosome( map );
		}

		//��������� ��ﳿ ���������
		public override IChromosome Clone( )
		{
			return new TSPChromosome( this );
		}

		//�������� �����������
		public override void Crossover( IChromosome pair )
		{
			TSPChromosome p = (TSPChromosome) pair;

			// �������� ����������� ����
			if ( ( p != null ) && ( p.length == length ) )
			{
				ushort[] child1 = new ushort[length];
				ushort[] child2 = new ushort[length];

				// ��������� ���� ����
				CreateChildUsingCrossover( this.val, p.val, child1 );
				CreateChildUsingCrossover( p.val, this.val, child2 );

				// ����� ������ �����
				this.val	= child1;
				p.val		= child2;
			}
		}

		// ��������� ���� ������ �������������� �������� �� ������
		private void CreateChildUsingCrossover( ushort[] parent1, ushort[] parent2, ushort[] child )
		{
			// ���������� �����, ��� �������, ���� ������ ��� ��� �������� � �����
			bool[]	geneIsBusy = new bool[length];
			// ��������� ��� � ������ � ���� ��������� ���������
			ushort	prev, next1, next2;
			// ���������� ��������� - �������� � ���������,���� �� �� �� ������
			bool	valid1, valid2;
			int		j, k = length - 1;
			// ������ ��� ������ �������� �� ������� � ������
			prev = child[0] = parent2[0];
			geneIsBusy[prev] = true;
			// ���������� ��� ����� ���� ������
			for ( int i = 1; i < length; i++ )
			{
				// ������ ��������� ��� ���� ������������ � ���� ������
				// 1
				for ( j = 0; j < k; j++ )
				{
					if ( parent1[j] == prev )
						break;
				}
				next1 = ( j == k ) ? parent1[0] : parent1[j + 1];
				// 2
				for ( j = 0; j < k; j++ )
				{
					if ( parent2[j] == prev )
						break;
				}
				next2 = ( j == k ) ? parent2[0] : parent2[j + 1];

				// �������� ���� ��������� �� ����������
				valid1 = !geneIsBusy[next1];
				valid2 = !geneIsBusy[next2];

				// ���� ����
				if ( valid1 && valid2 )
				{
					// ������ ��������� �������
					// ���� ������ ����������� ����
					double dx1 = map[next1, 0] - map[prev, 0];
					double dy1 = map[next1, 1] - map[prev, 1];
					double dx2 = map[next2, 0] - map[prev, 0];
					double dy2 = map[next2, 1] - map[prev, 1];

					prev = ( Math.Sqrt( dx1 * dx1 + dy1 * dy1 ) < Math.Sqrt( dx2 * dx2 + dy2 * dy2 ) ) ? next1 : next2; 
				}
				else if ( !( valid1 || valid2 ) )
				{
					// ����� � ��������� �� ���������
					// ���� ����������� ����, ���� � ������� � ������
					int r = j = rand.Next( length );

					// ������ ��� ���� 
					while ( ( r < length ) && ( geneIsBusy[r] == true ) )
						r++;
					if ( r == length )
					{
						// �� ��������, ��� �����
						r = j - 1;
						while ( geneIsBusy[r] == true )	// && ( r >= 0 )
							r--;
					}
					prev = (ushort) r;
				}
				else
				{
					// ���� � ��������� ���������
					prev = ( valid1 ) ? next1 : next2;
				}

				child[i] = prev;
				geneIsBusy[prev] = true;
			}
		}
	}
}
