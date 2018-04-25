using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class SetupWindowViewModel : MonoBehaviour {

    [Inject]
    SceneLoader _sceneLoader;

    [Binding]
    public void LoadScene() {
        _sceneLoader.LoadSecondScene();
    }
}
