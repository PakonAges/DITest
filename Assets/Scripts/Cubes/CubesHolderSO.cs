using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CubesCollection", menuName = "CubesCollection")]
public class CubesHolderSO : ScriptableObject {

    public List<CubeData> Cubes;
    public int CubesToSpawn;

    public void AddCube(Vector3 pos, float scale, SpawnSource src) {
        var newCube = new CubeData(pos, scale, src);
        Cubes.Add(newCube);
    }

    public void RemoveCube(CubeData cube) {
        if (Cubes.Contains(cube)) {
            Cubes.Remove(cube);
        }
    }

    public void ResetAll() {
        CubesToSpawn = 0;
        RemoveAllCubes();
    }

    public void RemoveAllCubes() {
        if (Cubes.Count != 0) {
            Cubes.Clear();
        }
    }

    [Serializable]
    public class CubeData 
    {
        public Vector3 Position;
        public float Scale;
        public SpawnSource Scr;

        public CubeData(Vector3 pos, float scale, SpawnSource scr) 
        {
            Position = pos;
            Scale = scale;
            Scr = scr;
        }
    }
}
