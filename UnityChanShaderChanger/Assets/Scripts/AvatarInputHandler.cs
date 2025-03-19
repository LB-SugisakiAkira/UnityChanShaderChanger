using UnityEngine;

public class AvatarInputHandler : MonoBehaviour
{
    public AvatarController avatarController;

    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックでドラッグ開始
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        if (isDragging)
        {
            // 左右の回転処理
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            avatarController.RotateAvatar(-deltaMouse.x);

            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) // 左クリックを離した時にドラッグ停止
        {
            isDragging = false;
        }

        // スクロールホイールでスケール
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            avatarController.ScaleAvatar(scroll);
        }
    }
}