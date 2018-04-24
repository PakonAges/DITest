using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class SpawnerWindowViewModel : MonoBehaviour {

    [Inject]
    CubesManager _spawner;

    [Binding]
	public void SpawnCube() {
        _spawner.SpawnCube(_spawner.settings.UISpawnMaterial);
    }

}
