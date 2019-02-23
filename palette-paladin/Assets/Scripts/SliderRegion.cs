using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Represents a region on the slider bar. Child classes have specific effect, eg. mix a color 
 **/
[System.Serializable]
public abstract class SliderRegion : MonoBehaviour {

    [SerializeField] protected float pos; // starting position
    [SerializeField] protected float width; // size of region

    protected Palette palette; // access to the palette for color mixing

    private void Start()
    {
        palette = transform.parent.GetComponent<Palette>();
    }

    // Check if a position is over the region
    public bool IsInRegion(float checkPos)
    {
        return (pos <= checkPos) && (checkPos <= pos + width);
    }

    // for debugging slider regions, display a line from start to end of region
    public void TestDrawLine()
    {
        Slider par = GetComponentInParent<Slider>();
        LineRenderer line = this.gameObject.AddComponent<LineRenderer>();
        Vector3[] positions = { par.PosToCoords(pos), par.PosToCoords(pos + width) };
        line.SetPositions(positions);
        line.startWidth = 10.0f;
        line.endWidth = 10.0f;
    }

    public abstract void UseRegion(); // To be implemented depending on slider functionality

}
