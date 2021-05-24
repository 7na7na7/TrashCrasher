using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCtrl : MonoBehaviour
{
    private bool canBoost = false;
    public float boosterRegenSpeed = 6f;
    public float boosterCost = 30f;
    public Slider boosterGage;
    public GameObject booster;
    public float boosterForce=3000f;
    public bool isBack = true;
    public bool isFront = true;
    public float jumpForce = 2000;
    public float qeSpeed = 700f;
    public float MaxSpeed = 15f;
    public float MaxFule = 100f;
    public float MinusFule = 8f;
   public Rigidbody2D carRigidbody;
    public Rigidbody2D backTire, frontTire;
    private float movement;
    public CircleCollider2D[] tireCollider2D;
   
    public SpriteRenderer[] carSprites;
    public Sprite[] tireSprites;
    public Sprite[] boosterSprites;
    public Sprite[] bumperSprite;
  //  public float carTorque = 10;
    public float speed = 200;

    void Start()
    {
        FindObjectOfType<CameraManager>().target = this.gameObject;
        SetPerformance();
        SetSprite();
    }

    void SetPerformance()
    {
        tireCollider2D[0].radius += GameManager.instance.upgradecount[GameManager.instance.tireKey] * 0.06f;
        tireCollider2D[1].radius += GameManager.instance.upgradecount[GameManager.instance.tireKey] * 0.06f;

        speed += GameManager.instance.upgradecount[GameManager.instance.timingbelt] * 150;
        qeSpeed *= GameManager.instance.upgradecount[GameManager.instance.timingbelt] + 1;
        MaxSpeed *= GameManager.instance.upgradecount[GameManager.instance.timingbelt] + 1;

        MinusFule -= GameManager.instance.upgradecount[GameManager.instance.timingbelt] * 3;

        boosterForce += GameManager.instance.upgradecount[GameManager.instance.boosterKey] * 1000;
        boosterCost -= GameManager.instance.upgradecount[GameManager.instance.boosterKey] * 3;
    }

    void SetSprite()
    {
        carSprites[0].sprite = tireSprites[GameManager.instance.tireKey];
        carSprites[1].sprite = tireSprites[GameManager.instance.tireKey];

        carSprites[2].sprite = boosterSprites[GameManager.instance.boosterKey];
       
        carSprites[3].sprite = bumperSprite[GameManager.instance.bumperKey];
    }

    void Update()
    {
        bool fueld = false;
        GameObject.Find("FuleSlider").GetComponent<Slider>().value= MaxFule;
        if (MaxFule <= 0)
        {
            GameManager.instance.GameOver();
        }

        movement = Input.GetAxis("Horizontal");
        if (movement != 0)
        {
            MaxFule -= MinusFule * Time.deltaTime;
            fueld = true;
        }
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
            canBoost = true;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (boosterGage.value > 0.1f)
            {
                if (canBoost)
                {
                    booster.SetActive(true);
                    boosterGage.value -= Time.deltaTime * boosterCost;   
                    carRigidbody.AddForce(transform.right*boosterForce*Time.deltaTime);
                }
            }
            else
            {
                canBoost = false;
                booster.SetActive(false);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            booster.SetActive(false);
        }
    }

    public void SetForce(float force, Vector2 pos)
    {
        Vector2 dir = (Vector3)pos - transform.position;
        dir.Normalize();
        carRigidbody.velocity = new Vector2(carRigidbody.velocity.x - force * dir.x, carRigidbody.velocity.y - (force * dir.y) / 2);
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
        if (other.CompareTag("End"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public void StopMovement()
    {
        carRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
