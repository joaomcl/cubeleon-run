using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnimations : MonoBehaviour
{
    [SerializeField] Animator _transitionFail;
    [SerializeField] Animator _transitionSuccess;

    private void Awake()
    {
        GameManager.Instance.levelAnimations = this; // make script accessible to GameManager singleton instance
    }

    public Animator transitionFail
    {
        get { return _transitionFail; }
    }

    public Animator transitionSuccess
    {
        get { return _transitionSuccess; }
    }
}
