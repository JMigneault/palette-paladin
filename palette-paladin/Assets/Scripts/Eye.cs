using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eye : MonoBehaviour {

    [SerializeField] private Sprite defaultImage;
    [SerializeField] private Sprite[] eyeImages;
    private Palette.PalColor color;
    private SpriteRenderer image;

    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
    }

    public void SetColorPos(Palette.PalColor c, Vector2 p)
    {
        color = c;
        image.sprite = eyeImages[(int) color - 4]; // todo: fix
        transform.localPosition = p;
    }

    public bool IsColor(Palette.PalColor p)
    {
        return p == this.color;
    }

    public void KillEye()
    {
        image.sprite = defaultImage;
    }    

}
