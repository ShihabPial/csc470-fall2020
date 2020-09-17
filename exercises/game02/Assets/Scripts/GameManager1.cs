using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public GameObject chakraPrefab;
    public GameObject ground;

    public float chakraFall = 0.01f;
    public float fallRate = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        chakraFall -= Time.deltaTime;
        if(chakraFall < 0)
        {
            Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-10, 10), ground.transform.position.y + 10, ground.transform.position.z + Random.Range(-10, 10));
            GameObject ch = Instantiate(chakraPrefab, pos, Quaternion.identity);
            Renderer rend = ch.GetComponent<Renderer>();
            //rend.material.color = new Color(Random.value, Random.value, Random.value);
            Destroy(ch, 1f);

            chakraFall = fallRate;
        }
    }

    public void makeMoreChakra()
    {
        Debug.Log("Chakras");

        SceneManager.LoadScene("GameScene");
    }
}
