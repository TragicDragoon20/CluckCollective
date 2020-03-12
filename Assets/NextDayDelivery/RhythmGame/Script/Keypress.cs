using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypress : MonoBehaviour
{
    public int noteSpawnCounter = 0;
    public int failLevel = 4;
    public string keyType;
    private string[][] letterlayers = new string[][] { new[] { "z", "v", "m"},
        new[] { "a", "f", "j", "l", " "},
        new[] { "q", "r", "u", "p"} };
    public Sprite sprite;

    private void Start()
    {
        if (((IList)letterlayers[0]).Contains(keyType))
        {
            transform.Translate(Vector2.down / 4);
        }

        if (((IList)letterlayers[2]).Contains(keyType))
        {
            transform.Translate(Vector2.up / 4);
        }
    }

    void Update()
    {
        transform.Translate(-Vector3.right * Time.deltaTime / 2); //Moves each note left slowly
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>(); //references the textmeshpro script attatched to the note
        textmeshPro.SetText(keyType); //sets the text attatched to textmesh pro as the key type, which is assigned in the spawner script

        if (keyType == "space") //and if the input key is equal to the keytype
        {
            textmeshPro.fontSize = 5;
            textmeshPro.SetText("¦");
        }
    }
    void OnTriggerStay2D(Collider2D hit) //If the notes collide with a 2D collider
    {
        if (Input.GetKey(keyType)) //and if the input key is equal to the keytype
        {
            noteSpawnCounter += 1;
            Debug.Log(noteSpawnCounter);
            Destroy(gameObject); //destroy the note object
        }

        if (hit.CompareTag("RhythmFail"))
        {
            failLevel = failLevel - 1;
            noteSpawnCounter += 1;
            Debug.Log(failLevel);
            Destroy(gameObject);
        }
    }
}