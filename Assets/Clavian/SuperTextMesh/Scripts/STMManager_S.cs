using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STMManager_S : MonoBehaviour
{
    public SuperTextMesh stmText;
    public string newText;
    public string hexcode = "FFFFFF";
    public int fontId = 0;
    public float textSize;
    public Color testColor;
    public List<Font> fontList = new List<Font>();

    private void Start()
    {
        stmText.gameObject.SetActive(false);
        StartCoroutine(TurnTextOn());
    }

    IEnumerator TurnTextOn()
    {
        yield return new WaitForSeconds(1f);
        stmText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Jitter(newText);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Wave(newText);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetText(newText);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SetHexcode(hexcode);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeSpecificTextColor(newText);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            SetItalic(newText);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SetBold(newText);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeFont(fontId);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeFontSize(textSize);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeTextColor(testColor);
        }
    }

    /// <summary>
    /// Set the Text to a new one
    /// </summary>
    /// <param name="text"></param>
    public void SetText (string text)
    {
        stmText.text = text;
    }

    /// <summary>
    /// Control the Jitter effects
    /// Removes jitter if word already has it, and applys if it doesn't have it
    /// </summary>
    /// <param name="lookFor"></param>
    public void Jitter(string lookFor)
    {
        //Handle all the text
        if (lookFor == "*")
        {
            if (stmText.text.Contains("<j>"))
            {
                stmText.text = stmText.text.Replace("<j>", "");

                if (stmText.text.Contains("</j>"))
                    stmText.text = stmText.text.Replace("</j>", "");
            }

            else
                stmText.text = "<j>" + stmText.text + "</j>";
        }

        //Handle specific text
        else
        {
            if (stmText.text.Contains(lookFor))
            {
                if (stmText.text.Contains("<j>" + lookFor + "</j>"))
                    stmText.text = stmText.text.Replace("<j>" + lookFor + "</j>", lookFor);

                else
                    stmText.text = stmText.text.Replace(lookFor, "<j>" + lookFor + "</j>");
            }
        }
    }

    /// <summary>
    /// Control the Wave effects
    /// Removes wave if word already has it, and applys if it doesn't have it
    /// </summary>
    /// <param name="lookFor"></param>
    public void Wave(string lookFor)
    {
        //Handle all the text
        if (lookFor == "*")
        {
            if (stmText.text.Contains("<w>"))
            {
                stmText.text = stmText.text.Replace("<w>", "");

                if (stmText.text.Contains("</w>"))
                    stmText.text = stmText.text.Replace("</w>", "");
            }

            else
                stmText.text = "<w>" + stmText.text + "</w>";
        }

        //Handle specific text
        else
        {
            if (stmText.text.Contains(lookFor))
            {
                if (stmText.text.Contains("<w>" + lookFor + "</w>"))
                    stmText.text = stmText.text.Replace("<w>" + lookFor + "</w>", lookFor);

                else
                    stmText.text = stmText.text.Replace(lookFor, "<w>" + lookFor + "</w>");
            }
        }
    }

    public void SetHexcode(string code) { hexcode = code; }    

    public void ChangeSpecificTextColor(string lookFor)
    {
        if (stmText.text.Contains(lookFor))
        {
            if (stmText.text.Contains("<c=" + hexcode + ">" + lookFor + "</c>"))
                stmText.text = stmText.text.Replace("<c=" + hexcode + ">" + lookFor + "</c>", lookFor);

            else
                stmText.text = stmText.text.Replace(lookFor, "<c=" + hexcode + ">" + lookFor + "</c>");
        }
    }

    public void ChangeTextColor(Color newColor) { stmText.color = newColor; }

    public void SetItalic(string lookFor)
    {
        if (lookFor == "*")
        {
            if (stmText.text.Contains("<i>"))
            {
                stmText.text = stmText.text.Replace("<i>", "");

                if (stmText.text.Contains("</i>"))
                    stmText.text = stmText.text.Replace("</i>", "");
            }

            else
                stmText.text = "<i>" + stmText.text + "</i>";
        }

        else
        {
            if (stmText.text.Contains(lookFor))
            {
                if (stmText.text.Contains("<i>" + lookFor + "</i>"))
                    stmText.text = stmText.text.Replace("<i>" + lookFor + "</i>", lookFor);

                else
                    stmText.text = stmText.text.Replace(lookFor, "<i>" + lookFor + "</i>");
            }
        }
    }

    public void SetBold(string lookFor)
    {
        if (lookFor == "*")
        {
            if (stmText.text.Contains("<b>"))
            {
                stmText.text = stmText.text.Replace("<b>", "");

                if (stmText.text.Contains("</b>"))
                    stmText.text = stmText.text.Replace("</b>", "");
            }

            else
                stmText.text = "<b>" + stmText.text + "</b>";
        }
        else
        {
            if (stmText.text.Contains(lookFor))
            {
                if (stmText.text.Contains("<b>" + lookFor + "</b>"))
                    stmText.text = stmText.text.Replace("<b>" + lookFor + "</b>", lookFor);

                else
                    stmText.text = stmText.text.Replace(lookFor, "<b>" + lookFor + "</b>");
            }
        }
    }

    public void ChangeFont(int id)
    {
        if (id < fontList.Count)
        {
            stmText.font = fontList[id];
            stmText.text = stmText.text;
        }
    }

    public void ChangeFontSize(float size)
    {
        stmText.size = size;
        stmText.text = stmText.text;
    }

    string[] options = new string[] { "<b>", "<i>", "<" };

    void GetEffect(int id, string text)
    {
        SetEffect(text, id);
    }

    public void SetEffect(string lookFor, int id)
    {
        string temp = options[id].Insert(0, "/");

        if (lookFor == options[id])
        {
            if (stmText.text.Contains(options[id]))
            {
                stmText.text = stmText.text.Replace(options[id], "");

                if (stmText.text.Contains(temp))
                    stmText.text = stmText.text.Replace(temp, "");
            }

            else
                stmText.text = options[id] + stmText.text + temp;
        }
        else
        {
            if (stmText.text.Contains(lookFor))
            {
                if (stmText.text.Contains("<b>" + lookFor + "</b>"))
                    stmText.text = stmText.text.Replace("<b>" + lookFor + "</b>", lookFor);

                else
                    stmText.text = stmText.text.Replace(lookFor, "<b>" + lookFor + "</b>");
            }
        }
    }
}
