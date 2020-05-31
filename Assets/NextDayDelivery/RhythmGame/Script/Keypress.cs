using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypress : MonoBehaviour
{
    public GameObject space;
    //public AudioSource audio;
    public GameObject circle;
    public string keyType;
    private string[][] letterlayers = new string[][] { new[] { "z", "v", "m"},
        new[] { "a", "f", "j", "l", " "},
        new[] { "q", "r", "u", "p"} };

    public Color32 col_w = new Color32(0x73, 0xEF, 0x5E, 0xFF);
    public Color32 col_d = new Color32(0xED, 0x5F, 0x5F, 0xFF);
    public Color32 col_p = new Color32(0xBF, 0x5F, 0xED, 0xFF);
    public Color32 col_l = new Color32(0x60, 0xC3, 0xEA, 0xFF);
    public Color32 col_y = new Color32(0xED, 0xE6, 0x5F, 0xFF);

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
        textmeshPro.SetText(keyType);
        Color keycolor = circle.GetComponent<SpriteRenderer>().color;
        //sets the text attatched to textmesh pro as the key type, which is assigned in the spawner script
        switch (keyType)
        {
            default:
                circle.GetComponent<SpriteRenderer>().color = col_w;
                Debug.Log("Couldn't find a colour so just used green");
                break;
            case "w":
                circle.GetComponent<SpriteRenderer>().color = col_w;
                Debug.Log("W uses green");
                break;
            case "d":
                circle.GetComponent<SpriteRenderer>().color = col_d;
                Debug.Log("D uses red");
                break;
            case "p":
                circle.GetComponent<SpriteRenderer>().color = col_p;
                Debug.Log("P uses purple");
                break;
            case "l":
                circle.GetComponent<SpriteRenderer>().color = col_l;
                Debug.Log("L uses blue");
                break;
            case "y":
                circle.GetComponent<SpriteRenderer>().color = col_y;
                Debug.Log("space uses yellow");
                break;
        }

        if (keyType == "space")
        {
            textmeshPro.fontSize = 0;
            circle.SetActive(false);
            Instantiate(space, gameObject.transform);

        }
    }


    void OnTriggerStay2D(Collider2D hit) //If the notes collide with a 2D collider
    {
        if (Input.GetKey(keyType)) //and if the input key is equal to the keytype
        {
            if (hit.CompareTag("EarlyNote"))
            {
                this.GetComponentInParent<Spawner>().counter++;
                this.GetComponentInParent<Spawner>().fail--;
                Destroy(gameObject);
                Debug.Log(this.GetComponentInParent<Spawner>().fail);
            }
            else
            {
                this.GetComponentInParent<Spawner>().counter++;
                Destroy(gameObject); //destroy the note object
            }
        }

        if (hit.CompareTag("RhythmFail"))
        {
            this.GetComponentInParent<Spawner>().counter++;
            this.GetComponentInParent<Spawner>().fail -= 2;
            Destroy(gameObject);
        }
    }
}