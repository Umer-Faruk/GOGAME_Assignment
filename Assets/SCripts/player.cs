using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public bulletfire bf;
    public Joystick _Joystick;
    public Joystick _Joystickr;
    public GameObject _player;
    public GameObject tope;
    public GameObject bullet;
    private GameObject _bullet;
    public GameObject toptip;
    // public GameObject wintext;
    public bullet bulleteff;

    public CameraShake CShake;

    public int p1h = 10;
    public int p2h = 10;
  

    void Start()
    {
        

        // bf = FindObjectOfType(typeof(bulletfire)) as bulletfire;
        bulleteff = FindObjectOfType(typeof(bullet)) as bullet;
        CShake = FindObjectOfType(typeof(CameraShake)) as CameraShake;
        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(Screen.width+" "+Screen.height);
        
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        if(p1h == 0 || p2h == 0)
        {
            Gameover();
        }
         
         //set bondrey for Tank
        
        Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);         
        pos.x = Mathf.Clamp01(pos.x);         
        pos.y = Mathf.Clamp01(pos.y);         
        transform.position = Camera.main.ViewportToWorldPoint(pos);  
        
        
        // Tanck move
        
        float turnlr = -10.0f * _Joystick.Horizontal  * Time.deltaTime;
        Vector3 rotation = transform.localRotation.eulerAngles;

        transform.localPosition += new Vector3(_Joystick.Horizontal, 0, _Joystick.Vertical) * 0.1f;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, turnlr);


        

        //rotetoin
        
        tope.transform.eulerAngles =  new Vector3(90,(Mathf.Atan2(_Joystickr.Horizontal, _Joystickr.Vertical)*60 ),0);
         
        if (_Joystickr.Horizontal + _Joystickr.Vertical > 0.5 || _Joystickr.Horizontal + _Joystickr.Vertical < -0.5)
        {
            if (!_bullet)
            {
                _bullet = Instantiate(bullet, toptip.transform.position, Quaternion.identity);
                _bullet.GetComponent<Rigidbody>().AddForce(toptip.transform.forward * 1000);

                // Debug.Log("fire bullet");
                
                
            }
            
       
        }

        if (_bullet)
        {
            if (_bullet.transform.position.y < -1)
            {    
                Destroy(_bullet);
            }
        }
 
        
        //back to exit game
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.gameObject.tag +collision.gameObject.tag);

        if (collision.gameObject.tag == "p1b")
        {
            p2hit();
            // bulleteff.showeff();
            CShake._shake();
            Destroy(collision.gameObject);
            
           
        }
        else if (collision.gameObject.tag == "p2b")
        {
            p1hit();
            // bulleteff.showeff();
            CShake._shake();
            Destroy(collision.gameObject);
            
        }
        
    }

    public void p1hit()
    {
        if (p1h > 0)
        {
            p1h -= 1;
            // Debug.Log("p1h:"+p1h);
        }
        else
        {
            //game over
            Gameover();
        }
        
    }

    public void p2hit()
    {
        if (p2h >0 )
        {
            p2h -= 1;
            // Debug.Log("p1h:"+p2h);
        }
        else
        {
            //game over
            Gameover();
        }
        
    }

    public void Gameover()
    {
        // DontDestroyOnLoad (wintext);
        
        PlayerPrefs.SetInt("p1h", p1h);
        PlayerPrefs.SetInt("p2h", p2h);
        
        SceneManager.LoadScene("GameOver");
    }
     
}

