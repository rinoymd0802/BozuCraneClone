using UnityEngine;

public class PlayButtonManager : MonoBehaviour
{
    // このボタンを押したときに物理演算を開始するオブジェクト
    public Rigidbody2D jointA;
    public Rigidbody2D jointB;
    public Rigidbody2D tip;

    bool IsPlay; // Play中かどうか

    // Play前の状態を保存
    private Vector3 jointAPos;
    private Vector3 jointBPos;
    private Vector3 tipPos;

    private Quaternion jointARot;
    private Quaternion jointBRot;
    private Quaternion tipRot;


    public void Start()
    {
        IsPlay = false;
    }

    // ボタン押されたとき
    public void OnPlayButtonClicked()
    {
        if ((!IsPlay))
        {
            // 現在位置と回転を保存
            jointAPos = jointA.transform.position;
            jointBPos = jointB.transform.position;
            tipPos = tip.transform.position;

            jointARot = jointA.transform.rotation;
            jointBRot = jointB.transform.rotation;
            tipRot = tip.transform.rotation;

            // KinematicからDynamicへ変更し物理演算を開始
            jointA.bodyType = RigidbodyType2D.Dynamic;
            jointB.bodyType = RigidbodyType2D.Dynamic;
            tip.bodyType = RigidbodyType2D.Dynamic;

            // ゲーム中に切り替え
            IsPlay = true;
        }
        else if(IsPlay)
        {
            // DynamicからKinematicへ変更し物理演算を終了
            jointA.bodyType = RigidbodyType2D.Kinematic;
            jointB.bodyType = RigidbodyType2D.Kinematic;
            tip.bodyType = RigidbodyType2D.Kinematic;

            // 保存した位置と回転へ戻す
            jointA.transform.position = jointAPos;
            jointB.transform.position = jointBPos;
            tip.transform.position = tipPos;

            jointA.transform.rotation = jointARot;
            jointB.transform.rotation = jointBRot;
            tip.transform.rotation = tipRot;

            // 速度の停止
            jointA.linearVelocity = Vector2.zero;
            jointB.linearVelocity = Vector2.zero;
            tip.linearVelocity = Vector2.zero;

            jointA.angularVelocity = 0f;
            jointB.angularVelocity = 0f;
            tip.angularVelocity = 0f;

            // ゲーム外に切り替え
            IsPlay = false;

        }
    }

}