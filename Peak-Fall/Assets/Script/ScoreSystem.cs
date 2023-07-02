using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour {
    [SerializeField] int score = 100;

    public static ScoreSystem instance;

    private PlayerMovement player;
    private Renderer playerRender;



    // Start is  called before the first frame update
    void Start() {
        instance = this;
        player = FindObjectOfType<PlayerMovement>();
        playerRender = player.GetComponent<Renderer>();
    }

    public void reduceScore(int reduce) {
        score -= reduce;
        BlinkPlayer(3, 0.1f);
        player.awayForce();
    }

    void BlinkPlayer(int number, float second) {
        StartCoroutine(DoBlinks(number, second));
    }

    public string gradeString() {
        string grade = "";
        if (score < 40)
            grade = "F ";
        else if (score < 55)
            grade = "D ";
        else if (score < 70) {
            grade = "C";
            grade += calculateSymbol(70);
        }
        else if (score < 85) {
            grade = "B";
            grade += calculateSymbol(85);
        }
        else {
            grade = "A";
            grade += calculateSymbol(100);
        }

        return grade;
    }

    private char calculateSymbol(int highest_grade) {
        int different = (highest_grade - score - 1) / 5;
        if (different == 0)
            return '+';
        else if (different == 1)
            return ' ';
        else
            return '-';
    }

    IEnumerator DoBlinks(int number, float second) {
        for (int i = 0; i < number * 2; i++) {
            playerRender.enabled = !playerRender.enabled;
            yield return new WaitForSeconds(second);
        }

        playerRender.enabled = true;
    }

}
