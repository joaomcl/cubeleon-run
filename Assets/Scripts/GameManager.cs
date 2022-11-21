using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    int _collectableScore;
    int _totalCollectableItens;
    bool _playerFailed;

    SlowMotion _slowMotion;
    LevelAnimations _levelAnimations;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
    }

    public int collectableScore
    {
        get { return _collectableScore; }
    }

    public int totalCollectableItens
    {
        get { return _totalCollectableItens; }
    }

    public void increaseTotalCollectableItens()
    {
        _totalCollectableItens++;
    }

    public bool playerFailed
    {
        get { return _playerFailed; }
    }

    public void increaseCollectableScore()
    {
        _collectableScore++;
    }

    public SlowMotion slowMotion
    {
        set { _slowMotion = value; }
    }

    public LevelAnimations levelAnimations
    {
        set { _levelAnimations = value; }
    }

    public void startSlowMotion()
    {
        _slowMotion.start();
    }

    public void stopSlowMotion()
    {
        _slowMotion.stop();
    }

    public void failed()
    {
        _playerFailed = true;
        StartCoroutine(restartLevel());
    }

    IEnumerator restartLevel()
    {
        _slowMotion.start();
        yield return new WaitForSeconds(_slowMotion.slowMotionTimescale);
        _levelAnimations.transitionFail.SetTrigger("Start");
        yield return new WaitForSeconds(_slowMotion.slowMotionTimescale * 2);
        _slowMotion.stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void succeeded()
    {
        StartCoroutine(showScoreScene());
    }

    IEnumerator showScoreScene()
    {
        _slowMotion.start(0.1f);

        PlayerPrefs.SetInt("playerScore", _collectableScore);
        PlayerPrefs.SetInt("levelTotalCollectableItens", _totalCollectableItens);
        
        _levelAnimations.transitionSuccess.SetTrigger("StartFinishAnimation");
        yield return new WaitForSeconds(0.5f);

        _slowMotion.stop();
        SceneManager.LoadScene(1);
    }
}