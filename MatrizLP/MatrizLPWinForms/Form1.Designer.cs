namespace MatrizLPWinForms
{
    partial class frmCalculo
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
            this.lblOrdem = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblResposta = new System.Windows.Forms.Label();
            this.nudOrdem = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrdem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrdem
            // 
            this.lblOrdem.AutoSize = true;
            this.lblOrdem.Location = new System.Drawing.Point(9, 9);
            this.lblOrdem.Name = "lblOrdem";
            this.lblOrdem.Size = new System.Drawing.Size(88, 13);
            this.lblOrdem.TabIndex = 0;
            this.lblOrdem.Text = "Nível de cálculo:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(49, 51);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblResposta
            // 
            this.lblResposta.AutoSize = true;
            this.lblResposta.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblResposta.Location = new System.Drawing.Point(12, 112);
            this.lblResposta.Name = "lblResposta";
            this.lblResposta.Size = new System.Drawing.Size(13, 13);
            this.lblResposta.TabIndex = 3;
            this.lblResposta.Text = "0";
            // 
            // nudOrdem
            // 
            this.nudOrdem.Location = new System.Drawing.Point(49, 25);
            this.nudOrdem.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.nudOrdem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOrdem.Name = "nudOrdem";
            this.nudOrdem.Size = new System.Drawing.Size(75, 20);
            this.nudOrdem.TabIndex = 4;
            this.nudOrdem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOrdem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudOrdem_KeyPress);
            // 
            // frmCalculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 150);
            this.Controls.Add(this.nudOrdem);
            this.Controls.Add(this.lblResposta);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblOrdem);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalculo";
            this.ShowIcon = false;
            this.Text = "Determinante";
            ((System.ComponentModel.ISupportInitialize)(this.nudOrdem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrdem;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblResposta;
        private System.Windows.Forms.NumericUpDown nudOrdem;
    }
}

