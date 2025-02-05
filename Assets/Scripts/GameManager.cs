using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private CircleController CircleController;
    private KnifeManager knifeManager;
    [SerializeField] GameObject startMenuUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gamePauseUI;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI maxLevelText;
    [SerializeField] TextMeshProUGUI maxHitText;
    public bool isGamePaused ;
    public int level;
    // Start is called before the first frame update
    private void Awake()
    {
        CircleController = FindObjectOfType<CircleController>();
        knifeManager = FindObjectOfType<KnifeManager>();
    }
    void Start()
    {
        CircleController.enabled = false;
        isGamePaused = true;
        level = 1;
        startMenuUI.SetActive(true);
        //GameStart();
        maxLevelText.text = PlayerPrefs.GetInt("MaxLevel", 0).ToString();
        maxHitText.text = PlayerPrefs.GetInt("MaxHit", 0).ToString(); 


    }

    

    public void NextLevel()
    {
        knifeManager.ClearKnifes();
        level++;
        knifeManager.CreateKnife();
        levelText.text = level.ToString();
        CircleController.rotatespeed += 5;
        knifeManager.knifeMoveSpeed += 100;

    }

    public void GameStart()
    {
        startMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
        CircleController.enabled = true;
        knifeManager.CreateKnife();
    }
    public void GamePause()
    {
        gamePauseUI.SetActive(true);    
        Time.timeScale = 0;
        isGamePaused = true;
        CircleController.enabled = false;
         
    }

    public void GameResume()
    {
        gamePauseUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }
    public void GameRestart()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
         
        if (knifeManager.hit > PlayerPrefs.GetInt("MaxHit", 0))
        {
            PlayerPrefs.SetInt("MaxHit", knifeManager.hit);
        }
        if (level > PlayerPrefs.GetInt("MaxLevel", 0))
        {
            PlayerPrefs.SetInt("MaxLevel", level);
        }
    }
}
