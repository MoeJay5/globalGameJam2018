using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {
    public TextAsset asset;
    public int startLine;
    public int endLine;
    public TextBoxManager textBox;
    public bool destroyWhenActivated;
    public bool requireButtonPress;
    private bool waitForPress;
    public AudioSource granny;
    // Use this for initialization
    void Start () {
        textBox = FindObjectOfType<TextBoxManager>();
        granny = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (waitForPress && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed E");
            textBox.reloadScript(asset);
            textBox.currentLine = startLine;
            textBox.endAtLine = endLine;
            textBox.enableTextBox();
            if (destroyWhenActivated)
                Destroy(this);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collider name" + collider.name);
        if (collider.name == "Player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            Debug.Log("collided with player");
            granny.Play();
            textBox.reloadScript(asset);
            textBox.currentLine = startLine;
            textBox.endAtLine = endLine;
            textBox.enableTextBox();
            if (destroyWhenActivated)
                Destroy(this);
        }

    }
    void onTriggerExit(Collider collider)
    {
        if (collider.name == "Player")
        {
            waitForPress = false;
        }
    }
}
