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
    [SerializeField] private Sprite[] castSprites;

    private bool frozen = false;
    [SerializeField] float freezeTime;
    [SerializeField] float castingFrameDelay;

    // Image for displaying the current color
    [SerializeField] private Image currentImage;
    [SerializeField] private Image castImage;

    private AudioSource paintSound;
    private AudioSource mixSound;

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
            // StartCoroutine(FreezeCasting(freezeTime));
            if (this.color != PalColor.None)
            {
                StartCoroutine(CastingAnimation(this.color));
            }
            this.color = PalColor.None;
        }
    }

    private IEnumerator CastingAnimation(PalColor c)
    {
        paintSound.Play();
        int i = (int) c - 1;
        this.castImage.sprite = castSprites[(4 * i) + 0];
        this.castImage.enabled = true;
        yield return new WaitForSeconds(castingFrameDelay);
        this.castImage.sprite = castSprites[(4 * i) + 1];
        yield return new WaitForSeconds(castingFrameDelay);
        enemyManager.CastColor(c);
        this.castImage.sprite = castSprites[(4 * i) + 2];
        yield return new WaitForSeconds(castingFrameDelay);
        this.castImage.sprite = castSprites[(4 * i) + 3];
        yield return new WaitForSeconds(castingFrameDelay);
        this.castImage.enabled = false;
    }

    private IEnumerator FreezeCasting(float t)
    {
        this.frozen = true;
        yield return new WaitForSeconds(t);
        this.frozen = false;
    }

    private void Start()
    {
        paintSound = GetComponent<AudioSource>();
        this.castImage.sprite = null;
        this.castImage.enabled = false;
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
