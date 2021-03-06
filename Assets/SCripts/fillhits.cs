using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillhits : MonoBehaviour
{
    public player Player1;
    public player Player2;
    public Slider slider2;
    public Slider slider1;
    public Image fill;
    // Start is called before the first frame update
    private void Awake() {
         
         
          
    }

    // Update is called once per frame
    void Update()
    {
        slider2.value = Player2.p2h;
        slider1.value = Player1.p1h;
    
    }

}
