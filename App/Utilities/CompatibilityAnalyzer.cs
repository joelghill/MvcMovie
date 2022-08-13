
namespace MvcMovie.Utilities;

public class CompatibilityAnalyzer
{

    public Dictionary<char, int>  PointsMap;

    public CompatibilityAnalyzer() {
        
        string lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        this.PointsMap = new Dictionary<char, int>();

        var random = new Random(1334);

        foreach (var letter in lowerCaseLetters) {
            this.PointsMap[letter] = random.Next(1, 100);
        }
    }

    public int GetPoints(string name) {

        int points = 0;
        foreach (char letter in name) {
            points += this.PointsMap.GetValueOrDefault(letter, 0);
        }

        return points;
    }

    public double GetCompatibility(string personOne, string personTwo) {
        var points1 = this.GetPoints(personOne);
        var points2 = this.GetPoints(personTwo);

        int larger;
        int smaller;

        if (points1 >= points2) {
            larger = points1;
            smaller = points2;
        } else {
            larger = points2;
            smaller = points1;
        }

        return ((double)smaller / (double)larger) * 100;
    }
}