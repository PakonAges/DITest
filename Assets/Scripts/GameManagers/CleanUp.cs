using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CleanUp : MonoBehaviour {

    CubesHolderSO cubesCollection;

    [Inject]
    public void Construct(CubesHolderSO cubesHolder) 
    {
        cubesCollection = cubesHolder;
    }

    private void OnApplicationQuit() {
        cubesCollection.RemoveAllCubes();
    }
}
