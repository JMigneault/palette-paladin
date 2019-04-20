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

    private PalColor color = PalColor.None; // The current color of the palette

    [SerializeField] private EnemyManager enemyManager; // Tracks all enemies on the screen

    [SerializeField] private Sprite[] paletteSprites; // All palette sprites (of each color)

    private bool frozen = false;
    [SerializeField] float freezeTime;

    // Image for displaying the current color
    [SerializeField] private Image currentImage;

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
    private Sprite EnumToSprite(PalColor col)
    {
        return this.paletteSprites[(int) col];
    }

    // Casts the color, removing it from the palette and affecting creatures
    private void CastColor()
    {
        if (!frozen)
        {
            StartCoroutine(FreezeCasting(freezeTime));
            enemyManager.CastColor(this.color);
            this.color = PalColor.None;
        }
    }

    private IEnumerator FreezeCasting(float t)
    {
        this.frozen = true;
        yield return new WaitForSeconds(t);
        this.frozen = false;
    }

    // called each from
    private void Update()
    {
        // set sprite to appropriate color
        this.currentImage.sprite = EnumToSprite(this.color);
        if (Input.GetKeyDown(KeyCode.Return)) // "Enter" casts the color
        {
            this.CastColor();
        }
    }

}
