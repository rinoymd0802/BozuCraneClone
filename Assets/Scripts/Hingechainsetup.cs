using UnityEngine;

/// <summary>
/// Arm1〜Arm3, Hammerなどのチェーンをまとめて管理するマネージャー。
/// ・エディタ上で一括してAnchorを自動設定
/// ・ゲーム内の「Play」ボタンが押された瞬間に、全RigidbodyをKinematic→Dynamicへ一斉切り替え
///
/// シーン開始直後は全リンクがKinematicのまま待機する。
/// これにより、プレイヤーはArm1の角度などを自由に決めてから
/// Playボタンを押して振り子運動をスタートできる。
/// </summary>
public class HingeChainSetup : MonoBehaviour
{
    [Tooltip("チェーンを構成するオブジェクト（Arm1, Arm2, Arm3, Hammerの順）")]
    public AutoHingeSetup[] chainLinks;

    [Header("位置決めフェーズ用スクリプト")]
    [Tooltip("Playボタンを押した瞬間に無効化する位置決め用スクリプト一覧\n（Arm1Controller, JointDragController, PivotController, ArmController, HammerControllerなど）")]
    public Behaviour[] setupPhaseComponents;

    private bool hasSwingStarted = false;

    [ContextMenu("Setup All Hinges")]
    public void SetupAll()
    {
        foreach (var link in chainLinks)
        {
            if (link != null) link.SetupAnchor();
        }
        Debug.Log($"[HingeChainSetup] {chainLinks.Length}個のリンクをセットアップしました。");
    }

    /// <summary>
    /// ゲーム内のPlayボタンのOnClick()からこのメソッドを呼ぶこと。
    /// 位置決めフェーズを終了し、物理演算による振り子運動を開始する。
    /// </summary>
    public void StartSwing()
    {
        if (hasSwingStarted) return; // 連打による二重実行を防止
        hasSwingStarted = true;

        SwitchAllToDynamic();
    }

    public bool HasSwingStarted => hasSwingStarted;

    private void SwitchAllToDynamic()
    {
        // ★追加: 位置決め用のコンポーネント（Arm1Controllerなど）を一斉に無効化する
        foreach (var comp in setupPhaseComponents)
        {
            if (comp != null) comp.enabled = false;
        }

        foreach (var link in chainLinks)
        {
            if (link == null) continue;

            if (link.remainKinematic) continue;

            var rb = link.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        Debug.Log("[HingeChainSetup] Playボタン押下: 位置決めスクリプトを停止し、全リンクをDynamicに切り替えました。");
    }
}