using Input;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _throwPointForSpring;
    [SerializeField] private Transform _readyPointForSpring;
    [SerializeField] private Transform _spawnBallPoint;
    [SerializeField] private SpringJoint _spring;
    [SerializeField] private Ball _ball;

    private void OnEnable()
    {
        _inputReader.ThrowRequested += Throw;
        _inputReader.GetReadyRequested += GetReady;
        _inputReader.SpawnBallRequested += SpawnBall;
    }
    
    private void OnDisable()
    {
        _inputReader.ThrowRequested -= Throw;
        _inputReader.GetReadyRequested -= GetReady;
        _inputReader.SpawnBallRequested -= SpawnBall;
    }

    private void Throw() =>
        _spring.transform.position = _throwPointForSpring.position;

    private void GetReady() =>
        _spring.transform.position = _readyPointForSpring.position;

    private void SpawnBall() =>
        Instantiate(_ball, _spawnBallPoint.position, Quaternion.identity, null);
}