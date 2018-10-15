using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StadiumControl : MonoBehaviour
{
    public static StadiumControl _Trans;
    private bool _CheckPos; // Kiem tra vi tri cua stadium da di ra ngoai man hinh chua.
    // Use this for initialization
    private void Awake()
    {
        _Trans = this;
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -5.5f)
        { Destroy(gameObject, 1.5f); }
        NextStadium();

    }
    public void NextStadium()
    {
        if (GameManager.GameTracking)
        {
            if (transform.position.x < 1.0f && !_CheckPos)
            {
                transform.DOMoveX(-5.64f, 0.5f);
            }

        }
    }
}



