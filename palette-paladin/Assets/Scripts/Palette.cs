using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Class for representing color mixing and casting
 **/
public class Palette : MonoBehaviour {

    // Enum representing all possible colors, may be extended in the future
    public enum PalColor { None, Red, Blue, Yellow, Green, Purple, Orange, Brown }; // todo: could bitwise representation work? (use [flags])

    [SerializeField] private PalColor color = PalColor.None; // The current color of the palette

    [SerializeField] private EnemyManager enemyManager; // Tracks all enemies on the screen

    // Image for displaying the current color
    public Image testImage;

    // Naive color mixing system (all done with conditionals)
    public void MixColor(PalColor toMixColor)
    {
        if (color == toMixColor || color == PalColor.Brown)
        {
            return;
        }
        if (color == PalColor.None)
        {
            color = toMixColor;
            return;
        }
        if (color == PalColor.Green)
        {
            if (toMixColor == PalColor.Red)
            {
                color = PalColor.Brown;
            }
            return;
        }
        if (color == PalColor.Purple)
        {
            if (toMixColor == PalColor.Yellow)
            {
                color = PalColor.Brown;
            }
            return;
        }
        if (color == PalColor.Orange)
        {
            if (toMixColor == PalColor.Blue)
            {
                color = PalColor.Brown;
            }
            return;
        }
        if (toMixColor == PalColor.Red)
        {
            if (color == PalColor.Yellow)
            {
                color = PalColor.Orange;
            } else // color == Blue
            {
                color = PalColor.Purple;
            }
        }
        if (toMixColor == PalColor.Yellow)
        {
            if (color == PalColor.Red)
            {
                color = PalColor.Orange;
            } else // color == Blue
            {
                color = PalColor.Green;
            }
        }
        if (toMixColor == PalColor.Blue)
        {
            if (color == PalColor.Red)
            {
                color = PalColor.Purple;
            } else // color == Yellow
            {
                color = PalColor.Green;
            }
        }
    }

    // Converts a PalColor enum to a UI.graphic.Color for display on a UI image
    private Color EnumToUIColor(PalColor col)
    {
        if (col == PalColor.Blue)
        {
            return Color.blue;
        }
        if (col == PalColor.Yellow)
        {
            return Color.yellow;
        }
        if (col == PalColor.Red)
        {
            return Color.red;
        }
        if (col == PalColor.Orange)
        {
            return new Vector4(1.0f, 0.55f, 0.0f, 1.0f);
        }
        if (col == PalColor.Purple)
        {
            return new Vector4(0.29f, 0.0f, 0.51f, 1.0f);
        }
        if (col == PalColor.Green)
        {
            return Color.green;
        }
        if (col == PalColor.Brown)
        {
            return Color.black;
        }
        if (col == PalColor.None)
        {
            return Color.white;
        }
        Debug.Log("error color not found :" + col.ToString());
        return Color.gray;
    }

    // Casts the color, removing it from the palette and affecting creatures
    private void CastColor()
    {
        enemyManager.CastColor(this.color);
        this.color = PalColor.None;
    }

    // called each from
    private void Update()
    {
        // for testing
        testImage.color = EnumToUIColor(color); // set UI image to current color
        if (Input.GetKeyDown(KeyCode.Return)) // "Enter" casts the color
        {
            this.CastColor();
        }
    }

}
