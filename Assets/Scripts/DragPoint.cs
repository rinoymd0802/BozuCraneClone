using UnityEngine;

public class DragPoint : MonoBehaviour
{
    private Vector3 offset;

    void OnMouseDown()
    {
        Vector3 mouse =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouse.z = 0;

        offset = transform.position - mouse;
    }

    void OnMouseDrag()
    {
        Vector3 mouse =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouse.z = 0;

        transform.position = mouse + offset;
    }
}