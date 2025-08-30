using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicBookFlip : MonoBehaviour
{
    [SerializeField] private int pageNumber = 1;

    [SerializeField] private Animator bookAnimator;

    [SerializeField] private GameObject leftCollider;
    [SerializeField] private GameObject rightCollider;

    // Start is called before the first frame update
    void Start()
    {
        //isPageTapped = false;
        bookAnimator = gameObject.GetComponentInChildren<Animator>();
        rightCollider = GameObject.Find("RightPageCollider");
        leftCollider = GameObject.Find("LeftPageCollider");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                switch (hit.transform.name)
                {
                    case "RightPageCollider":
                        switch (pageNumber)
                        {
                            case 1:
                                bookAnimator.Play("FrontPage01");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber++;
                                break;
                            case 2:
                                bookAnimator.Play("FrontPage02");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber++;
                                break;
                            case 3:
                                bookAnimator.Play("FrontPage03");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber++;
                                break;
                            case 4:
                                bookAnimator.Play("FrontPage04");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber++;
                                break;
                            case 5:
                                bookAnimator.Play("FrontPage05");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber++;
                                break;
                            default:
                                break;
                        }
                        break;

                    case "LeftPageCollider":
                        switch (pageNumber)
                        {
                            case 2:
                                bookAnimator.Play("BackPage01");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber--;
                                break;
                            case 3:
                                bookAnimator.Play("BackPage02");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber--;
                                break;
                            case 4:
                                bookAnimator.Play("BackPage03");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber--;
                                break;
                            case 5:
                                bookAnimator.Play("BackPage04");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber--;
                                break;
                            case 6:
                                bookAnimator.Play("BackPage05");
                                StartCoroutine(WaitForPageAnimation());
                                pageNumber--;
                                break;
                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

    IEnumerator WaitForPageAnimation()
    {
        rightCollider.SetActive(false);
        leftCollider.SetActive(false);
        yield return new WaitForSeconds(bookAnimator.GetCurrentAnimatorStateInfo(0).length); // + bookAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        rightCollider.SetActive(true);
        leftCollider.SetActive(true);
    }
}