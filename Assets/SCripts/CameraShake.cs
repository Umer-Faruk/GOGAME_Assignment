using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
     
          
          
 

     public float pow = 2f;
     public Camera maincamera;
     private Vector3 initialpos;

     public void _shake()
     {
          initialpos = maincamera.transform.position;
          InvokeRepeating("camerashaking",0f,0.05f);
          Invoke("stopshaking",0.5f);
          
     }

     void  camerashaking()
     {
          float x = Random.Range(-0.1f, 0.1f) * pow ;
          float y = Random.Range(-0.1f, 0.1f) * pow ;

          Vector3 caminpos = maincamera.transform.position;
          caminpos.x += x;
          caminpos.y += y;
          maincamera.transform.position = caminpos;

     }

     void stopshaking()
     {
          CancelInvoke("camerashaking");
          maincamera.transform.position = initialpos;

     }
      
}
