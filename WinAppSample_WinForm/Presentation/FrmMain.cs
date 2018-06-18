﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAppSample_WinForm.Business;
using WinAppSample_WinForm.Service;


namespace WinAppSample_WinForm.Presentation
{
	/// <summary>
	/// メイン画面クラス
	/// </summary>
	public partial class FrmMain : Form
	{
		#region constants
		private const string AdditionSign = "＋";
		private const string SubtractionSign = "－";
		private const string MultiplicationSign = "×";
		private const string DivisionSign = "÷";
		private const string PowerSign = "^";
		private const int ValueTxtMaxLength = 7;

		private const string NotNumericErrorMessage = "数値を入力して下さい";
		private const string CalculatingMessage = "計算中です...";
		private const string CofirmCancelingMessage = "実行中の計算処理を停止します。よろしいですか？";
		private const string CancelingCalcMessage = "計算処理を停止します";
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

		#region enums
		public enum OtherCalcPattern
		{
			Power,
			Sin
		}
		#endregion

		#region properties
		private IEnumerable<TextBox> InputtableTextBoxes => this.valueTextBoxes.Where(x => x.Enabled);
		#endregion

		#region event handlers
		private void frmMain_Load(object sender, EventArgs e)
		{
			// アセンブリ名のカンマまでをシステム名としてタイトルバーに記載
			this.Text = new string(Assembly.GetEntryAssembly().FullName.TakeWhile(x => x != ',').ToArray());

			this.txtValue1.ImeMode = ImeMode.Disable;
			this.txtValue2.ImeMode = ImeMode.Disable;
			this.txtValue1.MaxLength = ValueTxtMaxLength;
			this.txtValue2.MaxLength = ValueTxtMaxLength;
			this.valueTextBoxes = new List<TextBox>(new TextBox[] { this.txtValue1, this.txtValue2 });

			// 　OtherCalcPattern列挙型の全ての列挙子をリストにしたものをコンボボックスのデータソースに設定
			var otherCalcPatternList = Enum.GetValues(typeof(OtherCalcPattern)).OfType<OtherCalcPattern>().Select(x => x.Name()).ToList();
			this.cmbOtherCalcPattern.DataSource = otherCalcPatternList;

			this.btnCancel.Enabled = false;

			this.Initialize();
		}

		private async void btnCalc_Click(object sender, EventArgs e)
		{
			// クリアボタン以外は入力不可にする
			this.ControlEnabledAll(true);

			var values = this.InputtableTextBoxes.Select(x => x.Text.Length > 0 ? float.Parse(x.Text) : 0).ToArray();

			// 選択されている計算パターンとビジネスクラスの計算パターンを紐づける
			BizMain.CalculateType calcType;
			if (this.rbtnAddition.Checked)
			{
				calcType = BizMain.CalculateType.Addition;
			}
			else if (this.rbtnOther.Checked)
			{
				switch ((OtherCalcPattern)this.cmbOtherCalcPattern.SelectedIndex)
				{
					case OtherCalcPattern.Power:
						calcType = BizMain.CalculateType.Power;
						break;
					default:
						return;
				}
			}
			else
			{
				return;
			}

			this.toolStripStatusLabel.Text = CalculatingMessage;
			//　非同期で計算実行
			var result = await biz.CalculateAsync(calcType, values);
			this.lblResult.Text = result.ToString();
			this.toolStripStatusLabel.Text = string.Empty;

			// 入力可能に戻す
			this.ControlEnabledAll(false);
		}

		private async void btnCancel_Click(object sender, EventArgs e)
		{
			await this.CancelCalculation();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.Initialize();
		}

		private void rbtnCalcPattern_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rbtn = (RadioButton)sender;
			if (!rbtn.Checked) return;

			// その他が選択された場合のみコンボボックス活性化
			this.cmbOtherCalcPattern.Enabled = this.rbtnOther.Checked;

			if(this.rbtnOther.Checked)
			{
				// 何も選択されていない場合は1番目を選択状態に変更
				if (this.cmbOtherCalcPattern.SelectedIndex == -1)
				{
					this.cmbOtherCalcPattern.SelectedIndex = 0;
				}
			}

			var setSignAction = this.rbtnOther.Checked ? new Action(this.SetOtherCalcPatternSign) : new Action(this.SetRegularCalcPatternSign);
			var getInputValueCntFunc = this.rbtnOther.Checked ? new Func<int>(GetInputValueCntOnOtherCalcPattern) : new Func<int>(this.GetInputValueCntOnRegularCalcPattern);

			this.OnCalcPatternChanedAsync(setSignAction, getInputValueCntFunc);
		}

