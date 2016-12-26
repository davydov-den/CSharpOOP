using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WindowsFormsOOP
{
    class Indicate
    {
        Exception resultException;
        bool success;
        List<Types.Indication> indications;

        public bool Success
        {
            get
            {
                return success;
            }
        }

        public Exception ResultException
        {
            get
            {
                return resultException;
            }
        }

        public List<Types.Indication> Indications
        {
            get
            {
                return indications;
            }

        }

        
        public Indicate(string FileName)
        {
            try
            {
                indications = new List<Types.Indication>();
                string[] stringWithIndication;
                StreamReader reader = new StreamReader(FileName, Encoding.UTF8);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    stringWithIndication = line.Split(' ');
                    Types.Indication indicate = new Types.Indication();
                    indicate.Id = int.Parse(stringWithIndication[0]);
                    indicate.Time = DateTime.Parse(stringWithIndication[1] + " " + stringWithIndication[2]);
                    indicate.Value = double.Parse(stringWithIndication[3]);
                    indications.Add(indicate);
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
