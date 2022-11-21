using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rb;
    bool _isRed, _canJump;

    Material mat;
    Color redColor, blueColor;

    [SerializeField] float _forwardSpeed;
    [SerializeField] float _jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        redColor = new Color(221 / 255f, 30 / 255f, 30 / 255f);
        blueColor = new Color(30 / 255f, 70 / 255f, 221 / 255f);

        _rb = GetComponent<Rigidbody>();
        mat = GetComponent<Renderer>().material;
        mat.color = redColor;

        _isRed = true;
    }

    public void swapColor()
    {
        mat.color = _isRed ? blueColor : redColor;
        _isRed = !_isRed;
    }

    public Rigidbody rigidBody
    {
        get { return _rb; }
    }

    public bool isRed
    {
        get { return _isRed; }
        set { _isRed = value; }
    }

    public bool canJump
    {
        get { return _canJump; }
        set { _canJump = value; }
    }

    public float forwardSpeed
    {
        get { return _forwardSpeed; }
    }

    public float jumpSpeed
    {
        get { return _jumpSpeed; }
    }

}
