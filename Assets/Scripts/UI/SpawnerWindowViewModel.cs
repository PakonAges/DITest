using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class SpawnerWindowViewModel : MonoBehaviour {

    CubesManager _spawner;
    SceneLoader _loader;

    [Inject]
    public void Construct(CubesManager spawner, SceneLoader sceneLoader)
    {
        _spawner = spawner;
        _loader = sceneLoader;
    }

    [Binding]
	public void SpawnCube() {
        _spawner.SpawnCube(SpawnSource.UI);
    }

    [Binding]
    public void LoadFirstScene() {
        _loader.LoadFirstScene();
    }

    [Binding]
    public void LoadCubesFromSave() {
        //To implement
    }

    [Binding]
    public void ClearCubes() {
        //To implement
    }

}
