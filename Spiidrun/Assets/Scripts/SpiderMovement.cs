using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private bool isMove1Done = true;
    private bool isMove2Done = true;
    
    public Rigidbody leg1;
    public Rigidbody leg2;
    public Rigidbody leg3;
    public Rigidbody leg4;
    public Rigidbody leg5;
    public Rigidbody leg6;
    public Rigidbody leg7;
    public Rigidbody leg8;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Movement1());

        StartCoroutine(Movement2());
        
        // leg1.AddForce(Vector3.down);
        // leg4.AddForce(Vector3.down);
        // leg5.AddForce(Vector3.down);
        // leg8.AddForce(Vector3.down);
        // leg2.AddForce(Vector3.down);
        // leg3.AddForce(Vector3.down);
        // leg6.AddForce(Vector3.down);
        // leg7.AddForce(Vector3.down);
    }

    IEnumerator Movement1()
    {
        if (isMove1Done)
        {
            isMove1Done = false;
            leg1.AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            leg4.AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            leg5.AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            leg8.AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            yield return new WaitForSeconds(0.25f);
            leg1.AddForce(Vector3.down, ForceMode.Impulse);
            leg4.AddForce(Vector3.down, ForceMode.Impulse);
            leg5.AddForce(Vector3.down, ForceMode.Impulse);
            leg8.AddForce(Vector3.down, ForceMode.Impulse);
            yield return new WaitForSeconds(0.25f);
            leg1.AddForce(Vector3.back, ForceMode.Impulse);
            leg4.AddForce(Vector3.back, ForceMode.Impulse);
            leg5.AddForce(Vector3.back, ForceMode.Impulse);
            leg8.AddForce(Vector3.back, ForceMode.Impulse);
            yield return new WaitForSeconds(0.25f);
            isMove1Done = true;
        }
        
    }
    
    IEnumerator Movement2()
    {
        if (isMove2Done)
        {
            isMove2Done = false;
            leg2.AddForce(Vector3.back, ForceMode.Impulse);
            leg3.AddForce(Vector3.back, ForceMode.Impulse);
            leg6.AddForce(Vector3.back, ForceMode.Impulse);
            leg7.AddForce(Vector3.back, ForceMode.Impulse);
            yield return new WaitForSeconds(0.25f);
            leg2.AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            leg3.AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            leg6.AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            leg7.AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            yield return new WaitForSeconds(0.25f);
            leg2.AddForce(Vector3.down, ForceMode.Impulse);
            leg3.AddForce(Vector3.down, ForceMode.Impulse);
            leg6.AddForce(Vector3.down, ForceMode.Impulse);
            leg7.AddForce(Vector3.down, ForceMode.Impulse);
            yield return new WaitForSeconds(0.25f);
            isMove2Done = true;
        }
    }
}
