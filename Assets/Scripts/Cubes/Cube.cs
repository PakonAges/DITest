using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Cube : MonoBehaviour {

    public Vector3 Position {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public float Scale {
        get {
            var scale = transform.localScale;

            return scale[0];
        }
        set {
            transform.localScale = new Vector3(value, value, value);
        }
    }

    public Material CubeMaterial 
    {
        get { return gameObject.GetComponent<Renderer>().material; }
        set { gameObject.GetComponent<Renderer>().material = value; }
    }

    public class Factory : Factory<Cube> 
    {

    }
}
