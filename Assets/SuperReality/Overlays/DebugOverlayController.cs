using System;
using System.Web;
using UnityEngine;
using UnityEngine.UI;

namespace SuperReality.Overlays
{
    public class DebugOverlayController : MonoBehaviour
    {
        [SerializeField]
        private Text actionLogText;

        [SerializeField]
        private Text boolParameterValueText;

        [SerializeField]
        private Text intParameterValueText;

        [SerializeField]
        private Text floatParameterValueText;

        [SerializeField]
        private Text stringParameterValueText;

        [SerializeField]
        private Text vector2ParameterValueText;

        [SerializeField]
        private Text vector3ParameterValueText;

        [SerializeField]
        private Text colorParameterValueText;

        [SerializeField]
        private Image colorParameterRGBWell;

        [SerializeField]
        private RectTransform colorParameterAlphaMeterFill;

        [SerializeField]
        private RectTransform colorParameterAlphaMeterWell;

        [SerializeField]
        private Text color32ParameterValueText;

        [SerializeField]
        private Image color32ParameterRGBWell;

        [SerializeField]
        private RectTransform color32ParameterAlphaMeterFill;

        [SerializeField]
        private RectTransform color32ParameterAlphaMeterWell;

        private string m_receivedActionName;

        private int m_receivedActionCount;

        private float m_colorParameterAlphaMeterWellWidth;

        private float m_color32ParameterAlphaMeterWellWidth;

        private void Awake()
        {
            m_colorParameterAlphaMeterWellWidth = colorParameterAlphaMeterWell.sizeDelta.x;
            m_color32ParameterAlphaMeterWellWidth = color32ParameterAlphaMeterWell.sizeDelta.x;
        }

        public void UpdateActionLog(string actionName)
        {
            if (actionName == m_receivedActionName)
            {
                actionLogText.text = $"{m_receivedActionName} (x{++m_receivedActionCount})";
            }
            else
            {
                m_receivedActionName = actionName;
                m_receivedActionCount = 1;
                actionLogText.text = m_receivedActionName;
            }
        }

        public void UpdateBoolParameterValue(bool value)
        {
            boolParameterValueText.text = value ? "true" : "false";
        }

        public void UpdateIntParameterValue(int value)
        {
            intParameterValueText.text = value.ToString();
        }

        public void UpdateFloatParameterValue(float value)
        {
            floatParameterValueText.text = $"{value}";
        }

        public void UpdateStringParameterValue(string value)
        {
            stringParameterValueText.text = $"\"{HttpUtility.JavaScriptStringEncode(value)}\"";
        }

        public void UpdateVector2ParameterValue(Vector2 value)
        {
            vector2ParameterValueText.text = $"({value.x}, {value.y})";
        }

        public void UpdateVector3ParameterValue(Vector3 value)
        {
            vector3ParameterValueText.text = $"({value.x}, {value.y}, {value.z})";
        }

        public void UpdateColorParameterValue(Color value)
        {
            var hex = $"#{(int) (value.r * 255f):x2}{(int) (value.g * 255f):x2}{(int) (value.b * 255f):x2}{(int) (value.a * 255f):x2}";
            var rgba = $"({value.r}, {value.g}, {value.b}, {value.a})";
            colorParameterValueText.text = $"{hex} {rgba}";

            var wellColor = value;
            wellColor.a = 1f;
            colorParameterRGBWell.color = wellColor;

            var sizeDelta = colorParameterAlphaMeterWell.sizeDelta;
            sizeDelta.x = m_colorParameterAlphaMeterWellWidth * value.a;
            colorParameterAlphaMeterFill.sizeDelta = sizeDelta;
        }

        public void UpdateColor32ParameterValue(Color32 value)
        {
            var hex = $"#{value.r:x2}{value.g:x2}{value.b:x2}{value.a:x2}";
            var rgba = $"({value.r}, {value.g}, {value.b}, {value.a})";
            color32ParameterValueText.text = $"{hex} {rgba}";

            var wellColor = (Color) value;
            wellColor.a = 1f;
            color32ParameterRGBWell.color = wellColor;

            var sizeDelta = color32ParameterAlphaMeterWell.sizeDelta;
            sizeDelta.x = m_color32ParameterAlphaMeterWellWidth * (value.a / 255f);
            color32ParameterAlphaMeterFill.sizeDelta = sizeDelta;
        }
    }
}
