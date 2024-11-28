using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTrigger : MonoBehaviour
{
	public System.Action<Collider> OnPlayerTrigger; // Evento que notificar� a otros scripts

	private void OnTriggerEnter(Collider other)
	{
		// Verifica si el objeto est� en la capa "Player"
		if (other.gameObject.tag == "PlayerTag")
		{
			OnPlayerTrigger?.Invoke(other); // Notifica al script principal
		}
	}

	private void OnTriggerExit(Collider other)
	{
		// Tambi�n puedes manejar la salida del objeto
		if (other.gameObject.tag == "PlayerTag")
		{
			Debug.Log($"{other.name} sali� del trigger.");
		}
	}
}
