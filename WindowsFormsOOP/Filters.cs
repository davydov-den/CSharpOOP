using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOOP
{
    abstract class Filter
    {
        double filterValue;
        string filterName;
        double absolute, relation;

        public Filter()
        {
            filterValue = 0;
            absolute = 0;
            relation = 0;
            filterName = "Базовый";
        }

        public Filter(double _filterValue, double _absolute, double _relation)
        {
            filterValue = _filterValue;
            absolute = _absolute;
            relation = _relation;
            filterName = "Базовый";
        }
        public double Absolute
        {
            set{absolute = value;}
            get{return absolute;}
        }

        public double Relation
        {
            set{relation = value;}
            get{return relation;}
        }

        public double FilterValue
        {
            set{filterValue = value;}
            get{return filterValue;}
        }

        public string FilterName
        {
            set{filterName = value;}
        }

        abstract public bool CheckValue(double value);
        public virtual string GetName()
        {
            return filterName;
        }


    }

    class FilterAbsoluteExcess : Filter
    {
        public FilterAbsoluteExcess()
        {
            base.Absolute = 0;
            base.FilterValue = 0;
            base.FilterName = "Абсолютное превышение";
        }

        public FilterAbsoluteExcess(double _filterValue, double _absolute)
        {
            base.FilterValue = _filterValue;
            base.Absolute = _absolute;
            base.FilterName = "Абсолютное превышение";
        }

        public override bool CheckValue(double value)
        {
            return value - base.FilterValue > base.Absolute;
        }
    }

    class FilterAbsoluteDeviation : Filter
    {
        public FilterAbsoluteDeviation()
        {
            base.Absolute = 0;
            base.FilterValue = 0;
            base.FilterName = "Абсолютное отклонение";
        }
        public FilterAbsoluteDeviation(double _filterValue, double _absolute)
        {
            base.FilterValue = _filterValue;
            base.Absolute = _absolute;
            base.FilterName = "Абсолютное отклонение";
        }
        public override bool CheckValue(double value)
        {
            return Math.Abs(value - base.FilterValue) > base.Absolute;
        }
    }

    class FilterRelationExcess : Filter
    {
       public FilterRelationExcess()
        {
            base.Relation = 0;
            base.FilterValue = 0;
            base.FilterName = "Относительное превышение";
        }
       public FilterRelationExcess(double _filterValue, double _relation)
        {
            base.FilterValue = _filterValue;
            base.Relation = _relation;
            base.FilterName = "Относительное превышение";
        }
        public override bool CheckValue(double value)
        {
            return (value / base.FilterValue - 1) > base.Relation;
        }
    }

    class FilterRelationDeviation : Filter
    {
       public FilterRelationDeviation()
        {
            base.Relation = 0;
            base.FilterValue = 0;
            base.FilterName = "Относительное отклонение";
        }
       public FilterRelationDeviation(double _filterValue, double _relation)
        {
            base.FilterValue = _filterValue;
            base.Relation = _relation;
            base.FilterName = "Относительное отклонение";
        }
        public override bool CheckValue(double value)
        {
            return Math.Abs(value / base.FilterValue - 1) > base.Relation;
        }
    }

}
