using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindManager : MonoBehaviour
{
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text forward, left, right, backward, jump, sprint, crouch;
    public GameObject curKey;
    public Color32 changed = new Color32(39, 171, 249, 255);
    public Color32 selected = new Color32(239, 116, 36, 255);
    void Start()
    {
        keys.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
        keys.Add("Sprint", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift")));
        keys.Add("Crouch", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "LeftControl")));

        forward.text = keys["Forward"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        backward.text = keys["Backward"].ToString();
        jump.text = keys["Jump"].ToString();
        sprint.text = keys["Sprint"].ToString();
        crouch.text = keys["Crouch"].ToString();
    }

    void OnGUI()
    {
        if (curKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[curKey.name] = e.keyCode;
                curKey.GetComponentInChildren<Text>().text = e.keyCode.ToString();
                curKey.GetComponent<Image>().color = changed;
                curKey = null;
            }
        }
    }
    public void ChangeKey(GameObject clicked)
    {
        if (curKey != null)
        {
            curKey.GetComponent<Image>().color = changed;
        }
        curKey = clicked;
        curKey.GetComponent<Image>().color = selected;
    }
    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
}
