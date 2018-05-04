using System;
using UnityEngine;
using Zenject;

public class CubesManager : ITickable, IInitializable {

    Cube.Factory _cubeFactory;
    public Settings settings;
    CubesHolderSO _cubesList;

    public int CubesToSpawn {
        get { return _cubesList.CubesToSpawn; }
        set { _cubesList.CubesToSpawn = value; }
    }

    public CubesManager(Cube.Factory cubeFactory, Settings settings, CubesHolderSO cubesHolder) {
        _cubeFactory = cubeFactory;
        this.settings = settings;
        _cubesList = cubesHolder;
    }

    public void Initialize() {
        if (_cubesList.Cubes.Count != 0) {
            RestoreCubes();
        }
    }

    public int GetCubesAmount() {
        return _cubesList.Cubes.Count;
    }

    public void ResetAllCubes() {
        _cubesList.RemoveAllCubes();
        _cubesList.CubesToSpawn = 0;
    }

    void RestoreCubes() {
        foreach (var cube in _cubesList.Cubes) {
            var newCube = _cubeFactory.Create();
            newCube.Position = cube.Position;
            newCube.Scale = cube.Scale;

            switch (cube.Scr) {
                case SpawnSource.Init:
                newCube.CubeMaterial = settings.InititalSpawnMaterial;
                break;
                case SpawnSource.UI:
                newCube.CubeMaterial = settings.UISpawnMaterial;
                break;
                case SpawnSource.Hand:
                newCube.CubeMaterial = settings.HandSpawnMaterial;
                break;
                default:
                newCube.CubeMaterial = settings.InititalSpawnMaterial;
                break;
            }
        }
    }

    public void Tick() {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnCube(SpawnSource.Hand);
        }
    }

    public void SpawnCube(SpawnSource src) {
        var cube = _cubeFactory.Create();
        cube.Position = RandomPosition();
        cube.Scale = RandomScale(settings.minScale, settings.maxScale);

        switch (src) {
            case SpawnSource.Init:
            cube.CubeMaterial = settings.InititalSpawnMaterial;
            break;
            case SpawnSource.UI:
            cube.CubeMaterial = settings.UISpawnMaterial;
            break;
            case SpawnSource.Hand:
            cube.CubeMaterial = settings.HandSpawnMaterial;
            break;
            default:
            cube.CubeMaterial = settings.InititalSpawnMaterial;
            break;
        }
        

        _cubesList.AddCube(cube.Position, cube.Scale, src);
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

public enum SpawnSource {
    Init,
    UI,
    Hand
}
