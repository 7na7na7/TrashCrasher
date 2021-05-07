using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCtrl : MonoBehaviour
{
    public float boosterRegenSpeed = 1f;
    public float boosterCost = 5f;
    public Slider boosterGage;
    public GameObject booster;
    public float boosterForce=5f;
    public bool isBack = true;
    public bool isFront = true;
    public float jumpForce = 1000;
    public float qeSpeed = 50f;
    public float MaxSpeed = 10f;
    public Rigidbody2D carRigidbody;
    public Rigidbody2D backTire, frontTire;
    private float movement;
  //  public float carTorque = 10;
    public float speed = 10;

    void Start()
    {
        FindObjectOfType<CameraManager>().target = this.gameObject;
    }

 
    void Update()
    {
        boosterGage.value += boosterRegenSpeed * Time.deltaTime;
        movement = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Q))
        {
            if(!isBack && !isFront) 
                carRigidbody.AddTorque(qeSpeed*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if(!isBack && !isFront) 
                carRigidbody.AddTorque(-qeSpeed*Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isBack && isFront)
            {
                carRigidbody.AddForce(transform.up*jumpForce);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (boosterGage.value > 0)
            {
                boosterGage.value -= Time.deltaTime * boosterCost;   
                carRigidbody.AddForce(transform.right*boosterForce*Time.deltaTime);
            }
           
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            booster.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            booster.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (carRigidbody.velocity.x <= MaxSpeed)
        {
            if(isBack) 
                backTire.AddTorque(-movement*speed*Time.fixedDeltaTime);
            if(isFront) 
                frontTire.AddTorque(-movement*speed*Time.fixedDeltaTime);   
        }
        //carRigidbody.AddTorque(-movement*carTorque*speed*Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            GoldManager.instance.GetGold(10);
        }
    }

    public void StopMovement()
    {
        carRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
