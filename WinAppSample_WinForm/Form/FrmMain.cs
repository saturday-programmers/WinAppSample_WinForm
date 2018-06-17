using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinAppSample_WinForm.Business;
using WinAppSample_WinForm.Service;


namespace WinAppSample_WinForm.Applications
{
	/// <summary>
	/// メイン画面クラス
	/// </summary>
	public partial class FrmMain : Form
	{
		#region enums
		public enum OtherCalcPattern
		{
			Power,
			Sin
		}
		#endregion


		#region constants
		private const string AdditionSign = "＋";
		private const string SubtractionSign = "－";
		private const string MultiplicationSign = "×";
		private const string DivisionSign = "÷";
		private const string PowerSign = "^";
		private const int ValueTxtMaxLength = 7;

		private const string NotNumericErrorMessage = "数値を入力して下さい";
		#endregion


		#region private fields
		private BizMain biz = new BizMain();
		private List<TextBox> valueTextBoxes;
		#endregion


		#region constructors
		/// <summary>
		/// デフォルトコントラクタ
		/// </summary>
		public FrmMain()
		{
			InitializeComponent();
		}
		#endregion


		#region event handlers
		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Text = this.GetType().Assembly.FullName;
			this.txtValue1.ImeMode = ImeMode.Disable;
			this.txtValue2.ImeMode = ImeMode.Disable;
			this.txtValue1.MaxLength = ValueTxtMaxLength;
			this.txtValue2.MaxLength = ValueTxtMaxLength;
			this.valueTextBoxes = new List<TextBox>(new TextBox[] { this.txtValue1, this.txtValue2 });

			var otherCalcPatternList = Enum.GetValues(typeof(OtherCalcPattern)).OfType<OtherCalcPattern>().Select(x => x.Name()).ToList();
			this.cmbOtherCalcPattern.DataSource = otherCalcPatternList;

			this.Initialize();
		}

		private void btnCalc_Click(object sender, EventArgs e)
		{
			var values = this.valueTextBoxes.ConvertAll<float>(x => x.Text.Length > 0 ? float.Parse(x.Text) : 0);

			float result = 0;
			if (this.rbtnAddition.Checked)
			{
				result = biz.Calculate(BizMain.CalculateType.Addition, values[0], values[1]);
			} else if (this.rbtnOther.Checked)
			{
				switch ((OtherCalcPattern)this.cmbOtherCalcPattern.SelectedIndex)
				{
					case OtherCalcPattern.Power:
						result = biz.Calculate(BizMain.CalculateType.Power, values[0], values[1]);
						break;
				}
			}

			this.lblResult.Text = result.ToString();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.Initialize();
		}

		private void rbtnCalcPattern_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rbtn = (RadioButton)sender;
			if (!rbtn.Checked) return;

			this.cmbOtherCalcPattern.Enabled = this.rbtnOther.Checked;

			switch (rbtn.Name)
			{
				case nameof(this.rbtnAddition):
					this.lblCalcSign1.Text = string.Empty;
					this.lblCalcSign2.Text = AdditionSign;
					break;
				case nameof(this.rbtnSubtraction):
					this.lblCalcSign1.Text = string.Empty;
					this.lblCalcSign2.Text = SubtractionSign;
					break;
				case nameof(this.rbtnMultiplication):
					this.lblCalcSign1.Text = string.Empty;
					this.lblCalcSign2.Text = MultiplicationSign;
					break;
				case nameof(this.rbtnDivision):
					this.lblCalcSign1.Text = string.Empty;
					this.lblCalcSign2.Text = DivisionSign;
					break;
				case nameof(this.rbtnOther):
					this.OnOtherCalcPatternSelected();
					break;
			}

			this.lblResult.Text = string.Empty;
		}

		private void cmbOtherCalcPattern_SelectedIndexChanged(object sender, EventArgs e)
		{
			var cmb = (ComboBox)sender;
			if (cmb.SelectedIndex == -1) return;

			var otherCalcPattern = (OtherCalcPattern)(cmb.SelectedIndex);
			switch (otherCalcPattern)
			{
				case OtherCalcPattern.Power:
					this.lblCalcSign1.Text = string.Empty;
					this.lblCalcSign2.Text = PowerSign;
					break;
			}

			this.lblResult.Text = string.Empty;
		}


		private void txtValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			TextBox txt = (TextBox)sender;
			if (txt.Text.Length == 0 || float.TryParse(txt.Text, out var shortValue))
			{
				this.errorProvider.SetError(txt, string.Empty);
			}
			else
			{
				this.errorProvider.SetError(txt, NotNumericErrorMessage);
			}

			var textBoxes = new List<TextBox>(new TextBox[] { this.txtValue1, this.txtValue2 });
			this.btnCalc.Enabled = textBoxes.TrueForAll(x => x.Text.Length > 0 && this.errorProvider.GetError(x) == string.Empty);
		}
		#endregion


		#region private methods
		private void Initialize()
		{
			this.cmbOtherCalcPattern.SelectedIndex = -1;
			this.rbtnAddition.Checked = true;
			this.txtValue1.Text = string.Empty;
			this.txtValue2.Text = string.Empty;
			this.lblResult.Text = string.Empty;
			this.btnCalc.Enabled = false;
		}

		private void OnOtherCalcPatternSelected()
		{

		}
		#endregion

	}
}
