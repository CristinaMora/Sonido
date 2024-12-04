using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class RandomMusic : MonoBehaviour
{
    // Lista de eventos FMOD
    [SerializeField] private List<EventReference> fmodEvents;

    private System.Random random;
    // Instancia actual del evento
    private FMOD.Studio.EventInstance currentEventInstance;
    private StudioEventEmitter emitter;
	void Start()
	{
        random = new System.Random(System.Environment.TickCount + this.GetHashCode());
		// Inicia la reproducción aleatoria
		PlayRandomEvent();
    }

    private void PlayRandomEvent()
    {
        if (fmodEvents.Count == 0)
        {
            Debug.LogWarning("No hay eventos FMOD asignados.");
            return;
        }
		emitter = this.gameObject.AddComponent<StudioEventEmitter>();
		// Selecciona un evento aleatorio
		int randomIndex = random.Next(0, fmodEvents.Count);
        print(randomIndex);
        EventReference selectedEvent = fmodEvents[randomIndex];

        emitter.EventReference = selectedEvent;
        emitter.Play();
        
        emitter.EventStopTrigger = EmitterGameEvent.ObjectDestroy;
        // Crea y reproduce el evento
        currentEventInstance = RuntimeManager.CreateInstance(selectedEvent);
        //currentEventInstance.start();

        // Obtén la duración del evento y programa la siguiente reproducción
        currentEventInstance.getDescription(out var eventDescription);
        eventDescription.getLength(out int length); // Longitud en milisegundos

        if (length > 0)
        {
            // Reproduce el siguiente evento después de la duración actual
            Invoke(nameof(PlayRandomEvent), length / 1000f);
        }
        else
        {
            // Si no se puede determinar la duración, esperar un tiempo fijo
            Invoke(nameof(PlayRandomEvent), 5f);
        }
    }

    private void OnDestroy()
    {
        // Asegúrate de liberar el evento actual al destruir el objeto
        if (currentEventInstance.isValid())
        {
            currentEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            emitter.Stop();
            Destroy(emitter);
            currentEventInstance.release();
            
        }
    }

}
