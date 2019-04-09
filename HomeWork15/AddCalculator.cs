using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    delegate void Proc();

    /// Калькулятор для сложения целых чисел
    class AddCalculator
	{
        /// Последний результат
        protected double fResult;
        /// Текущий операнд
        protected double fOperand;
        /// Процедура вычисления последней заданной операции
        protected Proc fCalcOp;
        /// Последняя вызванная команда
        protected Command fLastCommand;
        /// Последняя нажатая кнопка
        protected BtnType fLastButton;
        /// Содержимое дисплея
        protected ShowNum fShowing;

        /// Перемещение значения операнда в результат
        private void OperToRes()
        {
            fResult = fOperand;
        }
        /// Перемещение значения результата в операнд
        private void ResToOper()
        {
            fOperand = fResult;
        }

        /// Установка операнда
        private void SetOperand(int d)
        {
            fOperand = d;
        }

        //protected -- Защищённые члены класса - для вызова из потомков или перекрытия

        // Вполнение арифметической операции
        protected void Calculate()
        {
            fCalcOp();
            fShowing = ShowNum.ResS;
        }

        /// Дописывание цифры к операнду
        protected void AddToOper(int d)
        {
            fOperand = fOperand * 10 + d;
        }

        /// Нажатие кнопки сброса
        public void CE()
        {
            SetOperand(0);
            OperToRes();
            fLastCommand = Command.None;
            fLastButton = BtnType.NoneB;
            fShowing = ShowNum.OperS;
        }

        ///Конструктор        
        public AddCalculator()
        {
            CE();
        }

        /// Нажатие цифровой кнопки
        public void Digit(int d)
        {
            switch (fLastButton)
            {
                case BtnType.ComB:
                    switch (fLastCommand)
                    {
                        case Command.Op: OperToRes(); break;
                        case Command.Res: CE(); break;
                    }
                    SetOperand(d);
                    break;
                default:
                    AddToOper(d);
                    break;
            }
            fLastButton = BtnType.DigitB;
            fShowing = ShowNum.OperS;
        }

        /// Нажатие на клавишу операции
        public void PerformOp()
        {
            switch (fLastButton)
            {
                case BtnType.ComB:
                    switch (fLastCommand)
                    {
                        case Command.Res: ResToOper(); break;
                    }
                    break;
                case BtnType.DigitB:
                    switch (fLastCommand) {
                        case Command.Op: Calculate(); ResToOper(); break;
                    }
                    break;
            }
            fLastCommand = Command.Op;
            fLastButton = BtnType.ComB;
        }

        /// Нажатие кнопки "+"
        public void Plus()
        {
            PerformOp();

            // всем в укрытие - лямбда-процедура!
            fCalcOp = () => fResult += fOperand;
        }


        /// Нажатие кнопки результата "="
        public void Result()
        {
            Calculate();
            fLastCommand = Command.Res;
            fLastButton = BtnType.ComB;
        }


        /// Преобразование к строке для "просмотра дисплея" калькулятора
        public  string ToString()
        {
            return (fShowing == ShowNum.ResS) ? fResult.ToString() : fOperand.ToString();
        }
    }
}

