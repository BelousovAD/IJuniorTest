namespace Character.Player
{
    using ChangeableValue;
    using Zenject;

    public class Player : Character
    {
        [Inject]
        private void Initialize(Health health) =>
            Health = health;
    }
}