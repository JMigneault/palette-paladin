using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SliderRegion : MonoBehaviour {

    [SerializeField] protected float pos; // starting position
    [SerializeField] protected float width; // size of region

    protected Palette palette;

    private void Start()
    {
        palette = transform.parent.GetComponent<Palette>();
    }

    public bool IsInRegion(float checkPos)
    {
        return (pos <= checkPos) && (checkPos <= pos + width);
    }

    public abstract void UseRegion();

}
