using System;
using System.Threading;
using System.Threading.Tasks;
using WinAppSample_WinForm.Services;


namespace WinAppSample_WinForm.Business
{
	/// <summary>
	/// メイン画面のビジネスロジッククラス
	/// </summary>
	public class BizMain
	{
		#region private fields
		private Task<float> calcultionTask;
		private CancellationTokenSource tokenSource;
		#endregion

		#region enums
		/// <summary>
		/// 計算種別
		/// </summary>
		public enum CalculateType
		{
			/// <summary>加算</summary>
			Addition,
			/// <summary>減算</summary>
			Subtraction,
			/// <summary>乗算</summary>
			Multiplication,
			/// <summary>除残</summary>
			Division,
			/// <summary>べき乗</summary>
			Power,
			/// <summary>Sine</summary>
			Sine,
		}
		#endregion

		#region Properties
		public bool IsCalculating => this.calcultionTask?.Status == TaskStatus.Running || this.calcultionTask?.Status == TaskStatus.WaitingToRun;
		
		#endregion

		#region public methods
		/// <summary>
		/// 計算処理を行う
		/// </summary>
		/// <param name="calculateType">計算種別</param>
		/// <param name="values">計算対象の値</param>
		/// <returns>計算結果</returns>
		public async Task<float> CalculateAsync(CalculateType calculateType, params float[] values)
		{
			if (!this.HasCorrectParameterCount(calculateType, values))
			{
				throw new ArgumentException("引数の数が正しくありません。");
			}

			ICalculator<float> calculator = null;
			switch (calculateType)
			{
				case CalculateType.Addition:
					calculator = new AdditionCalculator<float>(values[0], values[1]);
					break;
				case CalculateType.Power:
					calculator = new PowerCalculator<float>(values[0], values[1]);
					break;
				case CalculateType.Sine:
					calculator = new SineCalculator<float>(values[0]);
					break;
			}

			string errorMessage;
			if (calculator.Validate(out errorMessage))
			{
				this.tokenSource = new CancellationTokenSource();
				this.calcultionTask = Task.Run(() => calculator.Calculate(), this.tokenSource.Token);
			}
			else
			{
				this.calcultionTask = Task.FromException<float>(new ApplicationException(errorMessage));
			}

			return await this.calcultionTask;
		}

		/// <summary>
		/// 実行中の計算処理を停止する。
		/// </summary>
		public void CancelCalculation()
		{
			this.tokenSource?.Cancel();
			this.tokenSource?.Dispose();
		}
		#endregion

		#region private methods
		private bool HasCorrectParameterCount(CalculateType calculateType, params float[] values)
		{
			int count = 0;
			switch (calculateType)
			{
				case CalculateType.Addition:
				case CalculateType.Power:
					count = 2;
					break;
				case CalculateType.Sine:
					count = 1;
					break;
			}

			return (values.Length == count);
		}
		#endregion
	}
}
