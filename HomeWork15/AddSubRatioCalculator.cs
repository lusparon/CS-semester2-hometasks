using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	class AddSubRatioCalculator:AddRatioCalculator
	{
		/// <summary>
		/// Нажатие кнопки "-"
		/// </summary>
		public void Minus()
		{
			PerformOp();

			// всем в укрытие - лямбда-процедура!
			fCalcOp = () => fResult -= fOperand;
		}

		///конструктор
		public AddSubRatioCalculator() : base()
		{
		}
	}
}
