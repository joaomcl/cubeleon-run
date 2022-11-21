using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSceneHandler : MonoBehaviour
{
    public Text scoreTextValue;
    public GameObject uiDataGroup;
    
    void Start()
    {
        scoreTextValue.text = "" + PlayerPrefs.GetInt("playerScore") + "/" + PlayerPrefs.GetInt("levelTotalCollectableItens");
        StartCoroutine(showScoreData());
    }

    IEnumerator showScoreData()
    {
        yield return new WaitForSeconds(2.5f);
        uiDataGroup.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }

}
