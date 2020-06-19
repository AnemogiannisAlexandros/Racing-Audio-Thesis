using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;

public class CustomPause : MonoBehaviour
{
	public bool pause = false;
	public KeyCode key = KeyCode.P;
	public VPVehicleController controller;

	bool m_pausedState = false;
	Vector3 m_velocity = Vector3.zero;
	Vector3 m_angularVelocity = Vector3.zero;

	private void Start()
	{
		controller = FindObjectOfType<VPVehicleController>();
	}

	void FixedUpdate()
	{
		if (!controller.initialized) return;

		if (pause && !m_pausedState)
		{
			m_velocity = controller.cachedRigidbody.velocity;
			m_angularVelocity = controller.cachedRigidbody.angularVelocity;

			m_pausedState = true;
			controller.cachedRigidbody.isKinematic = true;
			controller.paused = true;
		}
		else
		if (!pause && m_pausedState)
		{
			controller.cachedRigidbody.isKinematic = false;
			controller.paused = false;

			controller.cachedRigidbody.velocity = m_velocity;
			controller.cachedRigidbody.angularVelocity = m_angularVelocity;

			m_pausedState = false;
		}
	}


	void Update()
	{
		if (DataManager.Instance.isCounting)
		{
			pause = false;
		}
		else
		{
			pause = true;
		}
	}
}
