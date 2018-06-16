using System;


namespace WinAppSample_WinForm.Services
{
	/// <summary>
	/// 加算処理を行うクラス
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class AdditionCalculator<T> : ICalculator<T> where T : struct
	{
		#region private fields
		private T value1;
		private T value2;
		#endregion


		#region constructors
		public AdditionCalculator(T value1, T value2)
		{
			this.value1 = value1;
			this.value2 = value2;
		}
		#endregion


		#region public methods
		/// <summary>
		/// 計算対象の値の検証を行う
		/// </summary>
		/// <returns></returns>
		public bool Validate() => true;

		/// <summary>
		/// 計算を行う
		/// </summary>
		/// <returns></returns>
		public T Calculate()
		{
			switch (this.value1)
			{
				case float floatVal1:
					return (T)(object)(floatVal1 + (float)(object)this.value2);
				default:
					throw new NotImplementedException();
			}
		}
		#endregion
	}
}
