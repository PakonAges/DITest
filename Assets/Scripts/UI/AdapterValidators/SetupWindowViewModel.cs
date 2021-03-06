﻿using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class SetupWindowViewModel : MonoBehaviour, INotifyPropertyChanged {

    string _sessionCounter = "";
    string _saveDate = "";

    string _cubesToSpawnTxt = "";
    int cubesAmount = 0;
    bool cubesCounterValid = true;

    SceneLoader _sceneLoader;
    Player _player;
    Saveloader _saveLoader;
    CubesHolderSO _cubesCollection;

    [Inject]
    public void Construct(SceneLoader loader, Player player, Saveloader saveloader, CubesHolderSO cubesCollection) {
        _sceneLoader = loader;
        _player = player;
        _saveLoader = saveloader;
        _cubesCollection = cubesCollection;
    }

    void Start() {
        SessionsCounter = _player.TotalSessions.ToString();
        SaveDate = _player.SaveDate;
        CubesAmount = Mathf.CeilToInt(_cubesCollection.CubesToSpawn);
    }

    [Binding]
    public string SessionsCounter {
        get { return _sessionCounter; }
        set 
        {
            if (_sessionCounter == value) {
                return;
            }
            else {
                _sessionCounter = "Total Sessions: " + value;
                OnPropertyChanged("SessionsCounter");
            }
        }
    }


    [Binding]
    public string CubesToSpawnTxt {
        get { return _cubesToSpawnTxt; }
        set {
            if (_cubesToSpawnTxt == value) {
                return;
            }
            else {
                _cubesToSpawnTxt = "Cubes Amount: " + value;
                OnPropertyChanged("CubesToSpawnTxt");
            }
        }
    }

    [Binding]
    public float CubesAmount {
        get {
            return cubesAmount;
        }

        set {
            if (cubesAmount == value) {
                return;
            }
            else {
                cubesAmount = Mathf.CeilToInt(value);
                _cubesCollection.CubesToSpawn = Mathf.CeilToInt(value);
                CubesToSpawnTxt = value.ToString();
                OnPropertyChanged("CubesAmount");
            }
        }
    }

    [Binding]
    public bool CubesCounterValid {
        get {
            return cubesCounterValid;
        }

        set {
            if (cubesCounterValid == value) {
                return;
            }

            cubesCounterValid = value;
            OnPropertyChanged("CubesCounterValid");

        }
    }

    [Binding]
    public string SaveDate {
        get {
            return _saveDate;
        }

        set {
            _saveDate = value;
            OnPropertyChanged("SaveDate");
        }
    }

    [Binding]
    public void LoadScene() {
        _sceneLoader.LoadSecondScene();
    }

    [Binding]
    public void OnExitPressed() {
        SaveProfile();
        AppStop();
    }

    [Binding]
    public void SaveProfile() {
        _saveLoader.SaveProfile();
    }

    [Binding]
    public void LoadProfile() {
        _saveLoader.LoadProfile();
    }

    [Binding]
    public void ResetAllSaveData() {
        _cubesCollection.ResetAll();
        _saveLoader.ResetProfile();
        AppStop();
    }

    [Binding]
    public void ResetLocal() {
        _cubesCollection.ResetAll();
        AppStop();
    }

    [Binding]
    public void IncrementSessions() {
        _player.IncrementSessionsCounter();
        SessionsCounter = _player.TotalSessions.ToString();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName) {
        if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    void AppStop() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
