using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Child class of SliderRegion. Color mixing regions.
 **/
[System.Serializable] // todo: is this necessary
public class SliderRegionColor : SliderRegion {

    [SerializeField] protected Palette.PalColor palColor; // Color of region

    public override void UseRegion()
    {
        palette.MixColor(this.palColor); // Mix the color into the palette
    }

}
