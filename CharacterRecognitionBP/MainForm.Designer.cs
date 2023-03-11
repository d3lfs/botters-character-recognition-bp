﻿namespace CharacterRecognitionPerceptron
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clearBtn = new System.Windows.Forms.Button();
            this.predictBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.canvasContainer = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.epochsInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trainBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.predictedOutput = new System.Windows.Forms.Label();
            this.totalErrorLabel = new System.Windows.Forms.Label();
            this.dataSetsFeed = new System.Windows.Forms.ListBox();
            this.resetPerceptronModel = new System.Windows.Forms.Button();
            this.learningRateTrackbar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.learningRate = new System.Windows.Forms.Label();
            this.randCharImageBtn = new System.Windows.Forms.Button();
            this.stopTraining = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.epochsLabel = new System.Windows.Forms.Label();
            this.loadDataSetBtn = new System.Windows.Forms.Button();
            this.dataSetPath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(12, 273);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(116, 34);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // predictBtn
            // 
            this.predictBtn.Location = new System.Drawing.Point(279, 127);
            this.predictBtn.Name = "predictBtn";
            this.predictBtn.Size = new System.Drawing.Size(85, 34);
            this.predictBtn.TabIndex = 2;
            this.predictBtn.Text = "Predict";
            this.predictBtn.UseVisualStyleBackColor = true;
            this.predictBtn.Click += new System.EventHandler(this.predictBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(279, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(85, 85);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // canvasContainer
            // 
            this.canvasContainer.BackColor = System.Drawing.Color.White;
            this.canvasContainer.Location = new System.Drawing.Point(12, 12);
            this.canvasContainer.Name = "canvasContainer";
            this.canvasContainer.Size = new System.Drawing.Size(250, 250);
            this.canvasContainer.TabIndex = 4;
            this.canvasContainer.TabStop = false;
            this.canvasContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseDown);
            this.canvasContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseMove);
            this.canvasContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "15x15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Predicted Output";
            // 
            // epochsInput
            // 
            this.epochsInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.epochsInput.Location = new System.Drawing.Point(21, 483);
            this.epochsInput.Name = "epochsInput";
            this.epochsInput.Size = new System.Drawing.Size(116, 29);
            this.epochsInput.TabIndex = 7;
            this.epochsInput.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Epochs:";
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(141, 481);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(119, 34);
            this.trainBtn.TabIndex = 9;
            this.trainBtn.Text = "Train";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.trainBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "Train Perceptron";
            // 
            // predictedOutput
            // 
            this.predictedOutput.AutoSize = true;
            this.predictedOutput.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.predictedOutput.Location = new System.Drawing.Point(379, 39);
            this.predictedOutput.Name = "predictedOutput";
            this.predictedOutput.Size = new System.Drawing.Size(0, 37);
            this.predictedOutput.TabIndex = 11;
            // 
            // totalErrorLabel
            // 
            this.totalErrorLabel.AutoSize = true;
            this.totalErrorLabel.Location = new System.Drawing.Point(409, 347);
            this.totalErrorLabel.Name = "totalErrorLabel";
            this.totalErrorLabel.Size = new System.Drawing.Size(63, 15);
            this.totalErrorLabel.TabIndex = 12;
            this.totalErrorLabel.Text = "Total Error:";
            // 
            // dataSetsFeed
            // 
            this.dataSetsFeed.FormattingEnabled = true;
            this.dataSetsFeed.ItemHeight = 15;
            this.dataSetsFeed.Location = new System.Drawing.Point(279, 372);
            this.dataSetsFeed.Name = "dataSetsFeed";
            this.dataSetsFeed.Size = new System.Drawing.Size(320, 214);
            this.dataSetsFeed.TabIndex = 13;
            // 
            // resetPerceptronModel
            // 
            this.resetPerceptronModel.Location = new System.Drawing.Point(21, 558);
            this.resetPerceptronModel.Name = "resetPerceptronModel";
            this.resetPerceptronModel.Size = new System.Drawing.Size(239, 32);
            this.resetPerceptronModel.TabIndex = 14;
            this.resetPerceptronModel.Text = "Reset";
            this.resetPerceptronModel.UseVisualStyleBackColor = true;
            this.resetPerceptronModel.Click += new System.EventHandler(this.resetPerceptronModel_Click);
            // 
            // learningRateTrackbar
            // 
            this.learningRateTrackbar.Location = new System.Drawing.Point(12, 390);
            this.learningRateTrackbar.Maximum = 1000;
            this.learningRateTrackbar.Minimum = 20;
            this.learningRateTrackbar.Name = "learningRateTrackbar";
            this.learningRateTrackbar.Size = new System.Drawing.Size(181, 45);
            this.learningRateTrackbar.TabIndex = 15;
            this.learningRateTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.learningRateTrackbar.Value = 20;
            this.learningRateTrackbar.Scroll += new System.EventHandler(this.learningRateTrackbar_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Learning Rate";
            // 
            // learningRate
            // 
            this.learningRate.AutoSize = true;
            this.learningRate.Location = new System.Drawing.Point(192, 392);
            this.learningRate.Name = "learningRate";
            this.learningRate.Size = new System.Drawing.Size(13, 15);
            this.learningRate.TabIndex = 17;
            this.learningRate.Text = "0";
            // 
            // randCharImageBtn
            // 
            this.randCharImageBtn.Location = new System.Drawing.Point(141, 273);
            this.randCharImageBtn.Name = "randCharImageBtn";
            this.randCharImageBtn.Size = new System.Drawing.Size(121, 34);
            this.randCharImageBtn.TabIndex = 18;
            this.randCharImageBtn.Text = "Rand Char Image";
            this.randCharImageBtn.UseVisualStyleBackColor = true;
            this.randCharImageBtn.Click += new System.EventHandler(this.randCharImageBtn_Click);
            // 
            // stopTraining
            // 
            this.stopTraining.Location = new System.Drawing.Point(21, 520);
            this.stopTraining.Name = "stopTraining";
            this.stopTraining.Size = new System.Drawing.Size(239, 32);
            this.stopTraining.TabIndex = 20;
            this.stopTraining.Text = "Stop training";
            this.stopTraining.UseVisualStyleBackColor = true;
            this.stopTraining.Click += new System.EventHandler(this.stopTraining_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(279, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Training Logs";
            // 
            // epochsLabel
            // 
            this.epochsLabel.AutoSize = true;
            this.epochsLabel.Location = new System.Drawing.Point(409, 332);
            this.epochsLabel.Name = "epochsLabel";
            this.epochsLabel.Size = new System.Drawing.Size(51, 15);
            this.epochsLabel.TabIndex = 22;
            this.epochsLabel.Text = "Epochs: ";
            // 
            // loadDataSetBtn
            // 
            this.loadDataSetBtn.Location = new System.Drawing.Point(141, 430);
            this.loadDataSetBtn.Name = "loadDataSetBtn";
            this.loadDataSetBtn.Size = new System.Drawing.Size(119, 34);
            this.loadDataSetBtn.TabIndex = 23;
            this.loadDataSetBtn.Text = "Load data set";
            this.loadDataSetBtn.UseVisualStyleBackColor = true;
            this.loadDataSetBtn.Click += new System.EventHandler(this.loadDataSetBtn_Click);
            // 
            // dataSetPath
            // 
            this.dataSetPath.AutoSize = true;
            this.dataSetPath.ForeColor = System.Drawing.Color.Gray;
            this.dataSetPath.Location = new System.Drawing.Point(23, 434);
            this.dataSetPath.MaximumSize = new System.Drawing.Size(106, 15);
            this.dataSetPath.Name = "dataSetPath";
            this.dataSetPath.Size = new System.Drawing.Size(106, 15);
            this.dataSetPath.TabIndex = 24;
            this.dataSetPath.Text = "No data set loaded";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 610);
            this.Controls.Add(this.dataSetPath);
            this.Controls.Add(this.loadDataSetBtn);
            this.Controls.Add(this.epochsLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stopTraining);
            this.Controls.Add(this.randCharImageBtn);
            this.Controls.Add(this.learningRate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.learningRateTrackbar);
            this.Controls.Add(this.resetPerceptronModel);
            this.Controls.Add(this.dataSetsFeed);
            this.Controls.Add(this.totalErrorLabel);
            this.Controls.Add(this.predictedOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trainBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.epochsInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canvasContainer);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.predictBtn);
            this.Controls.Add(this.clearBtn);
            this.Name = "MainForm";
            this.Text = "Vowel Recognition Perceptron";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button clearBtn;
        private Button predictBtn;
        private PictureBox pictureBox;
        private PictureBox canvasContainer;
        private Label label1;
        private Label label2;
        private TextBox epochsInput;
        private Label label3;
        private Button trainBtn;
        private Label label4;
        private Label predictedOutput;
        private Label totalErrorLabel;
        private ListBox dataSetsFeed;
        private Button resetPerceptronModel;
        private TrackBar learningRateTrackbar;
        private Label label5;
        private Label learningRate;
        private Button randCharImageBtn;
        private Button stopTraining;
        private Label label6;
        private Label epochsLabel;
        private Button loadDataSetBtn;
        private Label dataSetPath;
    }
}