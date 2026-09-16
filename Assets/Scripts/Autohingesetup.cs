using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class AutoHingeSetup : MonoBehaviour
{
    [Tooltip("このオブジェクトが接続する相手側のRigidbody2D（例: 1つ前のArm）")]
    public Rigidbody2D connectedBody;

    [Tooltip("自分側の接続点マーカー（このオブジェクトの子Transform）")]
    public Transform pivotPoint;

    [Tooltip("相手側の接続点マーカー（connectedBody側の子Transform）")]
    public Transform connectedPivotPoint;

    // ★追加: HingeChainSetupでエラーになっていた変数を定義
    [Tooltip("Playボタンを押した後もKinematicのままにするか（BaseやArm1など動かさない場合用）")]
    public bool remainKinematic = false;

    // ★追加: ゲーム実行中の位置決めフェーズでもリアルタイムにジョイントを更新するため
    private HingeChainSetup manager;

    private void Start()
    {
        // マネージャーを探しておく
        manager = Object.FindFirstObjectByType<HingeChainSetup>();
    }

    private void Update()
    {
        // ★追加: まだ物理（スイング）が始まっていない「位置決めフェーズ」の間は、
        // 毎フレームAnchorの位置を計算し直す（これでマウスで伸ばしても関節がズレない）
        if (manager != null && !manager.HasSwingStarted)
        {
            SetupAnchor();
        }
    }

    [ContextMenu("Setup Hinge Anchor")]
    public void SetupAnchor()
    {
        var hinge = GetComponent<HingeJoint2D>();

        if (hinge == null || pivotPoint == null || connectedPivotPoint == null || connectedBody == null)
        {
            return; // 警告でコンソールが埋まるのを防ぐため、Updateでの実行時はシンプルにリターン
        }

        hinge.connectedBody = connectedBody;
        hinge.enableCollision = false;

        hinge.anchor = transform.InverseTransformPoint(pivotPoint.position);
        hinge.connectedAnchor = connectedBody.transform.InverseTransformPoint(connectedPivotPoint.position);
    }
}
