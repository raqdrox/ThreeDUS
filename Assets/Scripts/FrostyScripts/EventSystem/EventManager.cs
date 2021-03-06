using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;
//Manager
//Server Side
namespace FrostyScripts.Events
{
    public enum GameEvents
    {
        GAME_START,
        ROUND_START,
        ROUND_END,
        MEETING_CALLED,
        MEETING_START,
        MEETING_END,
        CREWMATE_TASK_STARTED,
        CREWMATE_TASK_ENDED,
        IMP_KILL,
        IMP_SABOTAGE,
        GAME_END
    }

    public class EventManager : NetworkBehaviour
    {
        private Dictionary<GameEvents, UnityEvent<MEventData>> eventDictionary;
        private static EventManager eventManager;
        public static EventManager instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                    if (!eventManager)
                    {
                        Debug.LogError("No active EventManager Script on a GameObject in the Scene.");
                    }
                    else
                    {
                        eventManager.Init();
                    }
                }
                return eventManager;
            }
        }

        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<GameEvents, UnityEvent<MEventData>>();
            }
        }

        public static void StartListening(GameEvents eventType, UnityAction<MEventData> listener)
        {
            UnityEvent<MEventData> thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent<MEventData>();
                thisEvent.AddListener(listener);
                instance.eventDictionary.Add(eventType, thisEvent);
            }
        }


        public static void StopListening(GameEvents eventType, UnityAction<MEventData> listener)
        {
            if (eventManager == null) return;
            UnityEvent<MEventData> thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void TriggerEvent(GameEvents eventType, MEventData data = null)
        {
            UnityEvent<MEventData> thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.Invoke(data);
                Debug.Log(thisEvent);
            }
        }



    }
}