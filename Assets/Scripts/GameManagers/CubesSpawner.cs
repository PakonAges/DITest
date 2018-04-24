using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubesSpawner : IInitializable {

    private CubesManager _cubesManager;
    private Material _spawnMaterial;

    public CubesSpawner(CubesManager cubesManager) {
        _cubesManager = cubesManager;
        _spawnMaterial = cubesManager.settings.InititalSpawnMaterial;
    }

    public void Initialize() {
        for (int i = 0; i < 5; i++) {
            _cubesManager.SpawnCube(_spawnMaterial);
        }
    }
}
