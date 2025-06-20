using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboard;
    [SerializeField] TMP_Text mn;
    public PLayer player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    public void totalMoney(int price)
    {
        player.money += price;
        mn.text = player.money.ToString();
   }
   
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void increaseScore(int amount)
    {
        player.score += amount;
        scoreboard.text = player.score.ToString();
    }

}
