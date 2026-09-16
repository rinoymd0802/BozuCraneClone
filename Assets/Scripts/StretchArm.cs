using UnityEngine;

public class StretchArm : MonoBehaviour
{
    public Transform startPoint; // アーム始点
    public Transform endPoint; // アーム終点

    void Update()
    {
        // 始点から終点の方向ベクトル
        Vector3 dir = endPoint.position - startPoint.position;

        // 始点と終点の中間地点へアーム（オブジェクト）を移動
        transform.position = (startPoint.position + endPoint.position) * 0.5f;
        // 方向ベクトルからアーム角度を算出
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // 算出した角度にアームを回転させる
        transform.rotation = Quaternion.Euler(0, 0, angle);
        // 始点～終点の距離に合わせてアームの横長さを変更
        transform.localScale = new Vector3(dir.magnitude, 1f, 1f);
    }
}