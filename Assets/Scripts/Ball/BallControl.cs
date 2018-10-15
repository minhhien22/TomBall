using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallControl : MonoBehaviour
{
    private Vector3 _Pos, _PosWithStadium;
    private float _Force;
    private bool _CheckCollider, _CheckPlayerCol; // Kiểm tra va chạm với Goal,Kiem tra va chạm vớiplayer
    public GameObject _ScoreStar;
    private bool _CheckScorePlus; //kiem tra hàm cộng điểm.CHỉ cho +1 lần vì đặt trong update;
    public static bool _CheckIdle, _CheckStadiumCol; // kiem tra va cham vs stadium;
                                                     // Use this for initialization
    void Start()
    {
        StartCoroutine(isIdle());
    }

    // Update is called once per frame
    void Update()
    {
        //Mathf.Clamp(transform.position.x, -2.32f, 2.32f);
        //Mathf.Clamp(transform.position.y, 4.71f, 4.71f);
        CheckBallPosition();
        //if (transform.position.x > 2.0f || transform.position.x < -2.0f)
        //{
        //    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1) * 50);

        //}
        //if (transform.position.x > 3.3f && transform.position.x < -2.0f)
        //{
        //    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1) * 50);
        //}
        //if (transform.position.x > 3.3f && transform.position.x > 2.0f)
        //{
        //    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1) * 50);
        //}
    }
    private void OnCollisionEnter2D(Collision2D _Col)
    {
        // Kiểm tra khi nao cong diem
        if (_Col.gameObject.tag == "Goal")
        {
            Instantiate(_ScoreStar, transform.position, Quaternion.identity);

            _CheckCollider = true;
            if (transform.position.y > 0.0f && !_CheckScorePlus)  //+ điểm player 2
            {
                _CheckScorePlus = true;
                GameManager._ScorePlayer1++;
                GameManager._Score1 += 10;
            }
            else if (transform.position.y < 0.0f && !_CheckScorePlus) // cộng điểm player 1
            {
                _CheckScorePlus = true;
                GameManager._ScorePlayer2++;
                GameManager._Score2 += 10;
                Debug.Log("ScorePlayer2=" + GameManager._ScorePlayer2);
            }
            GameManager._isScored = true;
            PlayerPrefs.SetString("isBall", "Die");
            Destroy(gameObject);
        }
        //if(_Col.gameObject.tag=="Player")
        //{
        //    _CheckPlayerCol = true;
        //    if(_Col.gameObject.transform.position.y < transform.position.y)
        //    {
        //        if (transform.position.x > 2.0f) 
        //        {
        //            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 2) * 100);
        //            _CheckPlayerCol = true;
        //        }
        //        else if(transform.position.x < -2.0f)
        //        {
        //            GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 2) * 100);
        //            _CheckPlayerCol = true;
        //        }
        //    }
        //    else if(_Col.gameObject.transform.position.y >transform.position.y)
        //    {
        //        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.RandomRange(-5,-1),Random.Range(-5,-1) * 100));
        //    }
        //}
       // if (_Col.gameObject.tag == "Stadium")
       // {
       //     _CheckStadiumCol = true;
       //     GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, -1), Random.Range(-5, -1) * 10));
      //  }
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
            //Instantiate(_ScoreStar, transform.position, Quaternion.identity);
            GameManager._isScored = true;
            PlayerPrefs.SetString("isBall", "Die");
           // Destroy(gameObject);
        }
    }
    IEnumerator isIdle() //kiem tra ball co đứnng yên 1 chỗ không.
    {
        while (true)
        {
            Vector3 TempPos = transform.position;
            yield return new WaitForSeconds(0.5f);
            if (_CheckPlayerCol)
            {
                if (transform.position == TempPos)
                {
                    _CheckIdle = true;
                    Debug.Log("here");
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 1, 0) * 50);
                }
                else
                { _CheckIdle = false; }
            }

        }
    }

}
