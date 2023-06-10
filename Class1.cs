using System;
using System.Linq;

namespace Average
{
    public class AverageValue
    {
        private readonly double _average;
        private readonly UInt64 _elementcount;
        internal AverageValue(params int[] values) { _average = values.Average(); _elementcount = (UInt64)values.Length; }
        internal AverageValue(params double[] values) { _average = values.Average(); _elementcount = (UInt64)values.Length; }
        private AverageValue(double preAve, UInt64 preCount) { _average = preAve; _elementcount = preCount; }
        internal AverageValue AddValue(int add)
        {
            if (ulong.MaxValue == _elementcount) throw new Exception("上限到達");
            return new AverageValue(_average + (add - _average) / (_elementcount + 1), _elementcount + 1);
        }
        internal AverageValue AddValues(params int[] adds)
        {
            AverageValue rtn = new AverageValue(_average, _elementcount);
            foreach (int i in adds) rtn = rtn.AddValue(i);
            return rtn;
        }
        internal double ShowAverage() { return _average; }
        internal double ShowAverage(int digit) { return Math.Round(_average, digit, MidpointRounding.ToEven); }
    }

}
