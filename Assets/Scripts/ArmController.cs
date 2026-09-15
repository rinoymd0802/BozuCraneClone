using UnityEngine;

public class ArmController : MonoBehaviour
{
    // 参照
    [SerializeField]
    private Transform armPivot; // Arm3Pivot

    [SerializeField]
    private Transform hammer; // Hammer

    // 変数
    private float defaultLength; // 初期長さ
    private float defaultScaleX; // 初期ScaleX

    private void Start()
    {
        // 初期Scale保存
        defaultScaleX = transform.localScale.x;

        // 初期長さ保存
        defaultLength = Vector2.Distance(
            armPivot.position,
            hammer.position);
    }

    private void Update()
    {
        // 長さ更新
        UpdateLength();
    }

    // アームの長さ更新
    private void UpdateLength()
    {
        // PivotからHammerまでの距離取得
        float length = Vector2.Distance(armPivot.position, hammer.position);

        // 現在のScale取得
        Vector3 scale = transform.localScale;

        // 長さ反映
        scale.x = defaultScaleX *(length / defaultLength);

        // Scale更新
        transform.localScale = scale;
    }
}