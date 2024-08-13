using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI_Buttons : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject SoundButton;
    public Sprite[] SoundImg;
    public void OnClick_StartButton()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    public void OnClick_ExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // 어플리케이션 종료
        #endif
    }
    public void OnClick_SettingsButton()
    {
        if(SettingsPanel.activeSelf == false)
        {
            SettingsPanel.SetActive(true);
        }
        else if(SettingsPanel.activeSelf == true)
        {
            SettingsPanel.SetActive(false);
        }
    }
    public void OnClick_Settings_ExitButton()
    {
        SettingsPanel.SetActive(false);
    }
    public void OnClick_SoundButton()
    {
        SoundSetting.SoundPlayer();
        if(SoundSetting.isSoundOn == false)
        {
            SoundButton.GetComponent<Image>().sprite = SoundImg[0];
        }
        else if(SoundSetting.isSoundOn == true)
        {
            SoundButton.GetComponent<Image>().sprite = SoundImg[1];
        }
    }
}
