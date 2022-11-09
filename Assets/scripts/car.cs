using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarClass{

public class car : MonoBehaviour
{
    
 public float amax = 0.1f;
 public float smax = 5f;
 public float positionx = 0f;
 public float positiony = -5f;


 public GameObject Distance; //

 float speed;
 float acceleration;

bool near; 

 float moveY;
 void Start(){  
    speed = Random.Range(1f,10f);
    acceleration = Random.Range(0f,0.1f);
 }

 void Update(){
    near = Physics.CheckSphere(Distance.transform.position, .2f, LayerMask.GetMask("car"));

    if (near){
      speed -= acceleration * Time.deltaTime;
      acceleration = amax * ( 1 - ( speed / smax ) * ( speed / smax ));
    }
    else{
      speed += acceleration * Time.deltaTime;
      acceleration = amax * ( 1 - ( speed / smax ) * ( speed / smax ) * ( speed / smax ) * ( speed / smax ));
    }

    if (speed > smax){
      speed = smax;
    }
    if (speed < 0){
      speed = 0;
    }
    transform.Translate(Vector3.forward * ( speed * Time.deltaTime + acceleration * Time.deltaTime * Time.deltaTime));


    if (transform.position.z > 10f ){
        transform.position = new Vector3(0f,0.69f,-11f);
    }

 }

}
}
