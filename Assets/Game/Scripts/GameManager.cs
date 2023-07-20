using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);

        Instance = this;
    }

    public static event Action onSpinningWheel; 
    public static event Action onStopSpinningWheel; 

    Spinner spinner;
    ProbabilityHandler probabilityHandler;

    // public Item[] items =
    // {
    //     new Item("Chest", 10, -20, 20, 2),    //10% chance
    //     new Item("Coin", 5, 24, 64, 1000),   //5% chance
    //     new Item("Diamond", 30, 68, 108, 50),    //30% chance
    //     new Item("Diamond", 10, 115, 155,  500),    //10% chance
    //     new Item("Card", 20, 160, 200, 2),    //20% chance
    //     new Item("Coin", 5, 206, 246, 1500),    //5% chance
    //     new Item("Card", 10, 252, 293, 1),    //10% chance
    //     new Item("Coin", 10, 298, 336, 150),    //10% chance


    // };
        public Item[] items =
    {
        new Item("Chest", 1, -20, 20, 2),    //2% chance
        new Item("Coin", 5, 298, 336, 1000),   //5% chance
        new Item("Diamond", 30, 252, 293, 50),    //30% chance
        new Item("Diamond", 10, 206, 246,  500),    //10% chance
        new Item("Card", 20, 160, 200, 2),    //20% chance
        new Item("Coin", 5, 115, 155, 1500),    //5% chance
        new Item("Card", 19, 68, 108, 1),    //10% chance
        new Item("Coin", 10, 24, 64, 150),    //10% chance


    };

    public class ItemType{

        public string itemName;
        public int itemAmount;

        public ItemType(string n, int a){
            itemName = n;
            itemAmount = a;
        }

    }

    public ItemType[] ItemStore = {
        new ItemType("Coin", 0),
        new ItemType("Chest", 0),
        new ItemType("Card", 0),
        new ItemType("Diamond", 0)
    };
    int[] itemsProbabilty; // 10% - 100%
    int itemIndex;
    public Button spinButton;

    void Start()
    {
        spinner = gameObject.GetComponent<Spinner>();
        probabilityHandler = gameObject.GetComponent<ProbabilityHandler>();

        itemsProbabilty = new int[items.Length];
            
        for(int i = 0; i < items.Length; i++)
        {
            itemsProbabilty[i] = items[i].itemProbability;
        }

       // spinButton.onClick.AddListener(SpinTheWheel);
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            if(!Spinner.isSpinning){
                SpinTheWheel();
            }
        }
    }

    void SpinTheWheel()
    {
        onSpinningWheel?.Invoke();
        itemIndex = probabilityHandler.GetItemByProbability(itemsProbabilty);
        
        //Debug.Log(itemIndex);

        spinner.SpinAnimation(items[itemIndex]);
    }

    void ItemAmount()
    {
        onStopSpinningWheel?.Invoke();
        int index = 0;
        for (int i = 0 ;i<ItemStore.Length; i++){
            if (ItemStore[i].itemName == items[itemIndex].itemName){
                ItemStore[i].itemAmount += items[itemIndex].itemAmount;
                index = i;
                break;
            }
        }


        Debug.Log("item store "+ItemStore[index].itemAmount );
        UIManager.Instance.SetItemAmount(index, ItemStore[index].itemAmount);
        UIManager.Instance.EnableRewardPanel(index,items[itemIndex].itemAmount);
        
      //  Debug.Log(items[itemIndex].itemName + " = " + items[itemIndex].itemAmount);
    }

    private void OnEnable()
    {
        Spinner.OnSpinCompletete += ItemAmount;
    }
}
