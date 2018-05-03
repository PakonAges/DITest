using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityWeld.Binding;

[Adapter(typeof(bool), typeof(ColorBlock), typeof(ColorValidationAdapterOptions))]
public class ColorValidationAdapter : IAdapter {
    public object Convert(object valueIn, AdapterOptions adapterOptions) {
        var isValid = (bool)valueIn;
        var options = (ColorValidationAdapterOptions)adapterOptions;

        return isValid ? options.NormalColor : options.InvalidColor;
    }
}
