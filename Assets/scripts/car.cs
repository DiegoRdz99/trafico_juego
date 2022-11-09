using System.Collections;
using System.Collections.Generic;
// using System.Math;
using static System.Math;
using UnityEngine;

namespace CarClass{

// public class Car : MonoBehaviour
public class Car : MonoBehaviour
{
    
 public float amax = 0.1f; // maximum acceleration
 public float smax = 5f; // 
 public float positionx = 0f;
 public float positiony = -5f;

//////////////////////////////////////////////////////////////////////////////
// Private properties
//////////////////////////////////////////////////////////////////////////////
  private CarManager road;
  private float length = 1f; // vehicle length
  private float s0 = 1f; // desired distance between vehicles (bumper to bumper)
  private float T = 1f; // reaction time / delay
  private float v_max = 10f; // max desired speed
  private float a_max = 1.44f; // max acceleration
  private float b_max = 4.61f; // comfortable acceleration
  private float sqrt_ab;
//////////////////////////////////////////////////////////////////////////////
// Public properties
//////////////////////////////////////////////////////////////////////////////
  public float x; // car position
  public float v; // car velocity
  public float a; // acceleration
  public float alpha;
  public bool stopped;

// public Car(CarManager current_road)
public Car()
{
  // road = current_road;
  length = 1f;
  s0 = 1f;
  T = 1f;
  v_max = 10f;
  a_max = 1.44f;
  b_max = 4.61f;
}


 public GameObject Distance; //

 float speed;
 float acceleration;

bool near; 

 float moveY;
 void Start(){  
    speed = Random.Range(1f,10f);
    acceleration = Random.Range(0f,0.1f);
    sqrt_ab = 2f*(float)(PI*Sqrt(this.a_max * this.b_max));
    x = 0f; // car position
    v = this.v_max; // car velocity
    a = 0f; // acceleration
    stopped = false;
 }

 void Update(){
    near = Physics.CheckSphere(Distance.transform.position, this.s0, LayerMask.GetMask("car"));

    if (this.v + this.a*Time.deltaTime < 0){
      this.x -= 1/2*this.v*this.v/this.a; // Instead of (this.v)^2, which doesn't exist in C#, or Math.Pow(this.v,2), which is way slower for integer powers
      this.v = 0f;
    }
    else {
      this.v += this.a/Time.deltaTime;
      this.x += this.v*Time.deltaTime + this.a*Time.deltaTime*Time.deltaTime/2;
    }

    alpha = 0;


    

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
