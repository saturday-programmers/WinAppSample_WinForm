namespace WinAppSample_WinForm.Presentation
{
	partial class FrmMain
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.txtValue1 = new System.Windows.Forms.TextBox();
			this.lblCalcSign2 = new System.Windows.Forms.Label();
			this.txtValue2 = new System.Windows.Forms.TextBox();
			this.rbtnAddition = new System.Windows.Forms.RadioButton();
			this.rbtnSubtraction = new System.Windows.Forms.RadioButton();
			this.rbtnMultiplication = new System.Windows.Forms.RadioButton();
			this.rbtnDivision = new System.Windows.Forms.RadioButton();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.cmbOtherCalcPattern = new System.Windows.Forms.ComboBox();
			this.rbtnOther = new System.Windows.Forms.RadioButton();
			this.btnCalc = new System.Windows.Forms.Button();
			this.lblEqual = new System.Windows.Forms.Label();
			this.lblResult = new System.Windows.Forms.Label();
			this.btnClear = new System.Windows.Forms.Button();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.lblCalcSign1 = new System.Windows.Forms.Label();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtValue1
			// 
			this.txtValue1.Location = new System.Drawing.Point(71, 191);
			this.txtValue1.Name = "txtValue1";
			this.txtValue1.Size = new System.Drawing.Size(80, 19);
			this.txtValue1.TabIndex = 0;
			this.txtValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtValue1.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
			this.txtValue1.Validating += new System.ComponentModel.CancelEventHandler(this.txtValue_Validating);
			// 
			// lblCalcSign2
			// 
			this.lblCalcSign2.AutoSize = true;
			this.lblCalcSign2.Location = new System.Drawing.Point(174, 194);
			this.lblCalcSign2.Name = "lblCalcSign2";
			this.lblCalcSign2.Size = new System.Drawing.Size(11, 12);
			this.lblCalcSign2.TabIndex = 1;
			this.lblCalcSign2.Text = "+";
			this.lblCalcSign2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtValue2
			// 
			this.txtValue2.Location = new System.Drawing.Point(208, 191);
			this.txtValue2.Name = "txtValue2";
			this.txtValue2.Size = new System.Drawing.Size(80, 19);
			this.txtValue2.TabIndex = 2;
			this.txtValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtValue2.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
			this.txtValue2.Validating += new System.ComponentModel.CancelEventHandler(this.txtValue_Validating);
			// 
			// rbtnAddition
			// 
			this.rbtnAddition.AutoSize = true;
			this.rbtnAddition.Location = new System.Drawing.Point(43, 35);
			this.rbtnAddition.Name = "rbtnAddition";
			this.rbtnAddition.Size = new System.Drawing.Size(47, 16);
			this.rbtnAddition.TabIndex = 3;
			this.rbtnAddition.TabStop = true;
			this.rbtnAddition.Text = "加算";
			this.rbtnAddition.UseVisualStyleBackColor = true;
			this.rbtnAddition.CheckedChanged += new System.EventHandler(this.rbtnCalcPattern_CheckedChanged);
			// 
			// rbtnSubtraction
			// 
			this.rbtnSubtraction.AutoSize = true;
			this.rbtnSubtraction.Location = new System.Drawing.Point(154, 35);
			this.rbtnSubtraction.Name = "rbtnSubtraction";
			this.rbtnSubtraction.Size = new System.Drawing.Size(47, 16);
			this.rbtnSubtraction.TabIndex = 4;
			this.rbtnSubtraction.TabStop = true;
			this.rbtnSubtraction.Text = "減算";
			this.rbtnSubtraction.UseVisualStyleBackColor = true;
			this.rbtnSubtraction.CheckedChanged += new System.EventHandler(this.rbtnCalcPattern_CheckedChanged);
			// 
			// rbtnMultiplication
			// 
			this.rbtnMultiplication.AutoSize = true;
			this.rbtnMultiplication.Location = new System.Drawing.Point(265, 35);
			this.rbtnMultiplication.Name = "rbtnMultiplication";
			this.rbtnMultiplication.Size = new System.Drawing.Size(47, 16);
			this.rbtnMultiplication.TabIndex = 5;
			this.rbtnMultiplication.TabStop = true;
			this.rbtnMultiplication.Text = "乗算";
			this.rbtnMultiplication.UseVisualStyleBackColor = true;
			this.rbtnMultiplication.CheckedChanged += new System.EventHandler(this.rbtnCalcPattern_CheckedChanged);
			// 
			// rbtnDivision
			// 
			this.rbtnDivision.AutoSize = true;
			this.rbtnDivision.Location = new System.Drawing.Point(376, 35);
			this.rbtnDivision.Name = "rbtnDivision";
			this.rbtnDivision.Size = new System.Drawing.Size(47, 16);
			this.rbtnDivision.TabIndex = 6;
			this.rbtnDivision.TabStop = true;
			this.rbtnDivision.Text = "除算";
			this.rbtnDivision.UseVisualStyleBackColor = true;
			this.rbtnDivision.CheckedChanged += new System.EventHandler(this.rbtnCalcPattern_CheckedChanged);
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.cmbOtherCalcPattern);
			this.groupBox.Controls.Add(this.rbtnOther);
			this.groupBox.Controls.Add(this.rbtnAddition);
			this.groupBox.Controls.Add(this.rbtnDivision);
			this.groupBox.Controls.Add(this.rbtnSubtraction);
			this.groupBox.Controls.Add(this.rbtnMultiplication);
			this.groupBox.Location = new System.Drawing.Point(44, 54);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(684, 84);
			this.groupBox.TabIndex = 7;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "計算方法";
			// 
			// cmbOtherCalcPattern
			// 
			this.cmbOtherCalcPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOtherCalcPattern.FormattingEnabled = true;
			this.cmbOtherCalcPattern.Location = new System.Drawing.Point(550, 34);
			this.cmbOtherCalcPattern.Name = "cmbOtherCalcPattern";
			this.cmbOtherCalcPattern.Size = new System.Drawing.Size(112, 20);
			this.cmbOtherCalcPattern.TabIndex = 8;
			this.cmbOtherCalcPattern.SelectedIndexChanged += new System.EventHandler(this.cmbOtherCalcPattern_SelectedIndexChanged);
			// 
			// rbtnOther
			// 
			this.rbtnOther.AutoSize = true;
			this.rbtnOther.Location = new System.Drawing.Point(487, 35);
			this.rbtnOther.Name = "rbtnOther";
			this.rbtnOther.Size = new System.Drawing.Size(54, 16);
			this.rbtnOther.TabIndex = 7;
			this.rbtnOther.TabStop = true;
			this.rbtnOther.Text = "その他";
			this.rbtnOther.UseVisualStyleBackColor = true;
			this.rbtnOther.CheckedChanged += new System.EventHandler(this.rbtnCalcPattern_CheckedChanged);
			// 
			// btnCalc
			// 
			this.btnCalc.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnCalc.Location = new System.Drawing.Point(460, 175);
			this.btnCalc.Name = "btnCalc";
			this.btnCalc.Size = new System.Drawing.Size(86, 53);
			this.btnCalc.TabIndex = 8;
			this.btnCalc.Text = "計算";
			this.btnCalc.UseVisualStyleBackColor = true;
			this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
			// 
			// lblEqual
			// 
			this.lblEqual.AutoSize = true;
			this.lblEqual.Location = new System.Drawing.Point(311, 195);
			this.lblEqual.Name = "lblEqual";
			this.lblEqual.Size = new System.Drawing.Size(11, 12);
			this.lblEqual.TabIndex = 9;
			this.lblEqual.Text = "=";
			this.lblEqual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblResult
			// 
			this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblResult.Location = new System.Drawing.Point(345, 191);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(90, 19);
			this.lblResult.TabIndex = 10;
			this.lblResult.Text = "0";
			this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnClear
			// 
			this.btnClear.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnClear.Location = new System.Drawing.Point(642, 175);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(86, 53);
			this.btnClear.TabIndex = 11;
			this.btnClear.Text = "クリア";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// lblCalcSign1
			// 
			this.lblCalcSign1.AutoSize = true;
			this.lblCalcSign1.Location = new System.Drawing.Point(42, 194);
			this.lblCalcSign1.Name = "lblCalcSign1";
			this.lblCalcSign1.Size = new System.Drawing.Size(11, 12);
			this.lblCalcSign1.TabIndex = 12;
			this.lblCalcSign1.Text = "+";
			this.lblCalcSign1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 264);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(752, 22);
			this.statusStrip.TabIndex = 13;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnCancel.Location = new System.Drawing.Point(551, 175);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(86, 53);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "中止";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(752, 286);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.lblCalcSign1);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.lblEqual);
			this.Controls.Add(this.btnCalc);
			this.Controls.Add(this.groupBox);
			this.Controls.Add(this.txtValue2);
			this.Controls.Add(this.lblCalcSign2);
			this.Controls.Add(this.txtValue1);
			this.Name = "FrmMain";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtValue1;
		private System.Windows.Forms.Label lblCalcSign2;
		private System.Windows.Forms.TextBox txtValue2;
		private System.Windows.Forms.RadioButton rbtnAddition;
		private System.Windows.Forms.RadioButton rbtnSubtraction;
		private System.Windows.Forms.RadioButton rbtnMultiplication;
		private System.Windows.Forms.RadioButton rbtnDivision;
		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.Button btnCalc;
		private System.Windows.Forms.Label lblEqual;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Label lblCalcSign1;
		private System.Windows.Forms.ComboBox cmbOtherCalcPattern;
		private System.Windows.Forms.RadioButton rbtnOther;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.Button btnCancel;
	}
}

