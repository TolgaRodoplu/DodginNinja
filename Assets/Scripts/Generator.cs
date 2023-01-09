using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject obstacle;
    float seconds = 1f;

    // Start is called before the first frame update
    void Start()
    {

        EventSystem.instance.gameEnded += Disable;
        StartCoroutine(Generate());
    }

    // Update is called once per frame
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("obstacle"))
            Destroy(other.gameObject);
    }

    IEnumerator Generate()
    {
        while(true)
        {
            var rand = Random.Range(0f, 100f);

            if (rand <= 25)
            {
                var obj = Instantiate(obstacle);
                obj.transform.position = new Vector3(transform.position.x, 0.205f, transform.position.z);
                obj.transform.rotation = transform.rotation;
            }

            yield return new WaitForSeconds(seconds);
        }
    }

    void Disable(object sender, string str)
    {
        this.gameObject.SetActive(false);
    }
    
}
