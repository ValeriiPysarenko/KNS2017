using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using AForge;

namespace TSP
{

	public class MapControl : System.Windows.Forms.Control
	{
		
		private System.ComponentModel.Container components = null;

		
		private Pen		blackPen = new Pen( Color.Black );
		private Brush		whiteBrush = new SolidBrush( Color.White );
		private IntRange	rangeX = new IntRange( 0, 1000 );
		private IntRange	rangeY = new IntRange( 0, 1000 );
		// карта
		private int[,]		map = null;
		// шлях
		private ushort[]	path = null;


		// діапазон по X 
		public IntRange RangeX
		{
			get { return rangeX; }
			set
			{
				if ( value != null )
				{
					rangeX = value;
					Invalidate( );
				}
			}
		}
		// діапазон по Y 
		public IntRange RangeY
		{
			get { return rangeY; }
			set
			{
				if ( value != null )
				{
					rangeY = value;
					Invalidate( );
				}
			}
		}


		// Карта
		public int[,] Map
		{
			get { return map; }
			set
			{
				map = value;
				Invalidate( );
			}
		}
		// Шлях
		public ushort[] Path
		{
			get { return path; }
			set
			{
				path = value;
				Invalidate( );
			}
		}
		public MapControl( )
		{
			InitializeComponent();
			SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
				ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true );
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
				blackPen.Dispose( );
				whiteBrush.Dispose( );
			}
			base.Dispose( disposing );
		}


		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}


		protected override void OnPaint( PaintEventArgs pe )
		{
			Graphics	g = pe.Graphics;
			int			clientWidth = ClientRectangle.Width;
			int			clientHeight = ClientRectangle.Height;
			double		xFactor = (double)( clientWidth - 10 ) / ( rangeX.Length );
			double		yFactor = (double)( clientHeight - 10 ) / ( rangeY.Length );

			// заповнення форми білим кольором
			g.FillRectangle( whiteBrush, 0, 0, clientWidth - 1, clientHeight - 1 );

			// намалювати чорний прямокутник
			g.DrawRectangle( blackPen, 0, 0, clientWidth - 1, clientHeight - 1 );

			// намалювати карту
			if ( map != null )
			{
				Brush brush = new SolidBrush( Color.Red );

				// намалювати всі точки
				for ( int i = 0, n = map.GetLength( 0 ); i < n; i++ )
				{
					int x = (int) ( ( map[i, 0] - rangeX.Min ) * xFactor );
					int y = (int) ( ( map[i, 1] - rangeY.Min ) * yFactor );

					x += 5;
					y = clientHeight - 6 - y;

					g.FillRectangle( brush, x - 2, y - 2, 5, 5 );
				}

				brush.Dispose( );
			}
			// намалювати шлях
			if ( path != null )
			{
				Pen pen = new Pen( Color.Blue, 1 );
				int prev = path[path.Length - 1];
				int x1 = (int) ( ( map[prev, 0] - rangeX.Min ) * xFactor );
				int y1 = (int) ( ( map[prev, 1] - rangeY.Min ) * yFactor );

				x1 += 5;
				y1 = clientHeight - 6 - y1;

				// з'єднати всі міста
				for ( int i = 0, n = path.Length; i < n; i++ )
				{
					int curr = path[ i ];

					// вирахувати координати поточного міста
					int x2 = (int) ( ( map[curr, 0] - rangeX.Min ) * xFactor );
					int y2 = (int) ( ( map[curr, 1] - rangeY.Min ) * yFactor );

					x2 += 5;
					y2 = clientHeight - 6 - y2;

					// під'єднати попереднє місто до поточного
					g.DrawLine( pen, x1, y1, x2, y2 );

					x1 = x2;
					y1 = y2;
				}
			}

			// Виклик базового класу OnPaint
			base.OnPaint(pe);
		}
	}
}
