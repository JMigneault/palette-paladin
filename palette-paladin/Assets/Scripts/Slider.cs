using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls the movement of the slider and tracks player input for mixing colors
 **/
public class Slider : MonoBehaviour {

    // Parameters defining the sliders path curveRadius(X/Y) values in range [0.0f, 1.0f] as proportion of screen
    [SerializeField] private float curveRadiusX;
    [SerializeField] private float curveRadiusY;
    [SerializeField] private float minAngle; // Angles in radians/pi => 2 is 360 degrees, 1 is a semicircle, 5/6 is 5/12 of a circle
    [SerializeField] private float maxAngle;

    [SerializeField] private float speed; // Speed in radians/pi/sec => 1 is 180 degrees/second

    private SliderRegion[] regions; // An array of regions on the slider bar

    private float position = 1.0f; // The proportion of the slider bar from right to left => 0.0f is the right end of the bar; 1.0f is the left end
    private float curveOffsetX; // Pixel offsets for starting position
    private float curveOffsetY;

    private void Start()
    {
        // SliderRegion objects as children
        regions = GetComponentsInChildren<SliderRegion>();
        curveOffsetX = this.transform.position.x;
        curveOffsetY = this.transform.position.y;
        // Uncomment to see slider regions drawn in scene view while game is running
        TestDisplayRegions();
    }

    // For testing; displays slider regions
    private void TestDisplayRegions()
    {
        foreach (SliderRegion s in regions)
        {
            s.TestDrawLine();
        }
    }

    // Changes the position proportion ([0.0f, 1.0f]) to a pixel position on the screen
    public Vector2 PosToCoords(float pos)
    {
        float t = minAngle * Mathf.PI + (maxAngle - minAngle) * Mathf.PI * pos;
        float x = S2P(curveRadiusX, true) * Mathf.Cos(t) + curveOffsetX;
        float y = S2P(curveRadiusY, false) * Mathf.Sin(t) + curveOffsetY;
        return new Vector2(x, y);
    }

    // converts from proportion of screen to screen space [pixels] for displaying ui
    // TODO: seperate sizes from aspect ratio (relative to a standard reso vs proportion of screen)
    private float S2P(float proportion, bool isWidth)
    {
        if (isWidth) {
            return Screen.width * proportion;
        } else
        {
            return Screen.height * proportion;
        }
    }

    // Moves the slider by increasing position by speed and finding the new pixel coordinates
    private void MoveSlider()
    {
        position += speed * Time.deltaTime;
        transform.position = PosToCoords(position);
    }

    // Check if the slider has reached the end of the bar and reverse speed if so
    private void CheckForTurnAround()
    {
        if (position > 1.0f) {
            position = 1.0f;
            speed *= -1;
        } else if (position < 0.0f)
        {
            position = 0.0f;
            speed *= -1;
        }
    }

    // Called on use input. Check if the slider in over a region and return it or return null if not
    private SliderRegion CheckForRegion()
    {
        foreach (SliderRegion s in regions)
        {
            if (s.IsInRegion(position))
            {
                return s;
            }
        }
        return null;
    }

    // Called when the user misses a region
    private void MissedRegion()
    {
        // todo
        Debug.Log("You missed.");
    }

    // called each frame
    private void Update()
    {
        MoveSlider(); // advance slider position
        CheckForTurnAround(); // reverse speed if slider at end of bar
        if (Input.GetKeyDown(KeyCode.Space)) // check for user input
        {
            SliderRegion activatedRegion = CheckForRegion(); // get region slider is over
            if (activatedRegion != null)
            {
                activatedRegion.UseRegion();
            }
            else  // if user missed
            {
                MissedRegion();
            }
        }
    }

}
