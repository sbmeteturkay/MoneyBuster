using DG.Tweening;
using UnityEngine;

public class MoneyAction : MonoBehaviour
{
    [Header("Shredder & Money Stack")]
    [SerializeField] GameObject shedderPosition;
    [SerializeField] GameObject moneysPosition;
    [SerializeField] Shredder shredder;
    [SerializeField] Shredder moneyStack;
    [SerializeField] Animator shredAnimator;
    [Header("Current Money")]
    [SerializeField] GameObject money;
    [SerializeField] Material doodledMat;
    [SerializeField] Material normalMat;
    [SerializeField] Material UVMat;
    [SerializeField] Material normalUVMat;
    [SerializeField] TMPro.TMP_Text score;
    [SerializeField] int collectedNormalMoney;
    [SerializeField] int collectedFakeMoney;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (shredder.isMoneyHere)
            {
                ShredMoney();
            }
            else if(moneyStack.isMoneyHere)
            {
                TakeMoney();
            }
        }
    }

    void OnTakeEnter()
    {
    }
    void OnShredEnter()
    {
    }
    void TakeMoney()
    {
        moneyStack.isMoneyHere = false;
        moneyStack.shredPanel.SetActive(false);
        money.transform.DOKill();
        money.transform.DORotate(new Vector3(0, 90, 0), 0.1f);
        money.transform.DOMove(moneysPosition.gameObject.transform.position,1);
        this.Wait(1f, () => {
            money.SetActive(false);
            CheckMoney(false);
            RecreateMoney();
        });
    }
    void RecreateMoney()
    {
        //3 is fake checking layer, we set active if money is fake
        money.transform.GetChild(3).gameObject.SetActive(false);
        //doodle layer, active or not
        if (0 == Random.Range(0, 2))
        {
            money.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material = doodledMat;
            money.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            money.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material = normalMat;
        }
        //uv layer, active or not
        if (0 == Random.Range(0, 2))
        {
            money.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().material = UVMat;
            money.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            money.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().material = normalUVMat;
        }
        money.SetActive(true);
    }
    void CheckMoney(bool fake)
    {
        //NEEDS REWORK, THIS IS NOT WORK BECAUSE CHILD ALWWAYS OPEN FOR NOW
        if (fake)
        {
            if (money.transform.GetChild(3).gameObject.activeSelf)
            {
                collectedFakeMoney++;
            }
        }
        else
        {
            if (!money.transform.GetChild(3).gameObject.activeSelf)
            {
                collectedNormalMoney++;
                
            }
        }
        score.text = "Score:" + (collectedNormalMoney + collectedFakeMoney);

    }
    void ShredMoney()
    {
        shredder.isMoneyHere = false;
        shredder.shredPanel.SetActive(false);
        money.transform.DOKill();
        money.transform.DORotate(new Vector3(0, 90, 0), 0.1f);
        shredAnimator.SetTrigger("MoneyShredStart");
        money.transform.DOMove(shedderPosition.gameObject.transform.position, 1);
        this.Wait(1f, () => { 
            money.SetActive(false); 
            shredAnimator.SetTrigger("MoneyShredEnd");
            CheckMoney(true);
            RecreateMoney();

        });
    }
}
