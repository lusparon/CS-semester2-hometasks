using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	class FullRatioCalculator:AddSubRatioCalculator
	{
		public bool flag= false;

		public void Multiplication()
		{
			PerformOp();

			// всем в укрытие - лямбда-процедура!
			fCalcOp = () => fResult *= fOperand;
		}

		public void Division()
		{
			PerformOp();
			fCalcOp = () =>
			{
				if (fOperand == 0)
				{
					flag = true;
				}
				else
				{
					fResult /= fOperand;
				}
			};
		}

		public  new string ToString()
		{
			if (flag)
			{
				flag = false;
				return "ERROR";
			}
			else return base.ToString();
		}
	}
}
