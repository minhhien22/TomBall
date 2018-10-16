using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGroundControl : MonoBehaviour
{
    public GameObject[] Stadium;
    private List<GameObject> StadiumList;
    public Vector3 _StadiumPos;
    public static BackGroundControl _Trans;

   public static  int i;

    // Use this for initialization
    private void Awake()
    {
        StadiumList = new List<GameObject>();
        _Trans = this;
    }
    void Start()
    {
        GameObject FirstStadium = Instantiate(Stadium[0], _StadiumPos, Quaternion.identity);
        StadiumList.Add(FirstStadium);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateStadium()
    {
        i = Random.Range(0, Stadium.Length);
        GameObject _Stadium = Instantiate(Stadium[i], _StadiumPos, Quaternion.identity);
        _Stadium.transform.position = new Vector3(5.64f, 0, 0);
        StadiumList.Add(_Stadium);
    }
    public void MoveIn() //move the statdim in  the screen
    {
        StadiumList[1].transform.DOMoveX(0.0f, 0.5f);
    }
    public void MoveOut()
    {
        StadiumList[0].transform.DOMoveX(-5.64f, 0.5f);
        Destroy(StadiumList[0].gameObject,0.6f);
        StadiumList.Remove(StadiumList[0]);
    }

}
