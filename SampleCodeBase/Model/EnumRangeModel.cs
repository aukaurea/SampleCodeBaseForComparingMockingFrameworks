namespace SampleCodeBase.Helpers
{
    public class EnumRangeModel : IEnumRangeModel
    {
        public EnumRangeModel(int min, int max)
        {
            Min = min;
            Max = max;
        }

        #region Implementation of IEnumRangeModel

        /// <inheritdoc />
        public int Min { get; set; }

        /// <inheritdoc />
        public int Max { get; set; }

        #endregion
    }
}