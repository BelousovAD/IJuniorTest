namespace Fort.ChangeableValue
{
    using Common.ChangeableValue;

    public class Selection : ChangeableValue<Fort>
    {
        public void SetValue(Fort value) =>
            Value = value;
    }
}