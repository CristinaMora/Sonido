using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySoundWhenTriggered : MonoBehaviour
{
	[SerializeField]
	public GameObject triggerGameObject;

	private DetectTrigger triggerNotifier;

	void Start()
	{
		// Obt�n el TriggerNotifier del triggerGameObject
		triggerNotifier = triggerGameObject.GetComponent<DetectTrigger>();

		if (triggerNotifier != null)
		{
			// Suscr�bete al evento
			triggerNotifier.OnPlayerTrigger += HandlePlayerTrigger;
		}
	}

	private void HandlePlayerTrigger(Collider playerCollider)
	{
		// Maneja la interacci�n con el objeto de la capa Player
		Debug.Log($"El trigger detect� al jugador: {playerCollider.name}");
		if(!this.gameObject.GetComponent<StudioEventEmitter>().IsPlaying()) this.gameObject.GetComponent<StudioEventEmitter>().Play();
	}

	private void OnDestroy()
	{
		// Desuscr�bete del evento para evitar errores si se destruye el objeto
		if (triggerNotifier != null)
		{
			triggerNotifier.OnPlayerTrigger -= HandlePlayerTrigger;
		}
	}
}
