using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WindowsFormsOOP
{
    class Condite
    {
        int i;
        int tmp;
        Exception resultException;
        bool success;
        List<Types.Condition> conditions;//список данных
        public List<Types.Condition> Condition
        {
            get{return conditions;}
        }
        public bool Success
        {
            get{return success;}
        }
        public Exception ResultException
        {
            get{return resultException;}
        }
     
        public Condite(string FileName)
        {
            try
            {
                conditions = new List<Types.Condition>();
                string[] stringWithCondition;

                StreamReader reader = new StreamReader(FileName, Encoding.UTF8); //открыли файл
                string line;
                while ((line = reader.ReadLine()) != null) //считываем
                {
                    i = 2;
                    stringWithCondition = line.Split(' '); //разделили строку по пробелам 
                    Types.Condition condit = new Types.Condition();
                    condit.EventS = stringWithCondition[0]; //берем событие
                    condit.Conditions = double.Parse(stringWithCondition[1]); //условие
                    condit.Parametrs = "";
                    List<int> listSensor = new List<int>();
                    while (i < stringWithCondition.Count() && int.TryParse(stringWithCondition[i], out tmp)) //получаем список датчиков
                    {
                        listSensor.Add(tmp);
                        i++;
                    }
                    condit.IdIndicators = listSensor;
                    for (; i < stringWithCondition.Count(); i++) //получаем параметры
                        condit.Parametrs += stringWithCondition[i] + ' ';
                    conditions.Add(condit);
                }
                reader.Close();
                success = true;
            }
            catch (Exception ex)
            {
                resultException = ex;
                success = false;
            }

        }
    }
}
