using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class SceneLoader {

    Saveloader _saver;

    public SceneLoader(Saveloader saver) {
        saver = _saver;
    }

    public void LoadFirstScene() {
        SceneManager.LoadScene(0);
        _saver.LoadProfile();
    }

    public void LoadSecondScene() {
        SceneManager.LoadScene(1);
        _saver.LoadProfile();
    }
}
