using UnityEngine;

public class DragPoint : MonoBehaviour
{
    // マウス位置とオブジェクト位置の差分を保持
    // クリックしたときにオブジェクトが吸いつくのを防ぐため
    private Vector3 offset;

    // マウスクリック
    void OnMouseDown()
    {
        // マウスカーソルのワールド座標取得
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 2D用にZを固定
        mouse.z = 0;
        // オブジェクトとマウスの位置差を保存
        offset = transform.position - mouse;
    }

    // マウスドラッグ
    void OnMouseDrag()
    {
        // マウスカーソルのワールド座標取得
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 2D用にZを固定
        mouse.z = 0;
        // クリックの時の位置差を保持したまま移動
        transform.position = mouse + offset;
    }
}