using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
    }

    [Header("Prizes Panel")]
    public Text[] itemAmountText;
    public Image[] itemImage;

    [Header("Won Reward Panel")]
    public GameObject wonRewardBG;
    public RectTransform wonRewardPanel;
    public Image wonRewardImage;
    public Text wonRewardAmount;
    public Button claimRewardButton;

    [SerializeField] GameObject TapText;

    void Start()
    {
        wonRewardBG.gameObject.SetActive(false);

        claimRewardButton.onClick.AddListener(DisableRewardPanel);
    }

    public void EnableRewardPanel(int wonItemIdex, int amount)
    {
        StartCoroutine(RewardPanelCoroutine(wonItemIdex,amount));

    }

    IEnumerator RewardPanelCoroutine(int wonItemIdex, int amount)
    {
        
        yield return new WaitForSeconds(0.3f);
        wonRewardBG.gameObject.SetActive(true);
        TapText.SetActive(false);

        //reward panel animation
        wonRewardPanel.DOScale(new Vector3(1, 1, 0), 1f).SetEase(Ease.OutElastic);

       //set won reward image in won panel
       wonRewardImage.sprite = itemImage[wonItemIdex].sprite;

        //set won reward amount in won panel
        wonRewardAmount.text = amount.ToString(); 

        
        
    }

    void DisableRewardPanel()
    {
        TapText.SetActive(true);
        Spinner.isSpinning = false;
        wonRewardPanel.transform.DOKill();
        wonRewardPanel.transform.localScale = Vector3.zero;
        wonRewardBG.gameObject.SetActive(false);
        //StartCoroutine(C_DisableRewardPanel());
    }

    /*IEnumerator C_DisableRewardPanel()
    {
        wonRewardPanel.DOScale(new Vector3(0.5f, 0.5f, 0), 1f).SetEase(Ease.OutElastic);

        yield return new WaitForSeconds(0.5f);
        wonRewardBG.gameObject.SetActive(false);

        //set the amount in prizes
        //won prize animation
    }*/

    public void SetItemAmount(int index, int amount)
    {
       // int value =    int.Parse(itemAmountText[index].text);
       // amount += value;
        itemAmountText[index].text = amount.ToString();

      //  return amount;
    }
}
