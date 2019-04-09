using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	class AddRatioCalculator : AddCalculator
	{
		//поле для подсчёта количества цифр после десятичной точки
		public int fDigitsAfterDot;
		//нажата ли точка
		public bool fDotPressed;

		void ClearDot()
		{
			fDigitsAfterDot = 0;
			fDotPressed = false;
		}

		/// <summary>
		/// нажатие точки
		/// </summary>
		public void Dot()
		{
			fDotPressed = true;
			if ((fLastButton ==BtnType.ComB) && (fLastCommand == Command.Res)) CE();
			fDigitsAfterDot = 0;
			fLastButton = BtnType.DotB;
			//fLastCommand = Command.Dot;
		}

		///конструктор
		public AddRatioCalculator():base()
		{
			fDigitsAfterDot = 0;
        }
		///
		public new void Digit(int d)
		{
			if (fDotPressed)
			{
				fDigitsAfterDot += 1;
				fOperand = fOperand + d*Math.Pow(0.1,fDigitsAfterDot);
				fLastButton = BtnType.DigitB;
				fShowing = ShowNum.OperS;
			}
			else base.Digit(d);
			
		}

		public new void CE()
		{
			base.CE();
			ClearDot();
		}

		public new void Plus()
		{
			base.Plus();
			ClearDot();
		}

		public new void Result()
		{
			base.Result();
			ClearDot();
		}
		public new string ToString()
		{
			var s = base.ToString();
			if (fLastButton == BtnType.DotB)
				s += ",";
			return s;
		}
	}
}
