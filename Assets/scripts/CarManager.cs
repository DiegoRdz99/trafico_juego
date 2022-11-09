using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using static CarClass.car;
using CarClass;

public class CarManager : MonoBehaviour
{

public List<Car> CarList = new List<Car>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) 
        {
            CarList.Add(new Car());
        }

        GameObject newcar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newcar.transform.position = new Vector3(0f,0.8f,-4f);
        newcar.transform.localScale = new Vector3(0.5f,0.7f,1f);
        Car car = newcar.AddComponent(typeof(Car)) as Car;
    }

    // Update is called once per frame
    void Update()
    {
      int car_num = CarList.Count;
    }
}
