namespace Pickable.Medicine
{
    using Pickable;
    using UnityEngine;

    public class CoinSpawner : AbstractPickableSpawner<Medicine>
    {
        private void Start() =>
            SpawnAtPoints();

        protected override void PickedHandler(Medicine pickable)
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
