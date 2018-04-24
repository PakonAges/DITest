using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class SetupWindowViewModel : MonoBehaviour {

    [Binding]
    public void LoadScene() {
        //Should Create service for this. And inject it
        SceneManager.LoadScene(1);
    }
}
