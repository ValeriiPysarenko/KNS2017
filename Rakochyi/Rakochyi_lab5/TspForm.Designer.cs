//////////////////////////////////////////////////////////////////////////////////////////////////
// File Name: Tsp.Form.Designer.cs
//      Date: 06/01/2006
// Copyright (c) 2006 Michael LaLena. All rights reserved.
// Permission to use, copy, modify, and distribute this Program and its documentation,
//  if any, for any purpose and without fee is hereby granted, provided that:
//   (i) you not charge any fee for the Program, and the Program not be incorporated
//       by you in any software or code for which compensation is expected or received;
//   (ii) the copyright notice listed above appears in all copies;
//   (iii) both the copyright notice and this Agreement appear in all supporting documentation; and
//   (iv) the name of Michael LaLena or lalena.com not be used in advertising or publicity
//          pertaining to distribution of the Program without specific, written prior permission. 
///////////////////////////////////////////////////////////////////////////////////////////////////
namespace Tsp
{
    partial class TspForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tourDiagram = new System.Windows.Forms.PictureBox();
            this.populationSizeTextBox = new System.Windows.Forms.TextBox();
            this.PopulationSizeLabel = new System.Windows.Forms.Label();
            this.lastIterationLabel = new System.Windows.Forms.Label();
            this.lastIterationValue = new System.Windows.Forms.Label();
            this.lastTourLabel = new System.Windows.Forms.Label();
            this.lastFitnessValue = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.maxGenerationLabel = new System.Windows.Forms.Label();
            this.maxGenerationTextBox = new System.Windows.Forms.TextBox();
            this.openCityListButton = new System.Windows.Forms.Button();
            this.clearCityListButton = new System.Windows.Forms.Button();
            this.NumberCitiesLabel = new System.Windows.Forms.Label();
            this.NumberCitiesValue = new System.Windows.Forms.Label();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tourDiagram)).BeginInit();
            this.SuspendLayout();
            // 
            // tourDiagram
            // 
            this.tourDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tourDiagram.BackColor = System.Drawing.Color.White;
            this.tourDiagram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tourDiagram.Location = new System.Drawing.Point(15, 12);
            this.tourDiagram.Name = "tourDiagram";
            this.tourDiagram.Size = new System.Drawing.Size(467, 464);
            this.tourDiagram.TabIndex = 0;
            this.tourDiagram.TabStop = false;
            this.tourDiagram.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tourDiagram_MouseDown);
            // 
            // populationSizeTextBox
            // 
            this.populationSizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.populationSizeTextBox.Location = new System.Drawing.Point(488, 30);
            this.populationSizeTextBox.Name = "populationSizeTextBox";
            this.populationSizeTextBox.Size = new System.Drawing.Size(116, 21);
            this.populationSizeTextBox.TabIndex = 1;
            this.populationSizeTextBox.Text = "10000";
            // 
            // PopulationSizeLabel
            // 
            this.PopulationSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PopulationSizeLabel.AutoSize = true;
            this.PopulationSizeLabel.Location = new System.Drawing.Point(485, 14);
            this.PopulationSizeLabel.Name = "PopulationSizeLabel";
            this.PopulationSizeLabel.Size = new System.Drawing.Size(92, 13);
            this.PopulationSizeLabel.TabIndex = 0;
            this.PopulationSizeLabel.Text = "Population size";
            // 
            // lastIterationLabel
            // 
            this.lastIterationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastIterationLabel.AutoSize = true;
            this.lastIterationLabel.BackColor = System.Drawing.SystemColors.Control;
            this.lastIterationLabel.Location = new System.Drawing.Point(488, 213);
            this.lastIterationLabel.Name = "lastIterationLabel";
            this.lastIterationLabel.Size = new System.Drawing.Size(56, 13);
            this.lastIterationLabel.TabIndex = 0;
            this.lastIterationLabel.Text = "Iteration";
            // 
            // lastIterationValue
            // 
            this.lastIterationValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastIterationValue.BackColor = System.Drawing.SystemColors.Control;
            this.lastIterationValue.Location = new System.Drawing.Point(488, 238);
            this.lastIterationValue.Name = "lastIterationValue";
            this.lastIterationValue.Size = new System.Drawing.Size(117, 13);
            this.lastIterationValue.TabIndex = 0;
            // 
            // lastTourLabel
            // 
            this.lastTourLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastTourLabel.AutoSize = true;
            this.lastTourLabel.BackColor = System.Drawing.SystemColors.Window;
            this.lastTourLabel.Location = new System.Drawing.Point(128, 425);
            this.lastTourLabel.Name = "lastTourLabel";
            this.lastTourLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lastTourLabel.Size = new System.Drawing.Size(79, 13);
            this.lastTourLabel.TabIndex = 0;
            this.lastTourLabel.Text = "Route length";
            // 
            // lastFitnessValue
            // 
            this.lastFitnessValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastFitnessValue.BackColor = System.Drawing.SystemColors.Window;
            this.lastFitnessValue.Location = new System.Drawing.Point(129, 448);
            this.lastFitnessValue.Name = "lastFitnessValue";
            this.lastFitnessValue.Size = new System.Drawing.Size(85, 13);
            this.lastFitnessValue.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(640, 249);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(138, 38);
            this.StartButton.TabIndex = 10;
            this.StartButton.Text = "Buid route";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // maxGenerationLabel
            // 
            this.maxGenerationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxGenerationLabel.AutoSize = true;
            this.maxGenerationLabel.Location = new System.Drawing.Point(485, 61);
            this.maxGenerationLabel.Name = "maxGenerationLabel";
            this.maxGenerationLabel.Size = new System.Drawing.Size(63, 13);
            this.maxGenerationLabel.TabIndex = 0;
            this.maxGenerationLabel.Text = "Iter count";
            // 
            // maxGenerationTextBox
            // 
            this.maxGenerationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxGenerationTextBox.Location = new System.Drawing.Point(488, 77);
            this.maxGenerationTextBox.Name = "maxGenerationTextBox";
            this.maxGenerationTextBox.Size = new System.Drawing.Size(116, 21);
            this.maxGenerationTextBox.TabIndex = 4;
            this.maxGenerationTextBox.Text = "10000000";
            // 
            // openCityListButton
            // 
            this.openCityListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openCityListButton.Location = new System.Drawing.Point(640, 124);
            this.openCityListButton.Name = "openCityListButton";
            this.openCityListButton.Size = new System.Drawing.Size(138, 38);
            this.openCityListButton.TabIndex = 8;
            this.openCityListButton.Text = "Load  cities coordinats";
            this.openCityListButton.UseVisualStyleBackColor = true;
            this.openCityListButton.Click += new System.EventHandler(this.openCityListButton_Click);
            // 
            // clearCityListButton
            // 
            this.clearCityListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearCityListButton.Location = new System.Drawing.Point(640, 14);
            this.clearCityListButton.Name = "clearCityListButton";
            this.clearCityListButton.Size = new System.Drawing.Size(138, 38);
            this.clearCityListButton.TabIndex = 9;
            this.clearCityListButton.Text = "Clear field";
            this.clearCityListButton.UseVisualStyleBackColor = true;
            this.clearCityListButton.Click += new System.EventHandler(this.clearCityListButton_Click);
            // 
            // NumberCitiesLabel
            // 
            this.NumberCitiesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberCitiesLabel.BackColor = System.Drawing.SystemColors.Window;
            this.NumberCitiesLabel.Location = new System.Drawing.Point(254, 425);
            this.NumberCitiesLabel.Name = "NumberCitiesLabel";
            this.NumberCitiesLabel.Size = new System.Drawing.Size(87, 13);
            this.NumberCitiesLabel.TabIndex = 12;
            this.NumberCitiesLabel.Text = "Cities count";
            // 
            // NumberCitiesValue
            // 
            this.NumberCitiesValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberCitiesValue.BackColor = System.Drawing.SystemColors.Window;
            this.NumberCitiesValue.Location = new System.Drawing.Point(260, 449);
            this.NumberCitiesValue.Name = "NumberCitiesValue";
            this.NumberCitiesValue.Size = new System.Drawing.Size(48, 13);
            this.NumberCitiesValue.TabIndex = 13;
            // 
            // selectFileButton
            // 
            this.selectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFileButton.Location = new System.Drawing.Point(488, 172);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(113, 23);
            this.selectFileButton.TabIndex = 7;
            this.selectFileButton.Text = "Browse";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Visible = false;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(485, 118);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(117, 13);
            this.fileNameLabel.TabIndex = 0;
            this.fileNameLabel.Text = "City XML File Name";
            this.fileNameLabel.Visible = false;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameTextBox.Location = new System.Drawing.Point(488, 134);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(116, 21);
            this.fileNameTextBox.TabIndex = 6;
            this.fileNameTextBox.Text = "../../Cities.xml";
            this.fileNameTextBox.Visible = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLabel.Location = new System.Drawing.Point(12, 479);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(422, 13);
            this.StatusLabel.TabIndex = 9;
            this.StatusLabel.Text = "Open a City List or click the map to place cities.";
            this.StatusLabel.Visible = false;
            // 
            // TspForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(806, 671);
            this.Controls.Add(this.NumberCitiesValue);
            this.Controls.Add(this.NumberCitiesLabel);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.clearCityListButton);
            this.Controls.Add(this.openCityListButton);
            this.Controls.Add(this.maxGenerationTextBox);
            this.Controls.Add(this.maxGenerationLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.lastFitnessValue);
            this.Controls.Add(this.lastTourLabel);
            this.Controls.Add(this.lastIterationValue);
            this.Controls.Add(this.lastIterationLabel);
            this.Controls.Add(this.PopulationSizeLabel);
            this.Controls.Add(this.populationSizeTextBox);
            this.Controls.Add(this.tourDiagram);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TspForm";
            this.Text = "LAB_5";
            ((System.ComponentModel.ISupportInitialize)(this.tourDiagram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox tourDiagram;
        private System.Windows.Forms.TextBox populationSizeTextBox;
        private System.Windows.Forms.Label PopulationSizeLabel;
        private System.Windows.Forms.Label lastIterationLabel;
        private System.Windows.Forms.Label lastIterationValue;
        private System.Windows.Forms.Label lastTourLabel;
        private System.Windows.Forms.Label lastFitnessValue;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label maxGenerationLabel;
        private System.Windows.Forms.TextBox maxGenerationTextBox;
        private System.Windows.Forms.Button openCityListButton;
        private System.Windows.Forms.Button clearCityListButton;
        private System.Windows.Forms.Label NumberCitiesLabel;
        private System.Windows.Forms.Label NumberCitiesValue;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label StatusLabel;
    }
}

