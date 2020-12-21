using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SuperReality.Overlays
{
    public class OverlayManager : MonoBehaviour
    {
        private readonly Dictionary<string, List<ActionRelay>> m_actionRelays = new Dictionary<string, List<ActionRelay>>();

        private readonly Dictionary<string, List<BoolParameterRelay>> m_boolRelays = new Dictionary<string, List<BoolParameterRelay>>();

        private readonly Dictionary<string, List<IntParameterRelay>> m_intRelays = new Dictionary<string, List<IntParameterRelay>>();

        private readonly Dictionary<string, List<FloatParameterRelay>> m_floatRelays = new Dictionary<string, List<FloatParameterRelay>>();

        private readonly Dictionary<string, List<StringParameterRelay>> m_stringRelays = new Dictionary<string, List<StringParameterRelay>>();

        private readonly Dictionary<string, List<Vector2ParameterRelay>> m_vector2Relays = new Dictionary<string, List<Vector2ParameterRelay>>();

        private readonly Dictionary<string, List<Vector3ParameterRelay>> m_vector3Relays = new Dictionary<string, List<Vector3ParameterRelay>>();

        private readonly Dictionary<string, List<ColorParameterRelay>> m_colorRelays = new Dictionary<string, List<ColorParameterRelay>>();

        private readonly Dictionary<string, List<Color32ParameterRelay>> m_color32Relays = new Dictionary<string, List<Color32ParameterRelay>>();

        [DllImport("__Internal")]
        private static extern void SendBufferedMessages();

        private void Awake()
        {
            // TODO: read window.SuperReality preload data

            CacheActionRelays(m_actionRelays);

            CacheParameterRelays<bool, BoolParameterRelay>(m_boolRelays);
            CacheParameterRelays<int, IntParameterRelay>(m_intRelays);
            CacheParameterRelays<float, FloatParameterRelay>(m_floatRelays);
            CacheParameterRelays<string, StringParameterRelay>(m_stringRelays);
            CacheParameterRelays<Vector2, Vector2ParameterRelay>(m_vector2Relays);
            CacheParameterRelays<Vector3, Vector3ParameterRelay>(m_vector3Relays);
            CacheParameterRelays<Color, ColorParameterRelay>(m_colorRelays);
            CacheParameterRelays<Color32, Color32ParameterRelay>(m_color32Relays);

            SendBufferedMessages();
        }

        private void CacheActionRelays(Dictionary<string, List<ActionRelay>> relayCache)
        {
            var relays = FindObjectsOfType<ActionRelay>();
            foreach (var relay in relays)
            {
                if (!relayCache.ContainsKey(relay.ActionName))
                {
                    Debug.Log($"Found action relay: {relay.ActionName}");
                    relayCache.Add(relay.ActionName, new List<ActionRelay>());
                }
                relayCache[relay.ActionName].Add(relay);
            }
        }

        private void CacheParameterRelays<TValue, TRelay>(Dictionary<string, List<TRelay>> relayCache) where TRelay : ParameterRelay<TValue>
        {
            var relays = FindObjectsOfType<TRelay>();
            foreach (var relay in relays)
            {
                if (!relayCache.ContainsKey(relay.ParameterName))
                {
                    Debug.Log($"Found parameter relay: {relay.ParameterName}");
                    relayCache.Add(relay.ParameterName, new List<TRelay>());
                }
                relayCache[relay.ParameterName].Add(relay);
            }
        }

        public void RunAction(string actionName)
        {
            if (m_actionRelays.TryGetValue(actionName, out var actionRelays))
            {
                for (var i = actionRelays.Count - 1; i >= 0; i--)
                {
                    actionRelays[i].ReceiveAction();
                }
            }
        }

        private void SetParameter<TValue, TParameter, TRelay>(Dictionary<string, List<TRelay>> relays, string jsonData) where TParameter : Parameter<TValue> where TRelay : ParameterRelay<TValue>
        {
            var data = JsonUtility.FromJson<TParameter>(jsonData);
            Debug.Log($"Setting {typeof(TValue)} parameter: {data.name} = {data.value}");
            if (relays.TryGetValue(data.name, out var matchingRelays))
            {
                foreach (var relay in matchingRelays)
                {
                    relay.SetParameter(data.value);
                }
            }
        }

        public void SetBoolParameter(string jsonData)
        {
            SetParameter<bool, BoolParameter, BoolParameterRelay>(m_boolRelays, jsonData);
        }

        public void SetIntParameter(string jsonData)
        {
            SetParameter<int, IntParameter, IntParameterRelay>(m_intRelays, jsonData);
        }

        public void SetFloatParameter(string jsonData)
        {
            SetParameter<float, FloatParameter, FloatParameterRelay>(m_floatRelays, jsonData);
        }

        public void SetStringParameter(string jsonData)
        {
            SetParameter<string, StringParameter, StringParameterRelay>(m_stringRelays, jsonData);
        }

        public void SetVector2Parameter(string jsonData)
        {
            SetParameter<Vector2, Vector2Parameter, Vector2ParameterRelay>(m_vector2Relays, jsonData);
        }

        public void SetVector3Parameter(string jsonData)
        {
            SetParameter<Vector3, Vector3Parameter, Vector3ParameterRelay>(m_vector3Relays, jsonData);
        }

        public void SetColorParameter(string jsonData)
        {
            SetParameter<Color, ColorParameter, ColorParameterRelay>(m_colorRelays, jsonData);
        }

        public void SetColor32Parameter(string jsonData)
        {
            SetParameter<Color32, Color32Parameter, Color32ParameterRelay>(m_color32Relays, jsonData);
        }
    }
}
