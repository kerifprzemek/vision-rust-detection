namespace SW_T8_9_10
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_From_File_PB1 = new System.Windows.Forms.Button();
            this.button_Browse_Files_PB1 = new System.Windows.Forms.Button();
            this.textBox_Image_Path_PB1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_procent_pow_zardzewialej = new System.Windows.Forms.Label();
            this.label_liczba_ognisk_rdzy = new System.Windows.Forms.Label();
            this.button_analizuj_powierzchnie = new System.Windows.Forms.Button();
            this.button_Czysc = new System.Windows.Forms.Button();
            this.label_procent_plam = new System.Windows.Forms.Label();
            this.numericUpDown_numer_plamy = new System.Windows.Forms.NumericUpDown();
            this.button_pokaz_plame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numer_plamy)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 112);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 295);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button_From_File_PB1
            // 
            this.button_From_File_PB1.Location = new System.Drawing.Point(0, 34);
            this.button_From_File_PB1.Margin = new System.Windows.Forms.Padding(4);
            this.button_From_File_PB1.Name = "button_From_File_PB1";
            this.button_From_File_PB1.Size = new System.Drawing.Size(64, 54);
            this.button_From_File_PB1.TabIndex = 51;
            this.button_From_File_PB1.Text = "Z pliku";
            this.button_From_File_PB1.UseVisualStyleBackColor = true;
            this.button_From_File_PB1.Click += new System.EventHandler(this.button_From_File_PB1_Click);
            // 
            // button_Browse_Files_PB1
            // 
            this.button_Browse_Files_PB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Browse_Files_PB1.Location = new System.Drawing.Point(389, 2);
            this.button_Browse_Files_PB1.Margin = new System.Windows.Forms.Padding(4);
            this.button_Browse_Files_PB1.Name = "button_Browse_Files_PB1";
            this.button_Browse_Files_PB1.Size = new System.Drawing.Size(37, 25);
            this.button_Browse_Files_PB1.TabIndex = 54;
            this.button_Browse_Files_PB1.Text = "...";
            this.button_Browse_Files_PB1.UseVisualStyleBackColor = true;
            this.button_Browse_Files_PB1.Click += new System.EventHandler(this.button_Browse_Files_PB1_Click);
            // 
            // textBox_Image_Path_PB1
            // 
            this.textBox_Image_Path_PB1.Location = new System.Drawing.Point(59, 2);
            this.textBox_Image_Path_PB1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Image_Path_PB1.Name = "textBox_Image_Path_PB1";
            this.textBox_Image_Path_PB1.Size = new System.Drawing.Size(328, 22);
            this.textBox_Image_Path_PB1.TabIndex = 53;
            this.textBox_Image_Path_PB1.Text = "C:\\Users\\kerif\\Documents\\Codes\\Systemy Wizyjne\\SystemyWizyjne\\fig1.jpg";
            this.textBox_Image_Path_PB1.TextChanged += new System.EventHandler(this.textBox_Image_Path_PB1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 52;
            this.label1.Text = "Ścieżka:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_pokaz_plame);
            this.groupBox1.Controls.Add(this.numericUpDown_numer_plamy);
            this.groupBox1.Controls.Add(this.label_procent_plam);
            this.groupBox1.Controls.Add(this.label_procent_pow_zardzewialej);
            this.groupBox1.Controls.Add(this.label_liczba_ognisk_rdzy);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(435, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(355, 405);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ZEBRANE DANE O ZARDZEWIENIU ELEMENTU";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label_procent_pow_zardzewialej
            // 
            this.label_procent_pow_zardzewialej.AutoSize = true;
            this.label_procent_pow_zardzewialej.Location = new System.Drawing.Point(8, 110);
            this.label_procent_pow_zardzewialej.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_procent_pow_zardzewialej.Name = "label_procent_pow_zardzewialej";
            this.label_procent_pow_zardzewialej.Size = new System.Drawing.Size(297, 17);
            this.label_procent_pow_zardzewialej.TabIndex = 78;
            this.label_procent_pow_zardzewialej.Text = "Procentowa wartość powierzchni zardzewiałej:";
            // 
            // label_liczba_ognisk_rdzy
            // 
            this.label_liczba_ognisk_rdzy.AutoSize = true;
            this.label_liczba_ognisk_rdzy.Location = new System.Drawing.Point(8, 51);
            this.label_liczba_ognisk_rdzy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_liczba_ognisk_rdzy.Name = "label_liczba_ognisk_rdzy";
            this.label_liczba_ognisk_rdzy.Size = new System.Drawing.Size(129, 17);
            this.label_liczba_ognisk_rdzy.TabIndex = 77;
            this.label_liczba_ognisk_rdzy.Text = "Liczba ognisk rdzy:";
            // 
            // button_analizuj_powierzchnie
            // 
            this.button_analizuj_powierzchnie.Location = new System.Drawing.Point(144, 33);
            this.button_analizuj_powierzchnie.Margin = new System.Windows.Forms.Padding(4);
            this.button_analizuj_powierzchnie.Name = "button_analizuj_powierzchnie";
            this.button_analizuj_powierzchnie.Size = new System.Drawing.Size(177, 55);
            this.button_analizuj_powierzchnie.TabIndex = 71;
            this.button_analizuj_powierzchnie.Text = "Analizuj powierzchnę";
            this.button_analizuj_powierzchnie.UseVisualStyleBackColor = true;
            this.button_analizuj_powierzchnie.Click += new System.EventHandler(this.button_analizuj_powierzchne_Click);
            // 
            // button_Czysc
            // 
            this.button_Czysc.Location = new System.Drawing.Point(72, 34);
            this.button_Czysc.Margin = new System.Windows.Forms.Padding(4);
            this.button_Czysc.Name = "button_Czysc";
            this.button_Czysc.Size = new System.Drawing.Size(64, 54);
            this.button_Czysc.TabIndex = 81;
            this.button_Czysc.Text = "Czyść";
            this.button_Czysc.UseVisualStyleBackColor = true;
            this.button_Czysc.Click += new System.EventHandler(this.button_Czysc_Click);
            // 
            // label_procent_plam
            // 
            this.label_procent_plam.AutoSize = true;
            this.label_procent_plam.Location = new System.Drawing.Point(8, 223);
            this.label_procent_plam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_procent_plam.Name = "label_procent_plam";
            this.label_procent_plam.Size = new System.Drawing.Size(172, 17);
            this.label_procent_plam.TabIndex = 79;
            this.label_procent_plam.Text = "Procentowa wartość plam:";
            // 
            // numericUpDown_numer_plamy
            // 
            this.numericUpDown_numer_plamy.Location = new System.Drawing.Point(152, 175);
            this.numericUpDown_numer_plamy.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_numer_plamy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_numer_plamy.Name = "numericUpDown_numer_plamy";
            this.numericUpDown_numer_plamy.Size = new System.Drawing.Size(80, 22);
            this.numericUpDown_numer_plamy.TabIndex = 81;
            this.numericUpDown_numer_plamy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_pokaz_plame
            // 
            this.button_pokaz_plame.Location = new System.Drawing.Point(11, 171);
            this.button_pokaz_plame.Margin = new System.Windows.Forms.Padding(4);
            this.button_pokaz_plame.Name = "button_pokaz_plame";
            this.button_pokaz_plame.Size = new System.Drawing.Size(133, 28);
            this.button_pokaz_plame.TabIndex = 82;
            this.button_pokaz_plame.Text = "Pokaż plamę nr:";
            this.button_pokaz_plame.UseVisualStyleBackColor = true;
            this.button_pokaz_plame.Click += new System.EventHandler(this.button_pokaz_plame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(840, 451);
            this.Controls.Add(this.button_Czysc);
            this.Controls.Add(this.button_analizuj_powierzchnie);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Browse_Files_PB1);
            this.Controls.Add(this.textBox_Image_Path_PB1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_From_File_PB1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Wykrywanie plam rdzy";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numer_plamy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_From_File_PB1;
        private System.Windows.Forms.Button button_Browse_Files_PB1;
        private System.Windows.Forms.TextBox textBox_Image_Path_PB1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_analizuj_powierzchnie;
        private System.Windows.Forms.Label label_liczba_ognisk_rdzy;
        private System.Windows.Forms.Button button_Czysc;
        private System.Windows.Forms.Label label_procent_pow_zardzewialej;
        private System.Windows.Forms.Label label_procent_plam;
        private System.Windows.Forms.Button button_pokaz_plame;
        private System.Windows.Forms.NumericUpDown numericUpDown_numer_plamy;
    }
}

