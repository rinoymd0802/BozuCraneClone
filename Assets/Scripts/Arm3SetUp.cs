using UnityEngine;

public class Arm3SetUp: MonoBehaviour
{
    // •Ï”
    // PivotRotationZ
    [SerializeField]
    private float pivotZAngle = 60.0f;
    private void Start()
    {
        // Pivot‚ÌZ‰Šú’lİ’è
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, pivotZAngle);
    }

}