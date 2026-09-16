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


    public bool rotateLeft; // 左回転フラグ
    public bool rotateRight; // 右回転フラグ

    private float startAngle;  // 回転制限の基準となる初期角度

    private void Start()
    {
        // シーン開始時の角度を保存する
        // この角度を基準値として±15°まで回転可能
        startAngle = GetNormalizedAngle(transform.eulerAngles.z);
    }

    private void Update()
    {
        // 現在角度を取得し、-180～180°へ補正(回転制限を正しく判定するため)
        float currentAngle = GetNormalizedAngle(transform.eulerAngles.z);

        // 初期角度から左方向へ15°まで回転
        if (rotateLeft &&
        currentAngle < startAngle + MAX_ROTATION_ANGLE)
        {
            transform.Rotate(0.0f, 0.0f, rotateSpeed * Time.deltaTime);
        }

        // 初期角度から右方向へ15°まで回転
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

    // UnityのEuler角は0～360°で返されるため、
    // 回転制限を判定しやすいように-180～180°へ変換する
    private float GetNormalizedAngle(float angle)
    {
        if (angle > HALF_CIRCLE_ANGLE)
        {
            angle -= FULL_CIRCLE_ANGLE;
        }

        return angle;
    }
}