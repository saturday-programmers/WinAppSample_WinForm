using System;
using WinAppSample_WinForm.Services;


namespace WinAppSample_WinForm.Business
{
	/// <summary>
	/// メイン画面のビジネスロジッククラス
	/// </summary>
	public class BizMain
	{
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
			Power
		}
		#endregion


		#region public methods
		/// <summary>
		/// 計算処理を行う
		/// </summary>
		/// <param name="calculateType">計算種別</param>
		/// <param name="values">計算対象の値</param>
		/// <returns>計算結果</returns>
		public float Calculate(CalculateType calculateType, params float[] values)
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
			}

			var isValid = calculator?.Validate() ?? false;
			var result = isValid ? calculator.Calculate() : 0;

			return result;
		}
		#endregion


		#region private methods
		private bool HasCorrectParameterCount(CalculateType calculateType, params float[] values)
		{
			bool ret = false;
			switch (calculateType)
			{
				case CalculateType.Addition:
				case CalculateType.Power:
					ret = (values.Length == 2);
					break;
			}

			return ret;
		}
		#endregion
	}
}
