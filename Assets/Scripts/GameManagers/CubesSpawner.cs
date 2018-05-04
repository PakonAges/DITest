using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubesSpawner : IInitializable {

    CubesManager _cubesManager;
    CubesHolderSO _cubesHolder;

    public CubesSpawner(CubesManager cubesManager, CubesHolderSO cubesHolderSO) {
        _cubesManager = cubesManager;
        _cubesHolder = cubesHolderSO;
    }

    public void Initialize() {
        for (int i = 0; i < _cubesHolder.CubesToSpawn; i++) {
            _cubesManager.SpawnCube(SpawnSource.Init);
        }
    }
}
