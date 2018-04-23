using System;
using UnityEngine;
using Zenject;

public class CubesManager : ITickable {

    Cube.Factory _cubeFactory;
    Settings _settings;

    public CubesManager(Cube.Factory cubeFactory, Settings settings) {
        _cubeFactory = cubeFactory;
        _settings = settings;
    }

    public void Tick() {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnCube();
        }
    }

    public void SpawnCube() {
        var cube = _cubeFactory.Create();
        cube.Position = RandomPosition();
        cube.Scale = RandomScale(_settings.minScale, _settings.maxScale);
    }

    Vector3 RandomPosition() {
        return new Vector3(RandomScale(_settings.minPosition, _settings.maxPosition),0, RandomScale(_settings.minPosition, _settings.maxPosition));
    }

    float RandomScale(float min, float max) {
        return UnityEngine.Random.Range(min, max);
    }

    [Serializable]
    public class Settings {
        public GameObject CubePrefab;
        public float minScale;
        public float maxScale;
        public float minPosition;
        public float maxPosition;
    }
}
