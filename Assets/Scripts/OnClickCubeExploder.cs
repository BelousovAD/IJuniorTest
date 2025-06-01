using System.Collections.Generic;
using UnityEngine;

public class OnClickCubeExploder : MonoBehaviour
{
    private const int ExponentForCalculateMultipliersFromCubeScale = -1;

    [SerializeField] private CubeClickChecker _cubeClickChecker;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Explosion _explosion;

    private void OnEnable() =>
        _cubeClickChecker.CubeClicked += ExplodeCube;

    private void OnDisable() =>
        _cubeClickChecker.CubeClicked -= ExplodeCube;

    private void ExplodeCube(Cube cube)
    {
        if (Random.value <= cube.DivisionChanceBoundary)
        {
            List<Cube> spawnedCubes = _cubeSpawner.Spawn(cube);
            List<Rigidbody> cubeRigidbodies = new();
            spawnedCubes.ForEach(spawnedCube => cubeRigidbodies.Add(spawnedCube.gameObject.GetComponent<Rigidbody>()));
            _explosion.Explode(cubeRigidbodies, cube.transform.position);
        }
        else
        {
            float forceMultiplier = Mathf.Pow(cube.transform.localScale.x, ExponentForCalculateMultipliersFromCubeScale);
            float radiusMultiplier = Mathf.Pow(cube.transform.localScale.x, ExponentForCalculateMultipliersFromCubeScale);
            _explosion.Explode(cube.transform.position, forceMultiplier, radiusMultiplier);
        }

        Destroy(cube.gameObject);
    }
}
