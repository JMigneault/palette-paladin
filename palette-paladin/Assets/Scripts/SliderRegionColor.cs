using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // todo: is this necessary
public class SliderRegionColor : SliderRegion {

    [SerializeField] protected Palette.PalColor palColor; // color of region

    public override void UseRegion()
    {
        palette.MixColor(this.palColor);
    }

}
