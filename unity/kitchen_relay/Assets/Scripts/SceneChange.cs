using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("MainScene"); // ← シーン名は実際の名前に合わせる
    }
}
