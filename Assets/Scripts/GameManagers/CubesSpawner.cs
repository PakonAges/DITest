using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubesSpawner : IInitializable {

    CubesManager _cubesManager;

    public CubesSpawner(CubesManager cubesManager) {
        _cubesManager = cubesManager;
    }

    public void Initialize() {
        for (int i = 0; i < 5; i++) {
            _cubesManager.SpawnCube(SpawnSource.Init);
        }
    }
}
