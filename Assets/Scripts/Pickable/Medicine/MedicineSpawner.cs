namespace Pickable.Medicine
{
    using Pickable;
    using UnityEngine;

    public class MedicineSpawner : AbstractPickableSpawner<Medicine>
    {
        private void Start() =>
            SpawnAtPoints();

        protected override void PickedHandler(IPickable pickable)
        {
            base.PickedHandler(pickable);
            Destroy((pickable as Medicine).gameObject);
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshPointsArray))]
        protected override void RefreshPointsArray() =>
            base.RefreshPointsArray();
#endif
    }
}
