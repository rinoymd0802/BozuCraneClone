using UnityEngine;

public class JointDragController : MonoBehaviour
{
    // 変数
    private bool isDrag; // ドラッグ中フラグ

    private void Update()
    {
        // ドラッグ中のみ移動
        if (isDrag)
        {
            MoveToMouse();
        }
    }

    // マウスを押した時
    private void OnMouseDown()
    {
        isDrag = true;
    }

    // マウスを離した時
    private void OnMouseUp()
    {
        isDrag = false;
    }

    // マウス位置へ移動
    private void MoveToMouse()
    {
        // マウス座標取得
        Vector3 mousePosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Z座標補正
        mousePosition.z = 0.0f;

        // 関節移動
        transform.position = mousePosition;
    }
}