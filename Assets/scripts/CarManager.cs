using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using static CarClass.car;
using CarClass;

public class CarManager : MonoBehaviour
{

public List<car> CarList = new List<car>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) 
        {
            CarList.Add(new car());
        }
    }

    // Update is called once per frame
    void Update()
    {
      int car_num = CarList.Count;
    }
}
