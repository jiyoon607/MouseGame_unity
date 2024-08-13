using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public void Level1_Button()
    {
        SceneManager.LoadScene("1stLevel");
        SoundSetting.SoundConverter();
    }
}
