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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dgvLogData = new System.Windows.Forms.DataGridView();
            this.buttonShowLogs = new System.Windows.Forms.Button();
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.buttonHideLogs = new System.Windows.Forms.Button();
            this.DisplayBox = new System.Windows.Forms.PictureBox();
            this.DisplayBox_First_Floor = new System.Windows.Forms.PictureBox();
            this.DisplayBox_Ground_Floor = new System.Windows.Forms.PictureBox();
            this.Requesting_Up = new System.Windows.Forms.Button();
            this.Requesting_Down = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Timer_Requesting_Up = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Lift_Interior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ground_Floor_Door)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.First_Floor_Door)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox_First_Floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox_Ground_Floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // Lift_Interior
            // 
            this.Lift_Interior.BackColor = System.Drawing.Color.Transparent;
            this.Lift_Interior.Image = global::MovingImage.Properties.Resources.Lift;
            this.Lift_Interior.Location = new System.Drawing.Point(310, 1098);
            this.Lift_Interior.Margin = new System.Windows.Forms.Padding(4);
            this.Lift_Interior.Name = "Lift_Interior";
            this.Lift_Interior.Size = new System.Drawing.Size(210, 374);
            this.Lift_Interior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Lift_Interior.TabIndex = 0;
            this.Lift_Interior.TabStop = false;
            // 
            // TimerUp
            // 
            this.TimerUp.Interval = 4;
            this.TimerUp.Tick += new System.EventHandler(this.TimerUp_Tick);
            // 
            // TimerDown
            // 
            this.TimerDown.Interval = 4;
            this.TimerDown.Tick += new System.EventHandler(this.TimerDown_Tick);
            // 
            // TimerOpen
            // 
            this.TimerOpen.Interval = 4;
            this.TimerOpen.Tick += new System.EventHandler(this.TimerOpen_Tick);
            // 
            // TimerClose
            // 
            this.TimerClose.Interval = 4;
            this.TimerClose.Tick += new System.EventHandler(this.TimerClose_Tick);
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.Color.Gray;
            this.buttonUp.Image = global::MovingImage.Properties.Resources.Button_up;
            this.buttonUp.Location = new System.Drawing.Point(959, 327);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(145, 144);
            this.buttonUp.TabIndex = 1;
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.UpButtonClick);
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.Color.Gray;
            this.buttonDown.Image = global::MovingImage.Properties.Resources.Button_Down;
            this.buttonDown.Location = new System.Drawing.Point(959, 1034);
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
            this.buttonOpen.Image = global::MovingImage.Properties.Resources.Button_Open;
            this.buttonOpen.Location = new System.Drawing.Point(1053, 1195);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(140, 144);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.OpenButtonClick);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Gray;
            this.buttonClose.Image = global::MovingImage.Properties.Resources.Button_Close;
            this.buttonClose.Location = new System.Drawing.Point(853, 1195);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(145, 144);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // Ground_Floor_Door
            // 
            this.Ground_Floor_Door.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Ground_Floor_Door.Image = global::MovingImage.Properties.Resources.Door;
            this.Ground_Floor_Door.Location = new System.Drawing.Point(310, 1098);
            this.Ground_Floor_Door.Margin = new System.Windows.Forms.Padding(2);
            this.Ground_Floor_Door.Name = "Ground_Floor_Door";
            this.Ground_Floor_Door.Size = new System.Drawing.Size(210, 374);
            this.Ground_Floor_Door.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Ground_Floor_Door.TabIndex = 6;
            this.Ground_Floor_Door.TabStop = false;
            // 
            // First_Floor_Door
            // 
            this.First_Floor_Door.Image = global::MovingImage.Properties.Resources.Door;
            this.First_Floor_Door.Location = new System.Drawing.Point(310, 280);
            this.First_Floor_Door.Margin = new System.Windows.Forms.Padding(2);
            this.First_Floor_Door.Name = "First_Floor_Door";
            this.First_Floor_Door.Size = new System.Drawing.Size(210, 380);
            this.First_Floor_Door.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.First_Floor_Door.TabIndex = 7;
            this.First_Floor_Door.TabStop = false;
            // 
            // Timer_Close_First_Floor
            // 
            this.Timer_Close_First_Floor.Interval = 4;
            this.Timer_Close_First_Floor.Tick += new System.EventHandler(this.Timer_Close_1F_Tick);
            // 
            // Timer_Close_Ground_Floor
            // 
            this.Timer_Close_Ground_Floor.Interval = 4;
            this.Timer_Close_Ground_Floor.Tick += new System.EventHandler(this.Timer_Close_Ground_Floor_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::MovingImage.Properties.Resources.Door_Frame;
            this.pictureBox1.Location = new System.Drawing.Point(255, 1049);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 458);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Gray;
            this.pictureBox3.Image = global::MovingImage.Properties.Resources.Button_BG;
            this.pictureBox3.Location = new System.Drawing.Point(803, 179);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(451, 1241);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // dgvLogData
            // 
            this.dgvLogData.AllowUserToAddRows = false;
            this.dgvLogData.AllowUserToDeleteRows = false;
            this.dgvLogData.AllowUserToResizeColumns = false;
            this.dgvLogData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLogData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLogData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLogData.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvLogData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLogData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLogData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLogData.EnableHeadersVisualStyles = false;
            this.dgvLogData.Location = new System.Drawing.Point(1301, 179);
            this.dgvLogData.MultiSelect = false;
            this.dgvLogData.Name = "dgvLogData";
            this.dgvLogData.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLogData.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgvLogData.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLogData.RowTemplate.Height = 33;
            this.dgvLogData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogData.Size = new System.Drawing.Size(1116, 700);
            this.dgvLogData.TabIndex = 11;
            // 
            // buttonShowLogs
            // 
            this.buttonShowLogs.BackColor = System.Drawing.Color.LightCoral;
            this.buttonShowLogs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonShowLogs.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonShowLogs.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonShowLogs.Location = new System.Drawing.Point(1888, 913);
            this.buttonShowLogs.Name = "buttonShowLogs";
            this.buttonShowLogs.Size = new System.Drawing.Size(156, 74);
            this.buttonShowLogs.TabIndex = 12;
            this.buttonShowLogs.Text = "Show Logs";
            this.buttonShowLogs.UseVisualStyleBackColor = false;
            this.buttonShowLogs.Click += new System.EventHandler(this.buttonShowLogs_Click);
            // 
            // buttonClearLogs
            // 
            this.buttonClearLogs.BackColor = System.Drawing.Color.LightCoral;
            this.buttonClearLogs.Enabled = false;
            this.buttonClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClearLogs.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClearLogs.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonClearLogs.Location = new System.Drawing.Point(2265, 913);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Size = new System.Drawing.Size(152, 74);
            this.buttonClearLogs.TabIndex = 13;
            this.buttonClearLogs.Text = "Clear Logs";
            this.buttonClearLogs.UseVisualStyleBackColor = false;
            this.buttonClearLogs.Click += new System.EventHandler(this.buttonClearLogs_Click);
            // 
            // buttonHideLogs
            // 
            this.buttonHideLogs.BackColor = System.Drawing.Color.LightCoral;
            this.buttonHideLogs.Enabled = false;
            this.buttonHideLogs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHideLogs.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonHideLogs.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonHideLogs.Location = new System.Drawing.Point(2081, 913);
            this.buttonHideLogs.Name = "buttonHideLogs";
            this.buttonHideLogs.Size = new System.Drawing.Size(149, 74);
            this.buttonHideLogs.TabIndex = 14;
            this.buttonHideLogs.Text = "Hide Logs";
            this.buttonHideLogs.UseVisualStyleBackColor = false;
            this.buttonHideLogs.Click += new System.EventHandler(this.buttonHideLogs_Click);
            // 
            // DisplayBox
            // 
            this.DisplayBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DisplayBox.Image = global::MovingImage.Properties.Resources.Ground_Floor;
            this.DisplayBox.Location = new System.Drawing.Point(910, 536);
            this.DisplayBox.Name = "DisplayBox";
            this.DisplayBox.Size = new System.Drawing.Size(253, 451);
            this.DisplayBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.DisplayBox.TabIndex = 15;
            this.DisplayBox.TabStop = false;
            // 
            // DisplayBox_First_Floor
            // 
            this.DisplayBox_First_Floor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DisplayBox_First_Floor.Image = global::MovingImage.Properties.Resources.Ground_Floor_Small;
            this.DisplayBox_First_Floor.Location = new System.Drawing.Point(381, 134);
            this.DisplayBox_First_Floor.Name = "DisplayBox_First_Floor";
            this.DisplayBox_First_Floor.Size = new System.Drawing.Size(80, 89);
            this.DisplayBox_First_Floor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.DisplayBox_First_Floor.TabIndex = 16;
            this.DisplayBox_First_Floor.TabStop = false;
            // 
            // DisplayBox_Ground_Floor
            // 
            this.DisplayBox_Ground_Floor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DisplayBox_Ground_Floor.Image = global::MovingImage.Properties.Resources.Ground_Floor_Small;
            this.DisplayBox_Ground_Floor.Location = new System.Drawing.Point(381, 955);
            this.DisplayBox_Ground_Floor.Name = "DisplayBox_Ground_Floor";
            this.DisplayBox_Ground_Floor.Size = new System.Drawing.Size(80, 89);
            this.DisplayBox_Ground_Floor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.DisplayBox_Ground_Floor.TabIndex = 17;
            this.DisplayBox_Ground_Floor.TabStop = false;
            // 
            // Requesting_Up
            // 
            this.Requesting_Up.Image = global::MovingImage.Properties.Resources.Up;
            this.Requesting_Up.Location = new System.Drawing.Point(586, 1258);
            this.Requesting_Up.Name = "Requesting_Up";
            this.Requesting_Up.Size = new System.Drawing.Size(82, 81);
            this.Requesting_Up.TabIndex = 18;
            this.Requesting_Up.UseVisualStyleBackColor = false;
            this.Requesting_Up.Click += new System.EventHandler(this.Requesting_Up_Click);
            // 
            // Requesting_Down
            // 
            this.Requesting_Down.Image = global::MovingImage.Properties.Resources.Down;
            this.Requesting_Down.Location = new System.Drawing.Point(586, 450);
            this.Requesting_Down.Name = "Requesting_Down";
            this.Requesting_Down.Size = new System.Drawing.Size(82, 83);
            this.Requesting_Down.TabIndex = 19;
            this.Requesting_Down.UseVisualStyleBackColor = true;
            this.Requesting_Down.Click += new System.EventHandler(this.Requesting_Down_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Image = global::MovingImage.Properties.Resources.Door_Frame;
            this.pictureBox4.Location = new System.Drawing.Point(255, 228);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(300, 458);
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::MovingImage.Properties.Resources.Titanium_Textures;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2529, 1552);
            this.Controls.Add(this.Requesting_Down);
            this.Controls.Add(this.Requesting_Up);
            this.Controls.Add(this.DisplayBox_Ground_Floor);
            this.Controls.Add(this.DisplayBox_First_Floor);
            this.Controls.Add(this.DisplayBox);
            this.Controls.Add(this.buttonHideLogs);
            this.Controls.Add(this.buttonClearLogs);
            this.Controls.Add(this.buttonShowLogs);
            this.Controls.Add(this.dgvLogData);
            this.Controls.Add(this.First_Floor_Door);
            this.Controls.Add(this.Ground_Floor_Door);
            this.Controls.Add(this.Lift_Interior);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Lift_Form";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.Lift_Interior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ground_Floor_Door)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.First_Floor_Door)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox_First_Floor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox_Ground_Floor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
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
        private PictureBox pictureBox3;
        private DataGridView dgvLogData;
        private Button buttonShowLogs;
        private Button buttonClearLogs;
        private Button buttonHideLogs;
        private PictureBox DisplayBox;
        private PictureBox DisplayBox_First_Floor;
        private PictureBox DisplayBox_Ground_Floor;
        private Button Requesting_Up;
        private Button Requesting_Down;
        private PictureBox pictureBox4;
        private System.Windows.Forms.Timer Timer_Requesting_Up;
    }
}