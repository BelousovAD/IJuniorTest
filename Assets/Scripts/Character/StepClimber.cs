namespace Character
{
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class StepClimber : MonoBehaviour
    {
        [SerializeField] private Transform _lowerPoint;
        [SerializeField, Range(0f, 90f)] private float _slopeLimit = 45f;
        [SerializeField, Min(0)] private float _stepOffset = 0.3f;
        
        private readonly List<ContactPoint> _contactPoints = new();
        private Rigidbody _rigidbody;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void OnCollisionStay(Collision other)
        {
            if (Vector3.Dot(_rigidbody.velocity, Vector3.up) == 0)
            {
                return;
            }
            
            _contactPoints.Clear();
            other.GetContacts(_contactPoints);
            ContactPoint highestPoint = FindHighestContactPoint();

            if (Vector3.Angle(Vector3.up, highestPoint.normal) < _slopeLimit)
            {
                return;
            }
            
            float requiredStep = FindHighestContactPoint().point.y - _lowerPoint.position.y;

            if (requiredStep <= _stepOffset)
            {
                _rigidbody.position += new Vector3(0f, requiredStep, 0f);
            }
        }

        private ContactPoint FindHighestContactPoint()
        {
            ContactPoint highestPoint = _contactPoints[0];

            for (int i = 1; i < _contactPoints.Count; i++)
            {
                if (_contactPoints[i].point.y > highestPoint.point.y)
                {
                    highestPoint = _contactPoints[i];
                }
            }

            return highestPoint;
        }
    }
}
