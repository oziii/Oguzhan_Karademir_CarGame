using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
	public void RightPress()
	{
		GameObject car = GetComponent<GameManager>().cuurentCar;
		car.GetComponent<Car>().gasButton = true;
		car.GetComponent<Car>().steeringAmount = -1;
	}

	public void LeftPress()
	{
		GameObject car = GetComponent<GameManager>().cuurentCar;
		car.GetComponent<Car>().gasButton = true;
		car.GetComponent<Car>().steeringAmount = 1;
	}
	public void RightUnPress()
	{
		GameObject car = GetComponent<GameManager>().cuurentCar;
		car.GetComponent<Car>().steeringAmount = 0;
	}

	public void LeftUnPress()
	{
		GameObject car = GetComponent<GameManager>().cuurentCar;
		car.GetComponent<Car>().steeringAmount = 0;
	}

}
