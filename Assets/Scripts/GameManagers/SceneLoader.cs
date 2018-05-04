using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class SceneLoader {

    public void LoadFirstScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadSecondScene() {
        SceneManager.LoadScene(1);
    }
}
