using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;

    public LeaderManager player;

    private void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
            endAtLine = textLines.Length - 1;
    }

    private void Update()
    {
        dText.text = textLines[currentLine];

    }
    /*
    public bool dialogActive;

	void Start () {
        ReadString();
	}

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/story.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

    void Update () {
		if(dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.SetActive(false);
            dialogActive = false;
        }
	}

    public void ShowBox(string dialog)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialog;
    }
    */
}
