using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// Перечислимый тип для вида кнопки калькулятора
    enum BtnType
    {
        /// Командная кнопка ("=", "+", "-" и т.п.)
        ComB,

        /// Цифра
        DigitB,

        /// Нажатий кнопок не было
        NoneB,
		///нажатие точки 
		DotB
	}

}
