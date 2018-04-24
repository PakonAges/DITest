using System;
using UnityEngine;
using Zenject;

public class CubesManager : ITickable {

    Cube.Factory _cubeFactory;
    public Settings settings;

    public CubesManager(Cube.Factory cubeFactory, Settings settings) {
        _cubeFactory = cubeFactory;
        this.settings = settings;
    }

    public void Tick() {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnCube(settings.HandSpawnMaterial);
        }
    }

    public void SpawnCube(Material material) {
        var cube = _cubeFactory.Create();
        cube.Position = RandomPosition();
        cube.Scale = RandomScale(settings.minScale, settings.maxScale);
        cube.CubeMaterial = material;
    }

    Vector3 RandomPosition() {
        return new Vector3(RandomScale(settings.minPosition, settings.maxPosition),0, RandomScale(settings.minPosition, settings.maxPosition));
    }

    float RandomScale(float min, float max) {
        return UnityEngine.Random.Range(min, max);
    }

    [Serializable]
    public class Settings {
        public GameObject CubePrefab;

        public Material InititalSpawnMaterial;
        public Material HandSpawnMaterial;
        public Material UISpawnMaterial;

        public float minScale;
        public float maxScale;
        public float minPosition;
        public float maxPosition;
    }
}
