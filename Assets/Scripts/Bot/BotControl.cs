using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BotControl : MonoBehaviour
{
    private GameObject _Ball;
    private bool _CheckBallPos, _Check; //Kiểm tra vi trí của ball có thuộc nửa phần trên ko.
    float i, _BallPosX, _BallPosY;
    float j;
    public GameObject _BotChild;
    public SpriteRenderer _PlayerFace;
    public List<Sprite> _PlayerFaceImage;
    public static int FaceID;
    

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        SetPlayerFace();
        if (PlayerPrefs.GetString("isBall") == "Live")
        {
            _Ball = GameObject.FindGameObjectWithTag("Ball");
            _BallPosX = _Ball.transform.position.x;
            _BallPosY = _Ball.transform.position.y;
        }
        Move();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.0f, 2.0f), Mathf.Clamp(transform.position.y, 0.0f, 3.4f), 0);
    }
    void Move() // di chuyen Bot  khi ball ở sân nhà.
    {
        if(_BallPosY==1&& _BallPosX==0)
        {
            transform.DOMove(new Vector3(_BallPosX+Random.Range(-0.5f,0.5f), _BallPosY + 0.3f, 0), 1.0f);
        }
        if (BackGroundControl.i < 6)
        {
            if (_BallPosY > 0 && _BallPosY < 2.7f)
            {
                if (_BallPosX >= -2.0f && _BallPosX < 0)
                {
                    transform.DOMove(new Vector3(-1.33f, _BallPosY + 0.3f, 0), Random.Range(0.4f,0.8f));
                }
                else if (_BallPosX <= 2.0f && _BallPosX > 0)
                {
                    transform.DOMove(new Vector3(1.33f, _BallPosY + 0.3f, 0), Random.Range(0.4f, 0.8f));
                }
            }

            else if (_BallPosY > 2.7f && _BallPosY < 3.3f)
            {
                if (_BallPosX < -2.0f)
                {
                    transform.DOMove(new Vector3(-0.85f, _BallPosY + 0.3f, 0), Random.Range(0.4f, 0.8f));
                }
                else if (_BallPosX > 2.0f)
                {
                    transform.DOMove(new Vector3(0.85f, _BallPosY + 0.3f, 0), Random.Range(0.4f, 0.8f));
                }
            }
            else if (_BallPosY > 3.3f && _BallPosY < 3.5f)
            {
                if (_BallPosX < -2.0f)
                {
                    transform.DOMove(new Vector3(-1.05f, _BallPosY + 0.3f, 0), Random.Range(0.4f, 0.8f));
                }
                else if (_BallPosX > 2.0f)
                {
                    transform.DOMove(new Vector3(1.06f, _BallPosY + 0.3f, 0), Random.Range(0.4f, 0.8f));
                }
            }
            else if (_BallPosY > 3.7f)
            {
                if (_BallPosX < -2.5f || _BallPosX > -2.5f)
                {
                    transform.DOMove(new Vector3(0, 2.0f, 0), Random.Range(0.4f, 0.8f));
                }
            }
        }
        else if (BackGroundControl.i >= 6)
        {
            if (_BallPosY > 0 && _BallPosY < 1.5f)
            {
                if (_BallPosX < 0 && _BallPosX > -2.0f)  //lệch trái
                {
                    transform.DOMove(new Vector3(-1.16f, _BallPosY + 0.5f, 0), Random.Range(0.4f, 0.8f));
                }
                else if (_BallPosX > 0 && _BallPosX < 2.0f)
                {
                    transform.DOMove(new Vector3(1.16f, _BallPosY + 0.5f, 0), Random.Range(0.4f, 0.8f));
                }
            }
            else if (_BallPosY >= 1.5f && _BallPosY < 2.5f)
            {
                if (_BallPosX < 0 && _BallPosX > -2.0f)  //lệch trái
                {
                    transform.DOMove(new Vector3(-0.84f, _BallPosY + 0.5f, 0), Random.Range(0.4f, 0.8f));
                }
                else if (_BallPosX > 0 && _BallPosX < 2.0f) // lệch phải
                {
                    transform.DOMove(new Vector3(0.84f, _BallPosY + 0.5f, 0), Random.Range(0.4f, 0.8f));
                }
            }
            else if (_BallPosY >= 2.5f && _BallPosY < 3.3f)
            {
                if (_BallPosX < 0 && _BallPosX > -2.0f)  //lệch trái
                {
                    transform.DOMove(new Vector3(-0.3f, _BallPosY + 0.5f, 0), Random.Range(0.4f, 0.8f));
                }
                else if (_BallPosX > 0 && _BallPosX < 2.0f) // lệch phải
                {
                    transform.DOMove(new Vector3(0.3f, _BallPosY + 0.5f, 0), Random.Range(0.4f, 0.8f));
                }
                else if (_BallPosY >= 3.3f && _BallPosY < 3.5f)
                {
                    transform.DOMove(new Vector3(0.0f, _BallPosY + 0.5f, 0), Random.Range(0.4f, 0.8f));
                }
                else if (_BallPosY > 3.7f)
                {
                    if (_BallPosX < -2.5f || _BallPosX > -2.5f)
                    {
                        transform.DOMove(new Vector3(0, 2.0f, 0), Random.Range(0.4f, 0.8f));
                    }
                }

            }
        }
        if (_BallPosY < 0)
        {
            if (GameManager._RoungCount < 5)
            {
                if (_BallPosX < 0 && _BallPosX >-1.5f)
                {
                    transform.DOMove(new Vector3(_BallPosX + 0.5f, 1.0f, 0), 0.8f);
                }
                if (_BallPosX >= 0 && _BallPosX <1.5f)
                {
                    transform.DOMove(new Vector3(_BallPosX - 0.5f, 1.0f, 0), 0.8f);
                }
            }
            else if (GameManager._RoungCount >= 5 && GameManager._RoungCount < 10)
            {
                if (_BallPosX < 0 && _BallPosX > -1.5f)
                {
                    transform.DOMove(new Vector3(_BallPosX + 0.5f, 2.0f, 0), 0.8f);
                }
                if (_BallPosX >= 0 && _BallPosX < 1.5f)
                {
                    transform.DOMove(new Vector3(_BallPosX - 0.5f, 2.0f, 0), 0.8f);
                }
            }
            else if (GameManager._RoungCount >= 10.0f)
            {
                if (_BallPosX < 0 && _BallPosX>-1.5f)
                {
                    transform.DOMove(new Vector3(_BallPosX + 0.5f, 3.0f, 0), 0.8f);
                }
                if (_BallPosX >= 0 && _BallPosX<1.5f)
                {
                    transform.DOMove(new Vector3(_BallPosX - 0.5f, 3.0f, 0), 0.8f);
                }
            }
        }

    }
    private Vector2 _DirectionPlayertoBall(Vector2 PlayerPostion, Vector2 BallPosition)
    {
        Vector2 Direction = BallPosition - PlayerPostion;
        return Direction;
    }
    private void OnCollisionEnter2D(Collision2D _Col)
    {
        if (_Col.gameObject.tag == "Ball")
        {

            if (BackGroundControl.i < 6)
            {
                if (_BallPosY > 0 && _BallPosY < 2.9f && _BallPosX > -1.3f && _BallPosX < 1.3f)
                {
                    _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 150, ForceMode2D.Impulse);
                }
                else
                {
                    _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 150, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (_BallPosY > 0 && _BallPosY < 2.9f && _BallPosX > -1.0f && _BallPosX < 1.0f)
                {
                    _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 150, ForceMode2D.Impulse);
                }
                else
                {
                    _Col.gameObject.GetComponent<Rigidbody2D>().AddForce(_DirectionPlayertoBall(transform.position, _Col.transform.position) * 150, ForceMode2D.Impulse);
                }
                _Check = true;
            }
            if (BallControl._CheckStadiumCol)
            {
                Debug.Log(BallControl._CheckStadiumCol);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D _Col)
    {
        if (_Col.gameObject.tag == "Ball")
        {
            _Check = false;
        }
    }
    private void SetPlayerFace()
    {
        _PlayerFace.sprite = _PlayerFaceImage[FaceID];
    }
}
