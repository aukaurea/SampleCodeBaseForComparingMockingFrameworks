using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SampleCodeBase.Interface;
using SampleCodeBase.Model;

namespace SampleCodeBase.Helpers
{
    public static class EnumHelper
    {
        public static IEnumRangeModel GetRange(Type enumGiven)
        {
            var enumValues = Enum.GetValues(enumGiven);
            int min = 0, max = 0;

            foreach (var currentValue in enumValues)
            {
                var currentValueAsString = currentValue.ToString();
                var enumConverted = Enum.Parse(enumGiven, currentValueAsString);
                var intValue = (int) enumConverted;

                if (min >= intValue)
                {
                    min = intValue;
                }

                if (max <= intValue)
                {
                    max = intValue;
                }
            }

            return new EnumRangeModel(min, max);
        }

        public static T GetRandomEnum<T>()
        {
            var rnd = new Random();
            var rangeModel = EnumHelper.GetRange(typeof(T));
            dynamic random = rnd.Next(rangeModel.Min, rangeModel.Max);
            var result = (T) random;

            return result;
        }
    }
}
