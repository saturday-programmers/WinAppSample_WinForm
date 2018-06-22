using System;
using System.Threading;


namespace WinAppSample_WinForm.Services
{
	/// <summary>
	/// べき乗の計算を行うクラス
	/// </summary>
	/// <typeparam name="T">底、指数、解の型</typeparam>
	public class PowerCalculator<T> : ICalculator<T> where T : struct
	{
		#region private fields
		private T value1;
		private T value2;
		#endregion

		#region constructors
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="value1">底</param>
		/// <param name="value2">指数</param>
		public PowerCalculator(T value1, T value2)
		{
			this.value1 = value1;
			this.value2 = value2;
		}
		#endregion

		#region public methods
		/// <summary>
		/// 計算対象の値の検証を行う
		/// </summary>
		/// <returns>値が正しいかどうか</returns>
		public bool Validate() => true;

		/// <summary>
		/// 計算を行う
		/// </summary>
		/// <returns>計算結果の値</returns>
		public T Calculate()
		{
			Thread.Sleep(10000);
			switch (this.value1)
			{
				case float floatVal1:
					return (T)(object)Convert.ToSingle(Math.Pow(floatVal1, (float)(object)this.value2));
				default:
					throw new NotImplementedException();
			}
		}
		#endregion
	}
}
