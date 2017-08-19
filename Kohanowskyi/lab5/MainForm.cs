using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using AForge;
using AForge.Genetic;

namespace TSP
{

	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private TSP.MapControl mapControl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox citiesCountBox;
		private System.Windows.Forms.Button generateMapButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox populationSizeBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox selectionBox;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox iterationsBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox currentIterationBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox pathLengthBox;
		private System.Windows.Forms.CheckBox greedyCrossoverBox;

		private System.ComponentModel.Container components = null;

		private int citiesCount = 20;
		private int populationSize = 40;
		private int iterations = 100;
		private int selectionMethod = 0;
		private bool greedyCrossover = true;

		private int[,]	map = null;

		private Thread	workerThread = null;
		private bool	needToStop = false;

		public MainForm( )
		{

			InitializeComponent();

			selectionBox.SelectedIndex = selectionMethod;
			greedyCrossoverBox.Checked = greedyCrossover;
			UpdateSettings( );
			GenerateMap( );

			// встановлення карти
			mapControl.RangeX = new IntRange( 0, 1000 );
			mapControl.RangeY = new IntRange( 0, 1000 );
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.generateMapButton = new System.Windows.Forms.Button();
            this.citiesCountBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.greedyCrossoverBox = new System.Windows.Forms.CheckBox();
            this.iterationsBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectionBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.populationSizeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pathLengthBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.currentIterationBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.mapControl = new TSP.MapControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();

            this.groupBox1.Controls.Add(this.generateMapButton);
            this.groupBox1.Controls.Add(this.citiesCountBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.mapControl);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 340);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Карта";

            this.generateMapButton.Location = new System.Drawing.Point(110, 309);
            this.generateMapButton.Name = "generateMapButton";
            this.generateMapButton.Size = new System.Drawing.Size(154, 22);
            this.generateMapButton.TabIndex = 3;
            this.generateMapButton.Text = "&Випадкова генерація";
            this.generateMapButton.Click += new System.EventHandler(this.generateMapButton_Click);

            this.citiesCountBox.Location = new System.Drawing.Point(50, 310);
            this.citiesCountBox.Name = "citiesCountBox";
            this.citiesCountBox.Size = new System.Drawing.Size(50, 20);
            this.citiesCountBox.TabIndex = 2;

