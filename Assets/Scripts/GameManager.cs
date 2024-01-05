using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(waitTime);  
            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);  
        }
    }
    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp", 2f, 1f);
    }
}
// 3 variables for spawn handling one for holding the gamobject which will spawn , one for location where it will spawn , because game will restart ata this point so score =0.
//make a coroutine method of IEnumerator type for time gap with random.range for random time interval. and put it in infinite loop using while loop.
// then instatiate gameobject with spawnposition.
// then use StartCoroutine("name of IEnumerator method") method  in update().
//  Awake - Start - (*Physics* FixedUpdate - OnTrigger-OnCollision) - (*Input events* OnMouseDown) - Update - coroutines-  LateUpdate - (*scene rendering*

//                                                                                                                                  Onbecamevisible/invisible)-(*The last* OnDestroy)

// give refrence from prefab rather than from gameobject because gameobject can be deleted during run time and also dont forget to disable the gameobject.

