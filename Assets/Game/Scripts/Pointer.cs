using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject PointerObject;

    Coroutine Animation;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPointerMotion(){
        
        Animation = StartCoroutine(ToMotion());

    }
void StopPointerMotion(){
        
        StopCoroutine(Animation);

    }
    IEnumerator ToMotion()
    {

        float x = Spinner.spinDuration/8;
        float timedel = Spinner.spinDuration/8;
        float angle = 40;
        while(true){
            DOTween.Kill(12);
            DOTween.Kill(13);
            PointerObject.transform.DORotate(new Vector3(0,0,-angle),0.2f).OnComplete(()=> {
                 PointerObject.transform.DORotate(new Vector3(0,0,0),0.3f).SetId(13);
            }).SetId(12);
           
            yield return new WaitForSeconds(timedel);
            
            timedel +=0.02f;
            angle -= 2f;

        }
        
    }


    void OnEnable(){
        GameManager.onSpinningWheel += StartPointerMotion;
        Spinner.OnSpinCompletete += StopPointerMotion;

    }

    void OnDisable(){
        GameManager.onSpinningWheel -= StartPointerMotion;
        Spinner.OnSpinCompletete -= StopPointerMotion;

    }
  

   




  
}
