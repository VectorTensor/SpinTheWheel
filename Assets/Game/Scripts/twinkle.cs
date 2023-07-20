using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class twinkle : MonoBehaviour
{
    // Start is called before the first frame update

    Coroutine TwinkleCoroutine;
    void Start()
    {
    //    StartCoroutine(Twinkle());
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    void StartTheTwinkle(){

       TwinkleCoroutine =  StartCoroutine(Twinkle());


    }
    void StopTheTwinkle(){

          StopCoroutine(TwinkleCoroutine);


    }
    IEnumerator Twinkle()
    {

        float time = 0.1f;
        while(true){
            
           
            gameObject.GetComponent<Image>().color = new Color32(255,225,0,255);
           
            yield return new WaitForSeconds(time);
           
            gameObject.GetComponent<Image>().color = new Color32(120,120,0,255);

            
            yield return new WaitForSeconds(time);

            time += 0.07f;
            

        }
        
    }

    void OnEnable(){

        GameManager.onSpinningWheel += StartTheTwinkle;

        GameManager.onStopSpinningWheel += StopTheTwinkle;

    }

    void OnDisable(){

        GameManager.onSpinningWheel -= StartTheTwinkle;

        GameManager.onStopSpinningWheel -= StopTheTwinkle;

    }



}
