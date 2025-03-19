using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public GameObject avatarModel; // アバターのモデル

    private float moveSpeed = 0.05f; // 移動速度
    private float rotateSpeed = 1.2f; // 回転速度
    private float scaleSpeed = 0.1f; // 拡大縮小速度
    private float minScale = 1f; // 最小スケール
    private float maxScale = 15f; // 最大スケール

    // アバターの位置制限
    public float minX = -5f; // 最小X座標
    public float maxX = 5f; // 最大X座標
    public float minY = -3f; // 最小Y座標
    public float maxY = 3f; // 最大Y座標

    // 移動処理
    public void MoveAvatar(Vector3 direction)
    {
        Vector3 newPosition = avatarModel.transform.position + direction * moveSpeed;

        // 新しい位置を制限
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        avatarModel.transform.position = newPosition;
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