using UnityEngine;

public class Arm1Controller : MonoBehaviour
{
    // 定数
    private const float MAX_ROTATION_ANGLE = 15.0f; // Arm1の回転可能角度
    private const float FULL_CIRCLE_ANGLE = 360.0f; // 1周の角度
    private const float HALF_CIRCLE_ANGLE = FULL_CIRCLE_ANGLE / 2; // 半周の角度

    // 変数
    [SerializeField]
    private float rotateSpeed = 50.0f; // 回転速度
    // PivotRotationZ
    [SerializeField]
    private float pivotZAngle = 25.0f;


    public bool rotateLeft; // 左回転フラグ
    public bool rotateRight; // 右回転フラグ

    private float startAngle; // 開始時の角度

    private void Start()
    {
        // PivotのZ初期値設定
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, pivotZAngle);
        // 回転制限の基準となる開始角度を保存
        startAngle = GetNormalizedAngle(transform.eulerAngles.z);
    }

    private void Update()
    {
        // 現在角度を取得し、-180～180°へ補正
        float currentAngle = GetNormalizedAngle(transform.eulerAngles.z);

        // 左回転
        if (rotateLeft &&
            currentAngle < startAngle + MAX_ROTATION_ANGLE)
        {
            transform.Rotate(0.0f, 0.0f, rotateSpeed * Time.deltaTime);
        }

        // 右回転
        if (rotateRight &&
            currentAngle > startAngle - MAX_ROTATION_ANGLE)
        {
            transform.Rotate(0.0f, 0.0f, -rotateSpeed * Time.deltaTime);
        }
    }

    // 左回転開始
    public void StartRotateLeft()
    {
        rotateLeft = true;
    }

    // 左回転終了
    public void StopRotateLeft()
    {
        rotateLeft = false;
    }

    // 右回転開始
    public void StartRotateRight()
    {
        rotateRight = true;
    }

    // 右回転終了
    public void StopRotateRight()
    {
        rotateRight = false;
    }

    // 角度補正
    private float GetNormalizedAngle(float angle)
    {
        if (angle > HALF_CIRCLE_ANGLE)
        {
            angle -= FULL_CIRCLE_ANGLE;
        }

        return angle;
    }
}