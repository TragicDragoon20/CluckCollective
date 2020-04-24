using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypress : MonoBehaviour
{
    public GameObject space;
    public string keyType;
    private string[][] letterlayers = new string[][] { new[] { "z", "v", "m"},
        new[] { "a", "f", "j", "l", " "},
        new[] { "q", "r", "u", "p"} };

    private void Start()
    {
        if (((IList)letterlayers[0]).Contains(keyType))
        {
            transform.Translate(Vector2.down / 3);
        }

        if (((IList)letterlayers[2]).Contains(keyType))
        {
            transform.Translate(Vector2.up / 3);
        }
    }

    void Update()
    {
        transform.Translate(-Vector3.right * (Time.deltaTime)); //Moves each note left slowly
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>(); //references the textmeshpro script attatched to the note
        textmeshPro.SetText(keyType); //sets the text attatched to textmesh pro as the key type, which is assigned in the spawner script

        if (keyType == "space")
        {
            textmeshPro.fontSize = 0;
            Instantiate(space, gameObject.transform);

        }
    }


    void OnTriggerStay2D(Collider2D hit) //If the notes collide with a 2D collider
    {
        if (Input.GetKey(keyType)) //and if the input key is equal to the keytype
        {
            this.GetComponentInParent<Spawner>().counter++;
            Destroy(gameObject); //destroy the note object
        }

        if (hit.CompareTag("RhythmFail"))
        {
            this.GetComponentInParent<Spawner>().counter++;
            this.GetComponentInParent<Spawner>().fail--;
            Destroy(gameObject);
        }
    }
}