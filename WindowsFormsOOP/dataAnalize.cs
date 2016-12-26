using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOOP
{
    //Класс потомок
    class DataAnalize
    {
        bool successAnalize;
        double absolute, relation; //абсолютное и относительное отклонение
        List<Types.ResultAnalize> results;
        List<Types.Condition> conditions;
        List<Types.Indication> indications;

        public bool SuccessAnalize
        {
            get
            {
                return successAnalize;
            }
        }

        //проверить, что искомый датчике есть в списке датчиков для этого условия
        bool Find(int id, List<int> listSensors)
        {
            for (int i = 0; i < listSensors.Count; i++)
                if (listSensors[i] == id)
                    return true;
            return false;
        }

        //провести анализ
        public void DoAnalize()
        {
            Filter[] massivFilters;
            massivFilters = new Filter[4];

            massivFilters[0] = new FilterAbsoluteDeviation(0, absolute);
            massivFilters[1] = new FilterAbsoluteExcess(0, absolute);
            massivFilters[2] = new FilterRelationDeviation(0, relation);
            massivFilters[3] = new FilterRelationExcess(0, relation);


            string filter = "";
            try
            {
                results = new List<Types.ResultAnalize>();
                for (int i = 0; i < indications.Count; i++) //проверяем все показания
                {
                    for (int j = 0; j < conditions.Count; j++) //на все условия
                    {
                        for (int numberFilter = 0; numberFilter < 4; numberFilter++)
                            massivFilters[numberFilter].FilterValue = conditions[j].Conditions;
                        //проверим что для датчика актуально условие и проверим отклоенение
                        if (Find(indications[i].Id, conditions[j].IdIndicators))
                        {
                            filter = "";
                            for (int numberFilter = 0; numberFilter < 4; numberFilter++)
                                if (massivFilters[numberFilter].CheckValue(indications[i].Value))
                                    filter = massivFilters[numberFilter].GetName();
                            if (filter != "")
                            {
                                Types.ResultAnalize newResult = new Types.ResultAnalize(); //записываем данные
                                newResult.Time = indications[i].Time;
                                newResult.Id = indications[i].Id;
                                newResult.EventS = conditions[j].EventS;
                                newResult.Value = indications[i].Value;
                                newResult.Cond = conditions[j].Conditions;
                                newResult.Filter = filter;
                                results.Add(newResult);
                            }
                        }
                    }
                }
                successAnalize = true;
            }
            catch (Exception ex)
            {
                successAnalize = false;
            }
        }

        //передаем данные в  класс
        public void SetData(List<Types.Condition> _conditions, List<Types.Indication> _indications, double _absolute, double _relationn)
        {
            conditions = _conditions;
            indications = _indications;
            absolute = _absolute;
            relation = _relationn;
        }

        //Выводим результаты в таблицу
        public void PrintResult(DataGridView data)
        {
            data.Rows.Clear();
            for (int i = 0; i < results.Count; i++)
            {
                data.Rows.Add();
                data[0, i].Value = results[i].Time;
                data[1, i].Value = results[i].Id;
                data[2, i].Value = results[i].Value;
                data[3, i].Value = results[i].Cond;
                data[4, i].Value = results[i].EventS;
                data[5, i].Value = results[i].Filter;
            }
        }
    }
}
