using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityWeld.Binding;

[CreateAssetMenu(menuName = "Unity Weld/Adapter options/Color validation adapter")]
public class ColorValidationAdapterOptions : AdapterOptions {
    [Header("Valid color")]
    public ColorBlock NormalColor;

    [Space]

    [Header("Invalid color")]
    public ColorBlock InvalidColor;
}
