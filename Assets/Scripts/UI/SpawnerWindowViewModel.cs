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
    string _cubesAmountTxt = "";

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
        CubesAmountTxt = _spawner.GetCubesAmount().ToString();
    }

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
        
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName) {
        if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
