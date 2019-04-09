using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// Перечислимый тип для вида "командной" кнопки калькулятора
    enum Command
    {
        /// Кнопка операции ("+", "-" и т.п.)
        Op,

        /// Кнопка результата "="
        Res,

        /// Нажатий кнопок не было
        None,
	    ///нажатие точки 
		//Dot
    }
}
