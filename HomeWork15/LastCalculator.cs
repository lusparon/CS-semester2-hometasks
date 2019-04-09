using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	class LastCalculator:FullRatioCalculator
	{
		//убирает самую правую цифру у числа на экране;
		public void  ClearLast()
		{
			if (fDotPressed)
			{
				if (fShowing == ShowNum.ResS)
					fResult = Math.Round(fResult, fDigitsAfterDot - 1);
				else if (fShowing == ShowNum.OperS)
					fOperand = Math.Round(fOperand, fDigitsAfterDot - 1);
			}
			else
			{
				int a = (int)fResult;
				int b = (int)fOperand;
				if (fShowing == ShowNum.ResS)
					a = a/10;
				else if (fShowing == ShowNum.OperS)
					b=b/10;
				fResult = a;
				fOperand = b;
			}
		}
		//дописывает справа к числу два нуля.
		public void DoubleZero()
		{
			if (fShowing == ShowNum.ResS)
				fResult = fResult * 100;
			else if (fShowing == ShowNum.OperS)
				fOperand *= 100;
		}
		//нажатие «+/−» (смена знака текущего числа).
		public void ChangeSign()
		{
			if (fShowing == ShowNum.ResS)
				fResult = fResult * -1;
			else if (fShowing == ShowNum.OperS)
				fOperand *= -1;
		}


	}
}
