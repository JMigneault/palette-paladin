using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] private float resetTime;
    private Sprite defSprite;
    private float timeSinceCast = 0.0f;
    private Image imageRenderer;

    private void Start()
    {
        imageRenderer = GetComponent<Image>();
        defSprite = imageRenderer.sprite;
    }

    private void Update()
    {
        timeSinceCast += Time.deltaTime;
        if (timeSinceCast > resetTime)
        {
            imageRenderer.sprite = defSprite;
        }
    }

    public void SetCastImage(Sprite s)
    {
        imageRenderer.sprite = s;
        timeSinceCast = 0.0f;
    }

}
