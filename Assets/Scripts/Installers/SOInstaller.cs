using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
{
    public CubesManager.Settings Cubes;

    public override void InstallBindings()
    {
        Container.BindInstance(Cubes);
    }
}