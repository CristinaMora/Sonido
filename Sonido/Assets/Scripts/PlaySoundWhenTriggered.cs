using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySoundWhenTriggered : MonoBehaviour
{
	[SerializeField]
	public GameObject triggerGameObject;
    [SerializeField]
    public bool  triggerexit = false;
    private DetectTrigger triggerNotifier;

	void Start()
	{
		// Obtén el TriggerNotifier del triggerGameObject
		triggerNotifier = triggerGameObject.GetComponent<DetectTrigger>();

		if (triggerNotifier != null)
		{
			// Suscríbete al evento
			triggerNotifier.OnPlayerTrigger += HandlePlayerTrigger;
		}
	}

	private void HandlePlayerTrigger(Collider playerCollider)
	{
		// Maneja la interacción con el objeto de la capa Player
		Debug.Log($"El trigger detectó al jugador: {playerCollider.name}");
		if (!this.gameObject.GetComponent<StudioEventEmitter>().IsPlaying()) this.gameObject.GetComponent<StudioEventEmitter>().Play();
		else if (triggerexit && this.gameObject.GetComponent<StudioEventEmitter>().IsPlaying()) { 
			this.gameObject.GetComponent<StudioEventEmitter>().Stop();
			Debug.Log("stop");
		}
    }

	private void OnDestroy()
	{
		// Desuscríbete del evento para evitar errores si se destruye el objeto
		if (triggerNotifier != null)
		{
			triggerNotifier.OnPlayerTrigger -= HandlePlayerTrigger;
		}
	}
}
