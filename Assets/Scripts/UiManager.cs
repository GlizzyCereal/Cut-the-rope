using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public Image[] stars;
    public Sprite fullStar;

    private int index = 0;

    private void Awake()
    {
        if(instance == null) instance = this;
        else gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddStar()
    {
        stars[index].sprite = fullStar;
        index++;
    }
}
