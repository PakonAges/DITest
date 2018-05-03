using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class SetupWindowViewModel : MonoBehaviour, INotifyPropertyChanged {

    string _sessionCounter = "";

    string _cubesToSpawnTxt = "";
    int cubesAmount;
    bool cubesCounterValid = true;

    SceneLoader _sceneLoader;
    CleanUp _cleaner;
    Player _player;
    Saveloader _saveLoader;

    [Inject]
    public void Construct(SceneLoader loader, CleanUp cleaner, Player player, Saveloader saveloader) {
        _sceneLoader = loader;
        _cleaner = cleaner;
        _player = player;
        _saveLoader = saveloader;
    }

    void Start() {
        SessionsCounter = _player.TotalSessions.ToString();
        CubesAmount = 5;
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
    public int CubesAmount {
        get {
            return cubesAmount;
        }

        set {
            if (cubesAmount == value) {
                return;
            }
            else {
                cubesAmount = value;
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
    public void LoadScene() {
        _sceneLoader.LoadSecondScene();
    }

    [Binding]
    public void OnExitPressed() {
        _cleaner.CleanCubes();
        SaveProfile();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

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
    public void ResetProfile() {
        _saveLoader.ResetProfile();
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
}
