
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRepeat : BaseButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
