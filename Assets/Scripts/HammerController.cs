using UnityEngine;

public class HammerController : MonoBehaviour
{
    [SerializeField]
    private Transform hammerPivot;

    private void Update()
    {
        transform.position = hammerPivot.position;
    }
}