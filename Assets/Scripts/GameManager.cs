using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Sprite[] PlayerSprites;

     static Text score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSpriteToBlue());
    }

    IEnumerator  ChangeSpriteToBlue()
    {

        while (true)
        {
            

            yield return new WaitForSeconds(1.5f);
            Debug.Log(player.GetComponent<SpriteRenderer>().sprite);
            player.GetComponent<SpriteRenderer>().sprite = PlayerSprites[Mathf.FloorToInt(Random.Range(1,11))];
        }

    }


    private void Update()
    {
        
    }

    static void AddScore(int points)
    {
        //int myScore = int.Parse(GameManager.score.text);
        //myScore += 100;
        //GameManager.score.text = myScore.ToString();

    }





}
