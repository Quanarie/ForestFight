using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NENChanger : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController NENAnimator;
    [SerializeField] private RuntimeAnimatorController ZETSUAnimator;
    [SerializeField] private GameObject RENBackground;

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
            GetComponent<Animator>().runtimeAnimatorController = NENAnimator;
        }
        else if (currentAbility == 1)
        {
            RENBackground.SetActive(true);
            GetComponent<Animator>().runtimeAnimatorController = ZETSUAnimator;
        }
        else
        {
            RENBackground.SetActive(false);
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
            GetComponent<Animator>().runtimeAnimatorController = NENAnimator;
        }
        else if (currentAbility == 1)
        {
            RENBackground.SetActive(true);
        }
        else
        {
            GetComponent<Animator>().runtimeAnimatorController = ZETSUAnimator;
        }
    }
}
