using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralPlayerActivities : MonoBehaviour
{
    public GameObject player;
    public string username;
    public int wallet;  // TODO: change to array in future
    public int mole_kills;
    public int totalDeaths;
    public float totalTime;
    public GameObject FloatingTextPrefab;
    public static GeneralPlayerActivities Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        totalTime = Timer.time.currentTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Creates target when player is in range
        if (other.gameObject.tag == "Currency_Coin")
        {
            wallet++;
            string label = "+1 Coin";
            ShowFloatingText(label);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Currency_Gem")
        {
            wallet++;
            string label = "+1 Gem";
            ShowFloatingText(label);
            Destroy(other.gameObject);
        }
    }

    // void ShowFloatingText()
    // {
    //     Vector3 vec = new Vector3(Mathf.Abs(transform.position.x), Mathf.Abs(transform.position.y), Mathf.Abs(transform.position.z));
    //     // Instantiate(FloatingTextPrefab, vec, Quaternion.identity);
    //     Debug.Log(transform.localPosition);
    //     // Vector3 Offset = new Vector3(0, 2, 0);
    //     // FloatingTextPrefab.transform.position += Offset;

    //     var go = Instantiate(FloatingTextPrefab, vec, Quaternion.identity);
    //     go.GetComponent<TextMesh>().text = wallet.ToString();
    // }

    void ShowFloatingText(string _label)
    {
        Vector3 vec = new Vector3(Mathf.Abs(transform.position.x), Mathf.Abs(transform.position.y), Mathf.Abs(transform.position.z));
        // Instantiate(FloatingTextPrefab, vec, Quaternion.identity);
        Debug.Log(transform.localPosition);
        // Vector3 Offset = new Vector3(0, 2, 0);
        // FloatingTextPrefab.transform.position += Offset;

        var go = Instantiate(FloatingTextPrefab, vec, Quaternion.identity);
        go.GetComponent<TextMeshPro>().text = _label;
    }

    void endAnimation()
    {
        Debug.Log("Animation is done");
        // gameObject.GetComponent<SpriteRenderer>().enabled = false;
        var swing = player.GetComponent<Rigidbody2D>();
        swing.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        swing.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        swing.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
