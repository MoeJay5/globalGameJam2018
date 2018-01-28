using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;

    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;

    public LeaderManager player;

    public bool textBoxActive;
    public bool stopPlayerMovement;

    private void Start()
    {
        if (textBoxActive)
            enableTextBox();
        else
            disableTextBox();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
            endAtLine = textLines.Length - 1;
    }

    private void Update()
    {
        if (!textBoxActive)
            return;
        player.canMove = false;
        if (currentLine > endAtLine) {
            disableTextBox();
            return;
        }
        theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Return))
            currentLine++;
        
    }
    public void enableTextBox() {
        textBox.SetActive(true);
        textBoxActive = true;
        if (stopPlayerMovement)
            player.canMove = false;
    }
    public void disableTextBox() {
        textBox.SetActive(false);
        textBoxActive = false;
        player.canMove = true;
    }
    public void reloadScript(TextAsset asset)
    {
        if (asset != null)
        {
            Debug.Log("asset not null");
            textLines = new string[1];
            textLines = (asset.text.Split('\n'));

        }
    }
}
