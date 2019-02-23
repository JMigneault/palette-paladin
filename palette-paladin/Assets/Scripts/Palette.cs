using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour {

    public enum PalColor { None=0, Red=1, Blue=2, Yellow=4, Green=6, Purple=3, Orange=5, Brown=7 }; // todo: could bitwise represenation work? (use [flags])

    private PalColor color = PalColor.None;

    public void MixColor(PalColor toMixColor)
    {
        if (toMixColor == PalColor.Red)
        {
            Debug.Log("got a red one!");
        }
    }

}
