namespace Pickable.Coin
{
    using UnityEngine;

    public class CoinSpawner : AbstractPickableSpawner<Coin>
    {
        private void Start() =>
            SpawnAtPoints();

        protected override void PickedHandler(IPickable pickable)
        {
            base.PickedHandler(pickable);
            Destroy((pickable as Coin).gameObject);
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshPointsArray))]
        protected override void RefreshPointsArray() =>
            base.RefreshPointsArray();
#endif
    }
}
