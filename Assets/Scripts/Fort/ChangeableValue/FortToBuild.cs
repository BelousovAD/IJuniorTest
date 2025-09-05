namespace Fort.ChangeableValue
{
    using Common.ChangeableValue;

    public class FortToBuild : ChangeableValue<Fort>
    {
        public void SetValue(Fort fort) =>
            Value = fort;
    }
}