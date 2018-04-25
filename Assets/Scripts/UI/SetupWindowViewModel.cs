using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class SetupWindowViewModel : MonoBehaviour, INotifyPropertyChanged {

    string _sessionCounter = "";
    string _cubesToSpawn = "";

    [Inject]
    SceneLoader _sceneLoader;

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
    public string CubesToSpawn {
        get { return _cubesToSpawn; }
        set {
            if (_cubesToSpawn == value) {
                return;
            }
            else {
                _cubesToSpawn = "Current Cubes Amount: " + value;
                OnPropertyChanged("CubesToSpawn");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName) {
        if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [Binding]
    public void LoadScene() {
        _sceneLoader.LoadSecondScene();
    }
}
