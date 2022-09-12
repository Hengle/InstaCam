using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    public bool photoMode;
    public bool readingMode;

    public GameObject panelPhotoMode;
    public GameObject panelGamePlay;
    public GameObject panelText;

    MessagesManager messagesManager;
    
	public TextMeshProUGUI noteBooK;
    
    void Start()
    {
	    messagesManager = GameObject.Find("MessagesManager").GetComponent<MessagesManager>();
	    Draw();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape)) Pause();

        if (Input.GetButtonDown("Camera")&&!isPaused&&!readingMode&&Globals.playerKeys.Contains("Camera"))
        {
            PhotoMode();
        }

    }

    public void Pause()
    {
        isPaused = !isPaused;
    }

	public void Draw()
	{
		noteBooK.text="";
		for(int i=0;i<=Globals.ToDoList.Count-1;i++)
		{
			noteBooK.text+="-"+Globals.ToDoList[i]+"\n";
		    
		}
	}

    public void ToDoList()
    {
        for(int i=0; i < Globals.ToDoList.Count; i++)
        {
        	Debug.Log(Globals.currentObjective);
	        if (Globals.currentObjective == Globals.ToDoList[i])
            {
		        Debug.Log("FotoGuardada");
		        Globals.ToDoList.Remove(Globals.currentObjective);
            }
        }
    }


    public void PhotoMode()
    {
        if (photoMode)
        {
            
            panelGamePlay.SetActive(true); 
            panelPhotoMode.GetComponent<Animator>().Play("FadeOut");

        }
        else if (!photoMode)
        {
            panelPhotoMode.GetComponent<Animator>().Play("FadeIn");
            panelGamePlay.SetActive(false);
            
        }
        photoMode = !photoMode;
    }

    public void ReadingMode()
    {
        readingMode = true;
	    panelText.SetActive(true);
	    panelGamePlay.SetActive(false);
        messagesManager.StartDialogue();
    }

   

    public void Save()
    {
       /* if (Input.GetKeyDown(KeyCode.G))
        {
            SaveManager.SavePlayerData();
            Debug.Log("DatosGuardados");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerData playerData = SaveManager.LoadPlayerData();

            if (playerData == null) return;
                Globals.photo_index = playerData.photo_index;
            Debug.Log("DatosCargados");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SaveManager.DeletePlayerData();
            Debug.Log("DatosBorrados");
        }*/
    }

}
