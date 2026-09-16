using UnityEngine;

public class StretchArm : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    void Update()
    {
        Vector3 dir = endPoint.position - startPoint.position;

        transform.position =
            (startPoint.position + endPoint.position) * 0.5f;

        float angle =
            Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation =
            Quaternion.Euler(0, 0, angle);

        transform.localScale =
            new Vector3(dir.magnitude, 1f, 1f);
    }
}