using UnityEngine;

public class Arm2SetUp : MonoBehaviour
{
    // •Ï”
    // PivotRotationZ
    [SerializeField]
    private float pivotZAngle = 50.0f;
    private void Start()
    {
        // Pivot‚ÌZ‰Šú’lİ’è
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, pivotZAngle);
    }

}