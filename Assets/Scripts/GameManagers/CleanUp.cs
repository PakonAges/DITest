using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CleanUp {

    CubesHolderSO cubesCollection;
    
    public CleanUp(CubesHolderSO cubesHolder) 
    {
        cubesCollection = cubesHolder;
    }

    public void CleanCubes() {
        cubesCollection.RemoveAllCubes();
    }
}
