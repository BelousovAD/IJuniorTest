namespace Fort.ChangeableValue
{
    using Common.ChangeableValue;
    
    public class HasFreeUnit : ChangeableValue<bool>
    {
        public void SetValue(bool value) =>
            Value = value;
    }
}