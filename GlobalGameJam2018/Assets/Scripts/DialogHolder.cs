using UnityEngine;
using UnityEditor;
using System.IO;

[System.Serializable]
public class DialogHolder: MonoBehaviour {
  
    public string dialogue;
    private DialogManager dMan;

    public TextAsset textFile;
    public string[] textLines;

	void Start () {
        dMan = FindObjectOfType<DialogManager>();

        if (textFile != null) {
            textLines = (textFile.text.Split('\n'));
        }
	}
	
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //dMan.ShowBox(dialogue);
            }
        }
    }
    

}
