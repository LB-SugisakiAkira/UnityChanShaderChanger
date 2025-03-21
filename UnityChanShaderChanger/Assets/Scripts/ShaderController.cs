using UnityEngine;
using TMPro;

public class ShaderController : MonoBehaviour
{
    public GameObject avatarModel; // アバターのモデル
    public Shader[] shaders; // 使用するシェーダーの配列
    public TextMeshProUGUI shaderName;  // 選択中のシェーダーを表示するテキスト

    private int currentShaderIndex = 0; // 現在のシェーダーインデックス

    private void Start()
    {
        shaderName.text = shaders[currentShaderIndex].name;
    }

    // シェーダーを変更
    public void ChangeShader()
    {
        currentShaderIndex = (currentShaderIndex + 1) % shaders.Length; // 次のシェーダーにインデックスを更新
        shaderName.text = shaders[currentShaderIndex].name;

        // avatarModel内の全ての SkinnedMeshRenderer を取得
        SkinnedMeshRenderer[] renderers = avatarModel.GetComponentsInChildren<SkinnedMeshRenderer>();

        // すべての SkinnedMeshRenderer にマテリアルを適用
        foreach (var renderer in renderers)
        {
            if (renderer != null)
            {
                foreach (var material in renderer.materials)
                {
                    material.shader = shaders[currentShaderIndex];
                }
            }
        }
    }
}