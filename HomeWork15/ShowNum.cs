using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// Перечислимый тип для величины, отображаемой калькулятором
    enum ShowNum
    {
        /// Отображается текущий операнд
        OperS,
        /// Отображается последний результат
        ResS
    }
}
