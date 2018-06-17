using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinAppSample_WinForm.Applications.FrmMain;

namespace WinAppSample_WinForm.Service
{
	public static class EnumExtension
	{
		public static string Name(this OtherCalcPattern type)
		{
			switch (type)
			{
				case OtherCalcPattern.Power:
					return "べき乗";
				case OtherCalcPattern.Sin:
					return "Sin";
				default:
					return string.Empty;
			}
		}
	}
}
