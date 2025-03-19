using UnityEngine;

public class AvatarInputHandler : MonoBehaviour
{
    public AvatarController avatarController;

    private Vector3 lastMousePosition;

    void Update()
    {
        // 左クリックが押されている
        if (Input.GetMouseButton(0))
        {
            // 左右に回転
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            avatarController.RotateAvatar(-deltaMouse.x); // ドラッグの方向と同じにするためマイナスをかける
        }

        // 中ボタンが押されている
        if (Input.GetMouseButton(2))
        {
            // 上下左右に移動
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            avatarController.MoveAvatar(new Vector3(deltaMouse.x, deltaMouse.y, 0));
        }

        // スクロールホイールでスケール
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            avatarController.ScaleAvatar(scroll);
        }

        // マウスの位置を更新
        lastMousePosition = Input.mousePosition;
    }
}