namespace MovingImage
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Lift_Interior = new System.Windows.Forms.PictureBox();
            this.TimerUp = new System.Windows.Forms.Timer(this.components);
            this.TimerDown = new System.Windows.Forms.Timer(this.components);
            this.TimerOpen = new System.Windows.Forms.Timer(this.components);
            this.TimerClose = new System.Windows.Forms.Timer(this.components);
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.Ground_Floor_Door = new System.Windows.Forms.PictureBox();
            this.First_Floor_Door = new System.Windows.Forms.PictureBox();
            this.Timer_Close_First_Floor = new System.Windows.Forms.Timer(this.components);
            this.Timer_Close_Ground_Floor = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dgvLogData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Lift_Interior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ground_Floor_Door)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.First_Floor_Door)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogData)).BeginInit();
            this.SuspendLayout();
            // 
            // Lift_Interior
            // 
            this.Lift_Interior.BackColor = System.Drawing.Color.Transparent;
            this.Lift_Interior.Image = ((System.Drawing.Image)(resources.GetObject("Lift_Interior.Image")));
            this.Lift_Interior.Location = new System.Drawing.Point(229, 696);
            this.Lift_Interior.Margin = new System.Windows.Forms.Padding(4);
            this.Lift_Interior.Name = "Lift_Interior";
            this.Lift_Interior.Size = new System.Drawing.Size(210, 371);
            this.Lift_Interior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Lift_Interior.TabIndex = 0;
            this.Lift_Interior.TabStop = false;
            // 
            // TimerUp
            // 
            this.TimerUp.Tick += new System.EventHandler(this.TimerUp_Tick);
            // 
            // TimerDown
            // 
            this.TimerDown.Tick += new System.EventHandler(this.TimerDown_Tick);
            // 
            // TimerOpen
            // 
            this.TimerOpen.Tick += new System.EventHandler(this.TimerOpen_Tick);
            // 
            // TimerClose
            // 
            this.TimerClose.Tick += new System.EventHandler(this.TimerClose_Tick);
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.Color.Gray;
            this.buttonUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonUp.Image")));
            this.buttonUp.Location = new System.Drawing.Point(778, 212);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(145, 141);
            this.buttonUp.TabIndex = 1;
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.UpButtonClick);
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.Color.Gray;
            this.buttonDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonDown.Image")));
            this.buttonDown.Location = new System.Drawing.Point(778, 370);
            this.buttonDown.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(145, 144);
            this.buttonDown.TabIndex = 2;
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.DownButtonClick);
            // 
            // buttonOpen
            // 
            this.buttonOpen.BackColor = System.Drawing.Color.Gray;
            this.buttonOpen.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpen.Image")));
            this.buttonOpen.Location = new System.Drawing.Point(685, 578);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(155, 132);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.OpenButtonClick);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Gray;
            this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
            this.buttonClose.Location = new System.Drawing.Point(869, 578);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(151, 132);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // Ground_Floor_Door
            // 
            this.Ground_Floor_Door.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Ground_Floor_Door.Image = ((System.Drawing.Image)(resources.GetObject("Ground_Floor_Door.Image")));
            this.Ground_Floor_Door.Location = new System.Drawing.Point(229, 696);
            this.Ground_Floor_Door.Margin = new System.Windows.Forms.Padding(2);
            this.Ground_Floor_Door.Name = "Ground_Floor_Door";
            this.Ground_Floor_Door.Size = new System.Drawing.Size(210, 371);
            this.Ground_Floor_Door.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Ground_Floor_Door.TabIndex = 6;
            this.Ground_Floor_Door.TabStop = false;
            // 
            // First_Floor_Door
            // 
            this.First_Floor_Door.Image = ((System.Drawing.Image)(resources.GetObject("First_Floor_Door.Image")));
            this.First_Floor_Door.Location = new System.Drawing.Point(229, 102);
            this.First_Floor_Door.Margin = new System.Windows.Forms.Padding(2);
            this.First_Floor_Door.Name = "First_Floor_Door";
            this.First_Floor_Door.Size = new System.Drawing.Size(210, 374);
            this.First_Floor_Door.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.First_Floor_Door.TabIndex = 7;
            this.First_Floor_Door.TabStop = false;
            // 
            // Timer_Close_First_Floor
            // 
            this.Timer_Close_First_Floor.Tick += new System.EventHandler(this.Timer_Close_1F_Tick);
            // 
            // Timer_Close_Ground_Floor
            // 
            this.Timer_Close_Ground_Floor.Tick += new System.EventHandler(this.Timer_Close_Ground_Floor_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(178, 643);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(313, 459);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(178, 49);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(313, 454);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Gray;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(661, 152);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(392, 619);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // dgvLogData
            // 
            this.dgvLogData.AllowUserToAddRows = false;
            this.dgvLogData.AllowUserToDeleteRows = false;
            this.dgvLogData.AllowUserToOrderColumns = true;
            this.dgvLogData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogData.Location = new System.Drawing.Point(1097, 152);
            this.dgvLogData.MultiSelect = false;
            this.dgvLogData.Name = "dgvLogData";
            this.dgvLogData.ReadOnly = true;
            this.dgvLogData.RowHeadersWidth = 62;
            this.dgvLogData.RowTemplate.Height = 33;
            this.dgvLogData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogData.Size = new System.Drawing.Size(1219, 619);
            this.dgvLogData.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2345, 1536);
            this.Controls.Add(this.dgvLogData);
            this.Controls.Add(this.First_Floor_Door);
            this.Controls.Add(this.Ground_Floor_Door);
            this.Controls.Add(this.Lift_Interior);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Lift_Form";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.Lift_Interior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ground_Floor_Door)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.First_Floor_Door)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox Lift_Interior;
        private System.Windows.Forms.Timer TimerUp;
        private System.Windows.Forms.Timer TimerDown;
        private System.Windows.Forms.Timer TimerOpen;
        private System.Windows.Forms.Timer TimerClose;
        private Button buttonUp;
        private Button buttonDown;
        private Button buttonOpen;
        private Button buttonClose;
        private PictureBox Ground_Floor_Door;
        private PictureBox First_Floor_Door;
        private System.Windows.Forms.Timer Timer_Close_First_Floor;
        private System.Windows.Forms.Timer Timer_Close_Ground_Floor;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private DataGridView dgvLogData;
    }
}