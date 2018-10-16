using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BallControl : MonoBehaviour
{
    private Vector3 _Pos, _PosWithStadium;
    private float _Force;
    private bool _CheckCollider, _CheckPlayerCol; // Kiểm tra va chạm với Goal,Kiem tra va chạm vớiplayer
    public GameObject _ScoreStar;
    private bool _CheckScorePlus; //kiem tra hàm cộng điểm.CHỉ cho +1 lần vì đặt trong update;
    public static bool _CheckIdle, _CheckStadiumCol; // kiem tra va cham vs stadium;
                                                     // Use this for initialization
    public GameObject _Ball;
    public List<Sprite> _BallList;
   public static  int i;
    private bool _Check; //kiem tra create ball trong update
    private int _ColCount; //đếm số lần va chạm với player ở phần sân nhà.
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_ColCount>50)
        {
            transform.DOMove(new Vector3(0, -1, -5), 0.8f);    
        }
        if (transform.position.y <= 0)
        {
            _ColCount = 0;
        }
        if (_CheckScorePlus)
        {
            _CheckScorePlus = false;
            SoundController.instance.Scored();
        }
        if(transform.position.y >5.0f || transform.position.y <-5.0f ||transform.position.x >4.0f || transform.position.x <-4.0f )
        {
            if(!_Check)
            {
                _Check = true;
                Instantiate(_Ball, new Vector3(0, 0, -5), Quaternion.identity);
                Destroy(gameObject, 1);
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
       // _Scored();
        GetComponent<SpriteRenderer>().sprite = _BallList[i];
        CheckBallPosition();  
    }
    private void OnCollisionEnter2D(Collision2D _Col)
    {
        //Kiểm tra khi nao cong diem
        if (_Col.gameObject.tag == "Goal")
        {
            SoundController.instance.Scored();
            Instantiate(_ScoreStar, transform.position, Quaternion.identity);

            _CheckCollider = true;
            if (transform.position.y > 0.0f && !_CheckScorePlus)  //+ điểm player 1
            {
                _CheckScorePlus = true;
                GameManager._ScorePlayer1++;
                GameManager._Score1 += 10;
                GameManager.isPlayer1Win = true;
            }
            else if (transform.position.y < 0.0f && !_CheckScorePlus) // cộng điểm player 2
            {
                _CheckScorePlus = true;
                GameManager._ScorePlayer2++;
                GameManager._Score2 += 10;
                Debug.Log("ScorePlayer2=" + GameManager._ScorePlayer2);
                GameManager.isPlayer1Win = false;
            }
            GameManager._isScored = true;
            PlayerPrefs.SetString("isBall", "Die");
            Destroy(gameObject);
        }
        if (_Col.gameObject.tag=="Stadium" || _Col.gameObject.tag== "Player")
        {
            SoundController.instance.BallSound();
        }
        if (_Col.gameObject.tag == "Player")
        {
            if(transform.position.y >0)
            {
                _ColCount++;
                Debug.Log(_ColCount);
            }
           
        }
    }
    private void OnCollisionExit2D(Collision2D _Col)
    {
        if (_Col.gameObject.tag == "Stadium")
        {
            _CheckStadiumCol = false;
        }
    }
    void CheckBallPosition() //ham kiem tra xem ball da qua Gon hay chua.
    {
        if (_CheckCollider)
        { 
            GameManager._isScored = true;
            PlayerPrefs.SetString("isBall", "Die");     
        }
    }
    void _Scored()
    {
        if(transform.position.y>4.2f && transform.position.x >-2.0f && transform.position.x <2.0f )
        {
           
            _CheckScorePlus = true;
            GameManager._ScorePlayer1++;
            GameManager._Score1 += 10;
            GameManager._isScored = true;
            PlayerPrefs.SetString("isBall", "Die");
            SoundController.instance.Scored();
            Instantiate(_ScoreStar, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(transform.position.y <-4.2f && transform.position.x > -2.0f && transform.position.x < 2.0f)
        {
           
            _CheckScorePlus = true;
            GameManager._ScorePlayer2++;
            GameManager._Score2 += 10;
            GameManager._isScored = true;
            PlayerPrefs.SetString("isBall", "Die");
            SoundController.instance.Scored();
            Instantiate(_ScoreStar, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
   
}
