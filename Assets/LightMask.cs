using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMask : MonoBehaviour
{
    Light mlight;

    public CircleGenerator maskGenerator;

    private void Awake()
    {
        mlight = GetComponentInChildren<Light>();
        maskGenerator = GetComponentInChildren<CircleGenerator>();
    }

    void UpdateMask()
    {
        maskGenerator.transform.localPosition = transform.forward * mlight.range;
        float scale = Mathf.Tan(mlight.spotAngle / 2 * Mathf.PI / 180);
        print(scale);
        maskGenerator.GenerateMesh(maskGenerator.resolution, mlight.range * scale);
    }

    private void LateUpdate()
    {
        UpdateMask();
    }

}
