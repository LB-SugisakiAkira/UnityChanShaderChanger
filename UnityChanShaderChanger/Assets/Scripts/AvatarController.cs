using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public GameObject avatarModel; // アバターのモデル
    private float moveSpeed = 0.1f; // 移動速度
    private float rotateSpeed = 0.5f; // 回転速度
    private float scaleSpeed = 0.1f; // 拡大縮小速度
    private float minScale = 0.5f; // 最小スケール
    private float maxScale = 3f; // 最大スケール

    // 移動処理
    public void MoveAvatar(Vector3 direction)
    {
        avatarModel.transform.position += direction * moveSpeed;
    }

    // 回転処理
    public void RotateAvatar(float angle)
    {
        avatarModel.transform.Rotate(0, angle * rotateSpeed, 0);
    }

    // スケール処理
    public void ScaleAvatar(float scaleFactor)
    {
        Vector3 currentScale = avatarModel.transform.localScale;
        float newScale = Mathf.Clamp(currentScale.x + scaleFactor * scaleSpeed, minScale, maxScale);
        avatarModel.transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}