using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {

    [SerializeField] private float curveRadiusX;
    [SerializeField] private float curveRadiusY;
    [SerializeField] private float curveOffsetX;
    [SerializeField] private float curveOffsetY;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;

    [SerializeField] private float speed;

    private SliderRegion[] regions;

    private float position = 0.0f;

    private void Start()
    {
        regions = GetComponentsInChildren<SliderRegion>();
    }

    private Vector2 PosToCoords(float pos)
    {
        float t = minAngle * Mathf.PI + (maxAngle - minAngle) * Mathf.PI * pos;
        float x = curveRadiusX * Mathf.Cos(t) + curveOffsetX;
        float y = curveRadiusY * Mathf.Sin(t) + curveOffsetY;
        return new Vector2(x, y);
    }

    private void MoveSlider()
    {
        position += speed * Time.deltaTime;
        transform.position = PosToCoords(position);
    }

    private void CheckForTurnAround()
    {
        if (position > 1.0f || position < 0.0f)
        {
            speed *= -1;
        }
    }

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

    private void MissedRegion()
    {
        // todo
        Debug.Log("ya missed!");
    }

    private void Update()
    {
        MoveSlider();
        CheckForTurnAround();
        if (Input.GetKeyDown("space"))
        {
            SliderRegion activatedRegion = CheckForRegion();
            if (activatedRegion != null)
            {
                activatedRegion.UseRegion();
            } else
            {
                MissedRegion();
            }
        }
    }

}