		private void cmbOtherCalcPattern_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.OnCalcPatternChanedAsync(this.SetOtherCalcPatternSign, this.GetInputValueCntOnOtherCalcPattern);
		}

		private void txtValue_TextChanged(object sender, EventArgs e)
		{
			this.lblResult.Text = string.Empty;
		}

		private void txtValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			TextBox txt = (TextBox)sender;
			this.Validate(txt);
		}
		#endregion

		#region private methods
		private void Initialize()
		{
			this.cmbOtherCalcPattern.SelectedIndex = -1;
			this.txtValue1.Text = string.Empty;
			this.txtValue2.Text = string.Empty;
			this.rbtnAddition.Checked = true;
		}

		private void OnCalcPatternChanedAsync(Action setSignAction, Func<int> getInputValueCntFunc)
		{
			// 算術記号設定
			setSignAction();

			// テキストボックス活性制御
			this.EnableTextBoxes(getInputValueCntFunc());
			this.Validate();

			this.lblResult.Text = string.Empty;
		}

		private void SetRegularCalcPatternSign()
		{
			if (this.rbtnAddition.Checked) {
				this.lblCalcSign1.Text = string.Empty;
				this.lblCalcSign2.Text = AdditionSign;
			} else if (this.rbtnSubtraction.Checked) {
				this.lblCalcSign1.Text = string.Empty;
				this.lblCalcSign2.Text = SubtractionSign;
			} else if (this.rbtnMultiplication.Checked) {
				this.lblCalcSign1.Text = string.Empty;
				this.lblCalcSign2.Text = MultiplicationSign;
			} else if (this.rbtnDivision.Checked) {
				this.lblCalcSign1.Text = string.Empty;
				this.lblCalcSign2.Text = DivisionSign;
			}
		}

		private void SetOtherCalcPatternSign()
		{
			var otherCalcPattern = (OtherCalcPattern)(this.cmbOtherCalcPattern.SelectedIndex);
			switch (otherCalcPattern)
			{
				case OtherCalcPattern.Power:
					this.lblCalcSign1.Text = string.Empty;
					this.lblCalcSign2.Text = PowerSign;
					break;
			}
		}

		private int GetInputValueCntOnRegularCalcPattern()
		{
			return 2;
		}

		private int GetInputValueCntOnOtherCalcPattern()
		{
			var otherCalcPattern = (OtherCalcPattern)(this.cmbOtherCalcPattern.SelectedIndex);
			int ret = 0;
			switch (otherCalcPattern)
			{
				case OtherCalcPattern.Power:
					ret = 2;
					break;
			}
			return ret;
		}

		private void EnableTextBoxes(int count)
		{
			this.valueTextBoxes.Take(count).ToList().ForEach(x => x.Enabled = true);
			this.valueTextBoxes.Skip(count).ToList().ForEach(x => x.Enabled = false);
		}

		private void Validate(TextBox targetTxt = null)
		{
			var targets = (targetTxt == null) ? this.InputtableTextBoxes : new TextBox[] { targetTxt };

			foreach (var txt in targets)
			{
				if (txt.Text.Length == 0 || float.TryParse(txt.Text, out var _))
				{
					// エラー情報クリア
					this.errorProvider.SetError(txt, string.Empty);
				}
				else
				{
					// エラー情報設定
					this.errorProvider.SetError(txt, NotNumericErrorMessage);
				}
			}

			// 入力可能なテキストボックス全てに計算可能な値が入力されている場合は計算ボタンを活性化
			this.btnCalc.Enabled = this.InputtableTextBoxes.ToList().TrueForAll(x => x.Text.Length > 0 && this.errorProvider.GetError(x) == string.Empty);
		}

		private void ControlEnabledAll(bool isCalculating)
		{
			this.rbtnAddition.Enabled = !isCalculating;
			this.rbtnSubtraction.Enabled = !isCalculating;
			this.rbtnMultiplication.Enabled = !isCalculating;
			this.rbtnDivision.Enabled = !isCalculating;
			this.rbtnOther.Enabled = !isCalculating;
			this.cmbOtherCalcPattern.Enabled = isCalculating ? false : this.rbtnOther.Checked;

			this.valueTextBoxes.ForEach(x => x.ReadOnly = isCalculating);
			this.btnCalc.Enabled = !isCalculating;
			this.btnClear.Enabled = !isCalculating;
			this.btnCancel.Enabled = isCalculating;
		}

		private Task CancelCalculation()
		{
			Task waitTask = Task.CompletedTask;
			if (this.biz.IsCalculating)
			{
				// 確認メッセージ表示
				if (MessageBox.Show(CofirmCancelingMessage, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					this.toolStripStatusLabel.Text = CancelingCalcMessage;
					// キャンセル処理が一瞬で終わるとステータスバーのメッセージを視認できないので待機用のタスク生成
					waitTask = Task.Delay(1000);
				}
				else
				{
					return Task.CompletedTask;
				}
			}

			var cancelTask = Task.Run(() => {
												this.biz.CancelCalculation();
												// UIスレッドでコントロール活性制御
												this.Invoke(new Action(() => this.ControlEnabledAll(false)));
											});

			//　キャンセル処理と待機処理両方が完了後にステータスバーのメッセージをクリアするタスクを返却
			return Task.WhenAll(cancelTask, waitTask).ContinueWith((_) => this.toolStripStatusLabel.Text = string.Empty);
		}
		#endregion
	}
}