namespace Pickable.Coin
{
    using UnityEngine;

    public class CoinSpawner : AbstractPickableSpawner<Coin>
    {
        private void Start() =>
            SpawnAtPoints();

        protected override void PickedHandler(Coin pickable)
        {
            base.PickedHandler(pickable);
            Destroy(pickable.gameObject);
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshPointsArray))]
        protected override void RefreshPointsArray() =>
            base.RefreshPointsArray();
#endif
    }
}
