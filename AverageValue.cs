using System;
using System.Linq;

namespace AverageValue
{
    public class AverageValue
    {
        private readonly double _average;
        private readonly UInt64 _elementcount;
        internal AverageValue(params int[] values) { _average = values.Average(); _elementcount = (UInt64)values.Length; }
        internal AverageValue(params double[] values) { _average = values.Average(); _elementcount = (UInt64)values.Length; }

        private AverageValue(double preAve, UInt64 preCount) { _average = preAve; _elementcount = preCount; }
        
        internal AverageValue AddValues(params int[] adds)
        {
            AverageValue rtn = new AverageValue(adds);
            rtn = rtn.UnionAverage(this);
            return rtn;
        }
        internal AverageValue AddValues(params double[] adds)
        {
            AverageValue rtn = new AverageValue(adds);
            rtn = rtn.UnionAverage(this);
            return rtn;
        }
        internal AverageValue UnionAverage(AverageValue ave)
        {
            if (UInt64.MaxValue - _elementcount <= ave._elementcount) throw new Exception("要素数上限到達");
            UInt64 sumelementcount = _elementcount + ave._elementcount;
            double ave1 = _average * (_elementcount / sumelementcount),
                   ave2 = ave._average * (ave._elementcount / sumelementcount);
            return new AverageValue(ave1 + ave2, sumelementcount);

        }
        internal double ShowAverageValue() { return _average; }
        internal double ShowAverageValue(int digits) { return Math.Round(_average, digits, MidpointRounding.ToEven); }
        
    }

}

