using System;


namespace WinAppSample_WinForm.Service
{
	/// <summary>
	/// 計算処理のユーティリティクラス
	/// </summary>
	public static class MathUtil
	{
		#region public methods
		/// <summary>
		/// 角度をラジアンに変換する。
		/// </summary>
		/// <param name="angle">角度</param>
		/// <returns>ラジアン</returns>
		public static double AngleToRadian(double angle)
		{
			return angle * (Math.PI / 180);
		}
		#endregion
	}
}
