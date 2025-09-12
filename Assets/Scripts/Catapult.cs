using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private KeyCode _throwKey;
    [SerializeField] private KeyCode _readyKey;
    [SerializeField] private KeyCode _spawnBall;
    [SerializeField] private Transform _throwPointForSpring;
    [SerializeField] private Transform _readyPointForSpring;
    [SerializeField] private Transform _spawnBallPoint;
    [SerializeField] private SpringJoint _spring;
    [SerializeField] private Transform _ballPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(_throwKey))
        {
            Throw();
        }

        if (Input.GetKeyDown(_readyKey))
        {
            GetReady();
        }

        if (Input.GetKeyDown(_spawnBall))
        {
            SpawnBall();
        }
    }

    private void Throw() =>
        _spring.transform.position = _throwPointForSpring.position;

    private void GetReady() =>
        _spring.transform.position = _readyPointForSpring.position;

    private void SpawnBall() =>
        Instantiate(_ballPrefab, _spawnBallPoint.position, Quaternion.identity, null);
}