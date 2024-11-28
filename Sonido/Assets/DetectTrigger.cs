using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTrigger : MonoBehaviour
{
	public System.Action<Collider> OnPlayerTrigger; // Evento que notificará a otros scripts

	private void OnTriggerEnter(Collider other)
	{
		// Verifica si el objeto está en la capa "Player"
		if (other.gameObject.tag == "PlayerTag")
		{
			OnPlayerTrigger?.Invoke(other); // Notifica al script principal
		}
	}

	private void OnTriggerExit(Collider other)
	{
		// También puedes manejar la salida del objeto
		if (other.gameObject.tag == "PlayerTag")
		{
			Debug.Log($"{other.name} salió del trigger.");
		}
	}
}
