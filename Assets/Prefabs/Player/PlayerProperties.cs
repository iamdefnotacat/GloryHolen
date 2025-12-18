using UnityEngine;

public enum PlayerHats
{
    None,
    PartyHat,
    Hushanka,
}
  
public class PlayerProperties : MonoBehaviour
{
    [SerializeField]
    private PlayerHats currentPlayerHat = PlayerHats.None; // i.e keep track of player equipped hat default = None


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