            this.label1.Location = new System.Drawing.Point(10, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Міста:";

            this.groupBox2.Controls.Add(this.greedyCrossoverBox);
            this.groupBox2.Controls.Add(this.iterationsBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.selectionBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.populationSizeBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(320, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 225);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметри";

            this.greedyCrossoverBox.Location = new System.Drawing.Point(10, 87);
            this.greedyCrossoverBox.Name = "greedyCrossoverBox";
            this.greedyCrossoverBox.Size = new System.Drawing.Size(175, 24);
            this.greedyCrossoverBox.TabIndex = 7;
            this.greedyCrossoverBox.Text = "Жадібний алгоритм";

            this.iterationsBox.Location = new System.Drawing.Point(110, 178);
            this.iterationsBox.Name = "iterationsBox";
            this.iterationsBox.Size = new System.Drawing.Size(140, 20);
            this.iterationsBox.TabIndex = 5;
            this.iterationsBox.TextChanged += new System.EventHandler(this.iterationsBox_TextChanged);

            this.label4.Location = new System.Drawing.Point(10, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "К-сть ітерацій:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
   
            this.selectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionBox.Items.AddRange(new object[] {
            "Турнірна",
            "Ранжування",
            "Рулетка"});
            this.selectionBox.Location = new System.Drawing.Point(110, 65);
            this.selectionBox.Name = "selectionBox";
            this.selectionBox.Size = new System.Drawing.Size(140, 21);
            this.selectionBox.TabIndex = 3;

            this.label3.Location = new System.Drawing.Point(10, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Метод селекції:";

            this.populationSizeBox.Location = new System.Drawing.Point(110, 22);
            this.populationSizeBox.Name = "populationSizeBox";
            this.populationSizeBox.Size = new System.Drawing.Size(140, 20);
            this.populationSizeBox.TabIndex = 1;

            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Чисельність популяції:";

            this.groupBox3.Controls.Add(this.pathLengthBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.currentIterationBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(320, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 75);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поточна ітерація";

            this.pathLengthBox.Location = new System.Drawing.Point(110, 47);
            this.pathLengthBox.Name = "pathLengthBox";
            this.pathLengthBox.ReadOnly = true;
            this.pathLengthBox.Size = new System.Drawing.Size(140, 20);
            this.pathLengthBox.TabIndex = 3;
            this.pathLengthBox.TextChanged += new System.EventHandler(this.pathLengthBox_TextChanged);

            this.label7.Location = new System.Drawing.Point(10, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Довжина шляху:";

            this.currentIterationBox.Location = new System.Drawing.Point(110, 19);
            this.currentIterationBox.Name = "currentIterationBox";
            this.currentIterationBox.ReadOnly = true;
            this.currentIterationBox.Size = new System.Drawing.Size(140, 20);
            this.currentIterationBox.TabIndex = 1;

            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ітерація:";

            this.startButton.Location = new System.Drawing.Point(340, 325);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "&Страт";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);

            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(430, 325);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "С&топ";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);

            this.mapControl.Location = new System.Drawing.Point(10, 20);
            this.mapControl.Map = null;
            this.mapControl.Name = "mapControl";
            this.mapControl.Path = null;
            this.mapControl.Size = new System.Drawing.Size(280, 280);
            this.mapControl.TabIndex = 0;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(588, 360);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Traveling Salesman Problem using Genetic Algorithms";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}



		[STAThread]
		static void Main( ) 
		{
			Application.Run( new MainForm( ) );
		}

		private void MainForm_Closing( object sender, System.ComponentModel.CancelEventArgs e )
		{
			if ( ( workerThread != null ) && ( workerThread.IsAlive ) )
			{
				needToStop = true;
				workerThread.Join( );
			}
		}

		// Оновлення параметрів
		private void UpdateSettings( )
		{
			citiesCountBox.Text		= citiesCount.ToString( );
			populationSizeBox.Text	= populationSize.ToString( );
			iterationsBox.Text		= iterations.ToString( );
		}

		private void EnableControls( bool enable )
		{
			citiesCountBox.Enabled		= enable;
			populationSizeBox.Enabled	= enable;
			iterationsBox.Enabled		= enable;
			selectionBox.Enabled		= enable;

			generateMapButton.Enabled	= enable;

			startButton.Enabled	= enable;
			stopButton.Enabled	= !enable;
		}

		// Формування нової карти для задачі комівояжера
		private void GenerateMap( )
		{
			Random rand = new Random( (int) DateTime.Now.Ticks );

			// створення масиву координат
			map = new int[citiesCount, 2];

			for ( int i = 0; i < citiesCount; i++ )
			{
				map[i, 0] = rand.Next( 1001 );
				map[i, 1] = rand.Next( 1001 );
			}

			// вибір карти
			mapControl.Map = map;
			// стерти шлях якщо він порожній
			mapControl.Path = null;
		}

		// Випадкова генерація карти
		private void generateMapButton_Click( object sender, System.EventArgs e )
		{
			// отримання к-сті міст
			try
			{
				citiesCount = Math.Max( 5, Math.Min( 50, int.Parse( citiesCountBox.Text ) ) );
			}
			catch
			{
				citiesCount = 20;
			}
			citiesCountBox.Text = citiesCount.ToString( );

			// перегенерація карти
			GenerateMap( );
		}

		private void startButton_Click(object sender, System.EventArgs e)
		{
			// отримання розміру популяції
			try
			{
				populationSize = Math.Max( 10, Math.Min( 100, int.Parse( populationSizeBox.Text ) ) );
			}
			catch
			{
				populationSize = 40;
			}
			// ітерації
			try
			{
				iterations = Math.Max( 0, int.Parse( iterationsBox.Text ) );
			}
			catch
			{
				iterations = 100;
			}
			// оновлення параметрів
			UpdateSettings( );

			selectionMethod = selectionBox.SelectedIndex;
			greedyCrossover = greedyCrossoverBox.Checked;

			EnableControls( false );

			needToStop = false;
			workerThread = new Thread( new ThreadStart( SearchSolution ) );
			workerThread.Start( );
		}

		private void stopButton_Click( object sender, System.EventArgs e )
		{
			needToStop = true;
			workerThread.Join( );
			workerThread = null;
		}

		void SearchSolution( )
		{
			// створення фітнес функції
			TSPFitnessFunction fitnessFunction = new TSPFitnessFunction( map );
			// створення популяції
			Population population = new Population( populationSize,
				( greedyCrossover ) ? new TSPChromosome( map ) : new PermutationChromosome( citiesCount ),
				fitnessFunction,
				( selectionMethod == 0 ) ? (ISelectionMethod) new EliteSelection( ) :
				( selectionMethod == 1 ) ? (ISelectionMethod) new RankSelection( ) :
				(ISelectionMethod) new RouletteWheelSelection( )
				);
			// ітерації
			int i = 1;

			// петля
			while ( !needToStop )
			{
				// запус одного покоління генетичного алгоритму
				population.RunEpoch( );

				// відобразити поточний шлях
				mapControl.Path = ((PermutationChromosome) population.BestChromosome).Value;

				// встановити дані поточної ітерації
				currentIterationBox.Text = i.ToString( );
				pathLengthBox.Text = fitnessFunction.PathLength( population.BestChromosome ).ToString( );

				// наступна ітерація
				i++;


				if ( ( iterations != 0 ) && ( i > iterations ) )
					break;
			}

			EnableControls( true );
		}

        private void pathLengthBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void iterationsBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
	}
}
