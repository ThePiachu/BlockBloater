namespace BlockchainBloater
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
			this.RPCUsername = new System.Windows.Forms.TextBox();
			this.RPCPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Amount = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.Printout = new System.Windows.Forms.TextBox();
			this.RPCPort = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Run = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.Iterations = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.WalletPassword = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.Amount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Iterations)).BeginInit();
			this.SuspendLayout();
			// 
			// RPCUsername
			// 
			this.RPCUsername.Location = new System.Drawing.Point(95, 97);
			this.RPCUsername.Name = "RPCUsername";
			this.RPCUsername.Size = new System.Drawing.Size(120, 20);
			this.RPCUsername.TabIndex = 0;
			this.RPCUsername.Text = "user";
			// 
			// RPCPassword
			// 
			this.RPCPassword.Location = new System.Drawing.Point(95, 123);
			this.RPCPassword.Name = "RPCPassword";
			this.RPCPassword.Size = new System.Drawing.Size(120, 20);
			this.RPCPassword.TabIndex = 1;
			this.RPCPassword.Text = "pass";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 100);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "RPC Username";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "RPC Password";
			// 
			// Amount
			// 
			this.Amount.DecimalPlaces = 8;
			this.Amount.Location = new System.Drawing.Point(95, 198);
			this.Amount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.Amount.Name = "Amount";
			this.Amount.Size = new System.Drawing.Size(120, 20);
			this.Amount.TabIndex = 5;
			this.Amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 200);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Coins to use";
			// 
			// Printout
			// 
			this.Printout.Location = new System.Drawing.Point(7, 250);
			this.Printout.Multiline = true;
			this.Printout.Name = "Printout";
			this.Printout.Size = new System.Drawing.Size(208, 67);
			this.Printout.TabIndex = 7;
			// 
			// RPCPort
			// 
			this.RPCPort.Location = new System.Drawing.Point(95, 149);
			this.RPCPort.Name = "RPCPort";
			this.RPCPort.Size = new System.Drawing.Size(120, 20);
			this.RPCPort.TabIndex = 8;
			this.RPCPort.Text = "18332";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(38, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "RPC Port";
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(136, 38);
			this.Run.Name = "Run";
			this.Run.Size = new System.Drawing.Size(75, 23);
			this.Run.TabIndex = 10;
			this.Run.Text = "Run";
			this.Run.UseVisualStyleBackColor = true;
			this.Run.Click += new System.EventHandler(this.Run_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label5.Location = new System.Drawing.Point(12, 14);
			this.label5.MaximumSize = new System.Drawing.Size(120, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(118, 74);
			this.label5.TabIndex = 11;
			this.label5.Text = "Block Bloater";
			// 
			// Iterations
			// 
			this.Iterations.Location = new System.Drawing.Point(95, 224);
			this.Iterations.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.Iterations.Name = "Iterations";
			this.Iterations.Size = new System.Drawing.Size(120, 20);
			this.Iterations.TabIndex = 12;
			this.Iterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(39, 226);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Iterations";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(4, 175);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Wallet password";
			// 
			// WalletPassword
			// 
			this.WalletPassword.Location = new System.Drawing.Point(95, 172);
			this.WalletPassword.Name = "WalletPassword";
			this.WalletPassword.Size = new System.Drawing.Size(120, 20);
			this.WalletPassword.TabIndex = 14;
			this.WalletPassword.Text = "password";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(224, 323);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.WalletPassword);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.Iterations);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.Run);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.RPCPort);
			this.Controls.Add(this.Printout);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Amount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RPCPassword);
			this.Controls.Add(this.RPCUsername);
			this.Name = "Form1";
			this.Text = "Block Bloater";
			((System.ComponentModel.ISupportInitialize)(this.Amount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Iterations)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox RPCUsername;
		private System.Windows.Forms.TextBox RPCPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown Amount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Printout;
		private System.Windows.Forms.TextBox RPCPort;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button Run;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown Iterations;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox WalletPassword;
	}
}

