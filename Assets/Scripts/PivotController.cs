using UnityEngine;

public class PivotController : MonoBehaviour
{
    // 参照
    [SerializeField]
    private Transform hammerPivot; // ドラッグ用ターゲット

    [SerializeField]
    private Transform arm3; // Arm3

    private float defaultLength; // 初期長さ
    private float defaultScaleX; // 初期ScaleX

    private void Start()
    {
        // Arm3の初期Scale保存
        defaultScaleX = arm3.localScale.x;

        // 初期長さ保存
        defaultLength =
            Vector2.Distance(
                transform.position,
                hammerPivot.position);
    }

    private void Update()
    {
        UpdateArm3();
    }

    // Arm3の角度と長さ更新
    private void UpdateArm3()
    {
        // Pivotからターゲットへの方向
        Vector2 direction =
            hammerPivot.position - transform.position;

        // 距離取得
        float length = direction.magnitude;

        // 角度計算
        float angle =
            Mathf.Atan2(direction.y, direction.x)
            * Mathf.Rad2Deg;

        // Pivot回転
        transform.rotation =
            Quaternion.Euler(
                0.0f,
                0.0f,
                angle);

        // Arm3のScale取得
        Vector3 scale =
            arm3.localScale;

        // 長さ変更
        scale.x =
            defaultScaleX *
            (length / defaultLength);

        // Scale更新
        arm3.localScale = scale;
    }
}