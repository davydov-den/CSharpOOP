using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOOP
{
    class Types
    {
        //тип показание
        public struct Indication
        {
            int id; //номер датчика
            DateTime time; //время
            double _value; //значение

            public int Id
            {
                set{id=value;}
                get{return id;}
            }
            public DateTime Time
            {
                set { time = value; }
                get { return time; }
            }
            public double Value
            {
                set { _value = value; }
                get { return _value; }
            }                
        };
        //условие
        public struct Condition
        {
            string eventS; //название
            double conditions; //условие
            List<int> idIndicators; //список датчиков для которых проверяем
            string parametrs; //параметры

            public string EventS
            {
                set { eventS = value; }
                get { return eventS; }
            }
            public double Conditions
            {
                set { conditions = value; }
                get { return conditions; }
            }
            public List<int> IdIndicators
            {
                set { idIndicators = value; }
                get { return idIndicators; }
            }
            public string Parametrs
            {
                set { parametrs = value; }
                get { return parametrs; }
            }
        };

        //результат анализа
        public struct ResultAnalize
        {
            DateTime time; //время
            int id; //номер датчика
            double _value; //значение
            string eventS; //событие
            string filter; //название фильтра
            double cond;

            public DateTime Time
            {
                set { time = value; }
                get { return time; }
            }
            public int Id
            {
                set { id = value; }
                get { return id; }
            }
            public double Value
            {
                set { _value = value; }
                get { return _value; }
            }
            public string EventS
            {
                set { eventS = value; }
                get { return eventS; }
            }
            public string Filter
            {
                set { filter = value; }
                get { return filter; }
            }
            public double Cond
            {
                set { cond = value; }
                get { return cond; }
            }
        };
    }
}
