using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] stars;
    public Sprite starOn;
    
    // Replace single panel with separate panels
    public GameObject victoryPanel;  // Panel for when monster eats the candy
    public GameObject losePanel;     // Panel for when candy dies
    
    // Star display in each panel
    public Image[] victoryStars;
    public Image[] loseStars;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        // Hide panels at start
        if (victoryPanel != null)
            victoryPanel.SetActive(false);
        
        if (losePanel != null)
            losePanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void starGet(int starCount)
    {
        int count = Mathf.Min(starCount, stars.Length);
        
        for (int i = 0; i < count; i++)
        {
            stars[i].sprite = starOn;
        }
    }
    
    public void ShowEndGame(int starsCollected)
    {
        // Show lose panel
        if (losePanel != null)
        {
            losePanel.SetActive(true);
            
            // Update stars in the lose panel
            for (int i = 0; i < loseStars.Length; i++)
            {
                loseStars[i].sprite = (i < starsCollected) ? starOn : loseStars[i].sprite;
            }
            
        }
    }

    public void ShowVictory(int starsCollected)
    {
        // Show victory panel
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            
            // Update stars in the victory panel
            for (int i = 0; i < victoryStars.Length; i++)
            {
                victoryStars[i].sprite = (i < starsCollected) ? starOn : victoryStars[i].sprite;
            }
        }
    }
    
    // Optional methods to access each panel's button functionality
    public void ReturnToMainMenu()
    {
        // Replace "MainMenu" with your main menu scene name
        SceneManager.LoadScene("MainMenu");
    }
    
    public void NextLevel()
    {
        // Load the next level
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextLevel);
        else
            ReturnToMainMenu(); // Return to menu if this was the last level
    }
}