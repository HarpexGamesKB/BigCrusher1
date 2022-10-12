using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public void ToMenu()
    {
        ScreenFade.Instance.FadeIn(() => SceneManager.LoadScene(0));
    }
    public void Restart()
    {
        //ADS
        /*
        int thisLevel = PlayerPrefs.GetInt("CurrentLevel");
        if (thisLevel % 2 == 0)
        {
            Interstitial.Instance.ShowInterstitial();
        }*/
        Scene scene = SceneManager.GetActiveScene();
        ScreenFade.Instance.FadeIn(() => SceneManager.LoadScene(scene.name));
    }
    public void LoadScene(int num)
    {
        PlayerPrefs.SetInt("CurrentLevel", num - 1);
        ScreenFade.Instance.FadeIn(() => SceneManager.LoadScene(1));
    }
    public void LoadNextLvl()
    {/*
        int next = PlayerPrefs.GetInt("CurrentLevel") + 1;
        if (next < ProgressManager.Instance.MaximumLevel)
        {
            PlayerPrefs.SetInt("CurrentLevel", next);
            Restart();
        }
        else
        {
            ToMenu();
        }*/
    }
    public void LoadLastUnlockedLevel()
    {
        int unlocked = PlayerPrefs.GetInt("LevelUnlocked");//0
        /*
        if (unlocked < ProgressManager.Instance.MaximumLevel)
        {
            PlayerPrefs.SetInt("CurrentLevel", unlocked);
        }*/
            
        ScreenFade.Instance.FadeIn(() => SceneManager.LoadScene(1));
    }
    
}
