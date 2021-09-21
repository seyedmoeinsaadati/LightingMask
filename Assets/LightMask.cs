using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMask : MonoBehaviour
{

    public enum MaskType { Light, Circle };
    public MaskType maskType;

    Light mlight;
    RaycastHit hit;
    public CircleGenerator maskGenerator;
    public float offset = 0;
    float spotScale;
    float range = 1;

    [System.Serializable]
    public class Mask
    {
        public int resolution = 3;
        public List<Vector3> castPoints;
    }

    private void Awake()
    {
        mlight = GetComponentInChildren<Light>();
        maskGenerator = GetComponentInChildren<CircleGenerator>();
        spotScale = Mathf.Tan(mlight.spotAngle / 2 * Mathf.Deg2Rad);
    }

    void UpdateMask()
    {
        maskGenerator.transform.localPosition = Vector3.forward * range;

        if (maskType == MaskType.Light) return;
        //maskGenerator.GenerateMesh(Mask mask);
        else
            maskGenerator.GenerateMesh(maskGenerator.resolution, range * spotScale);
    }

    Vector3 firstPointOnCone;

    private void LateUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.red, .1f);
        if (Physics.Raycast(ray, out hit, 200))
        {
            float distance = (hit.point - transform.position).magnitude;
            range = distance - offset;
        }

        UpdateMask();
        // RayPoints();
    }

    public Mask mask;

    public void RayPoints()
    {
        firstPointOnCone = (transform.up * range * spotScale) + GeneralDirection;
        Vector3 dir = firstPointOnCone.normalized;
        // Ray ray;
        for (int i = 0; i < mask.resolution; i++)
        {
            //ray = new Ray(transform.position, dir);
            Debug.DrawRay(transform.position, dir, Color.red, .1f);

            dir = dir.RotateXY((float)360 / mask.resolution * Mathf.Deg2Rad, true) + GeneralDirection.normalized;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.white;
        //Gizmos.DrawSphere(transform.TransformPoint(firstPointOnCone), .1f);
    }

    public Vector3 GeneralDirection
    {
        get
        {
            return transform.forward * range;
        }
    }


}