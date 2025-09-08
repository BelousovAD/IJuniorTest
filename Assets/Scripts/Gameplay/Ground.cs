namespace Gameplay
{
    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class Ground : MonoBehaviour, IPointerClickHandler
    {
        public event Action<Vector3> Clicked;
        
        public void OnPointerClick(PointerEventData eventData) =>
            Clicked?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
    }
}