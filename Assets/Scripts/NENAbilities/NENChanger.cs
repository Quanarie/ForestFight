using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NENChanger : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController NENAnimator;
    [SerializeField] private RuntimeAnimatorController ZETSUAnimator;
    [SerializeField] private GameObject RENBackground;
    [SerializeField] private GameObject NENButton;
    [SerializeField] private Sprite[] NENAbilitiesBackgrounds;

    private AbstractNENAbility[] NENAbilities;
    private int currentAbility = 0;
    private const int abilitiesQuantity = 3;

    private void Start()
    {
        NENAbilities = new AbstractNENAbility[abilitiesQuantity];
        NENAbilities[0] = GetComponent<NEN>();
        NENAbilities[1] = GetComponent<REN>();
        NENAbilities[2] = GetComponent<ZETSU>();
        NENAbilities[0].Activate();
    }

    public void Next()
    {
        NENAbilities[currentAbility].Disactivate();
        if (currentAbility != 2)
        {
            currentAbility += 1;
        }
        else
        {
            currentAbility = 0;
        }
        NENAbilities[currentAbility].Activate();

        if (currentAbility == 0)
        {
            NENButton.GetComponent<Image>().sprite = NENAbilitiesBackgrounds[0];
            GetComponent<Animator>().runtimeAnimatorController = NENAnimator;
        }
        else if (currentAbility == 1)
        {
            RENBackground.SetActive(true);
            NENButton.GetComponent<Image>().sprite = NENAbilitiesBackgrounds[1];
            GetComponent<Animator>().runtimeAnimatorController = ZETSUAnimator;
        }
        else
        {
            RENBackground.SetActive(false);
            NENButton.GetComponent<Image>().sprite = NENAbilitiesBackgrounds[2];
            GetComponent<Animator>().runtimeAnimatorController = ZETSUAnimator;
        }
    }

    public void Previous()
    {
        NENAbilities[currentAbility].Disactivate();
        if (currentAbility != 0)
        {
            currentAbility -= 1;
        }
        else
        {
            currentAbility = 2;
        }
        NENAbilities[currentAbility].Activate();

        if (currentAbility == 0)
        {
            RENBackground.SetActive(false);
            NENButton.GetComponent<Image>().sprite = NENAbilitiesBackgrounds[0];
            GetComponent<Animator>().runtimeAnimatorController = NENAnimator;
        }
        else if (currentAbility == 1)
        {
            RENBackground.SetActive(true);
            NENButton.GetComponent<Image>().sprite = NENAbilitiesBackgrounds[1];
        }
        else
        {
            NENButton.GetComponent<Image>().sprite = NENAbilitiesBackgrounds[2];
            GetComponent<Animator>().runtimeAnimatorController = ZETSUAnimator;
        }
    }
}
