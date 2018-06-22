namespace WinAppSample_WinForm.Services
{
	/// <summary>
	/// 計算処理のインターフェース
	/// </summary>
	/// <typeparam name="T">解の型</typeparam>
	interface ICalculator<T> where T : struct
	{
		/// <summary>
		/// 計算対象の値の検証を行う
		/// </summary>
		/// <returns></returns>
		bool Validate();

		/// <summary>
		/// 計算を行う
		/// </summary>
		/// <returns></returns>
		T Calculate();
	}
}
