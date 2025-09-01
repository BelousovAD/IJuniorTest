namespace Pickable
{
    using System;
    using UnityEngine;

    public class Picker : MonoBehaviour
    {
        [SerializeField] private Transform _handPoint;
        [SerializeField] private Transform _dropPoint;
        
        public event Action Picked;
        
        public event Action Dropped;
        
        public IPickable Pickable { get; private set; }

        public void PickUp(IPickable pickable)
        {
            if (Pickable is not null)
            {
                return;
            }
            
            Pickable = pickable;
            Pickable.PickUp();

            if (pickable is MonoBehaviour component)
            {
                component.transform.SetParent(_handPoint);
                component.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            }

            Picked?.Invoke();
        }

        public void Drop()
        {
            if (Pickable is null)
            {
                return;
            }
            
            if (Pickable is MonoBehaviour component)
            {
                component.transform.SetParent(null);
                component.transform.SetPositionAndRotation(_dropPoint.position, Quaternion.identity);
            }
            
            Pickable.Drop();
            Pickable = null;
            Dropped?.Invoke();
        }
    }
}