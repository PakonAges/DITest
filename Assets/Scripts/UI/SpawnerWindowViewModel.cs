using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class SpawnerWindowViewModel : MonoBehaviour, INotifyPropertyChanged {

    CubesManager _spawner;
    SceneLoader _loader;
    Saveloader _saveLoader;

    int _cubesNumber = 0;
    string _cubesAmountTxt = "";


    [Inject]
    public void Construct(CubesManager spawner, SceneLoader sceneLoader, Saveloader saveloader)
    {
        _spawner = spawner;
        _loader = sceneLoader;
        _saveLoader = saveloader;
    }

    public int CubesNumber {
        get {
            return _cubesNumber;
        }

        set {
            _cubesNumber = value;
            CubesAmountTxt = value.ToString();

            OnPropertyChanged("CubesAmountTxt");
        }
    }

    [Binding]
    public string CubesAmountTxt {
        get {
            return _cubesAmountTxt;
        }

        set {
            _cubesAmountTxt = "Total Cubes: " + value;
            OnPropertyChanged("CubesAmountTxt");
        }
    }


    void Start() {
        CubesNumber = _spawner.GetCurentCubesAmount();
    }


    [Binding]
	public void SpawnCube() {
        _spawner.SpawnCube(SpawnSource.UI);
        CubesNumber++;
    }

    [Binding]
    public void LoadFirstScene() {
        _spawner.ResetLocalCubeData();
        _loader.LoadFirstScene();
    }

    [Binding]
    public void LoadCubesFromSave() {
        _saveLoader.LoadProfile();
        _spawner.RestoreCubes();
    }

    [Binding]
    public void ClearCubes() {
        _saveLoader.SaveProfile();
        _spawner.ResetAllCubes();
        CubesNumber = 0;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName) {
        if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
