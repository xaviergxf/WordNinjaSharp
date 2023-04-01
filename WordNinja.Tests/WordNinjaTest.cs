using System.Diagnostics;
using WordNinjaSharp.App;

namespace WordNinjaSharp.Tests;

[TestClass]
public class WordNinjaTest
{
    private readonly List<string> _sentences = new()
    {
        //"Two households both alike in dignity",
        //"In fair Verona where we lay our scene",
        "From ancient grudge break to new mutiny",
        "Where civil blood makes civil hands unclean",
        "From forth the fatal loins of these two foes",
        "A pair of star crossed lovers take their life",
        //"Whose misadventured piteous overthrows",
        "Doth with their death bury their parents strife",
        "The fearful passage of their death marked love",
        "And the continuance of their parents rage",
        "Which but their children's end naught could remove",
        "Is now the two hours traffic of our stage",
        "The which if you with patient ears attend",
        //"What here shall miss our toil shall strive to mend",
        "O Romeo Romeo wherefore art thou Romeo",
        "Deny thy father and refuse thy name",
        "Or if thou wilt not be but sworn my love",
        "And I'll no longer be a Capulet",
        "My only love sprung from my only hate",
        "Too early seen unknown and known too late",
    };

    [TestMethod]
    public void TestSplitMany()
    {
        var testSentences = _sentences
            .ToDictionary(x => x.ToLower(), y => y.Replace(" ", "").ToLower());

        foreach (var testSentence in testSentences)
        {
            var sentence = WordNinja.Split(testSentence.Value);
            Console.WriteLine(testSentence.Key);
            Console.WriteLine(sentence);
            Assert.AreEqual(sentence, testSentence.Key);
        }

    }

    [TestMethod]
    public void TestSplitOne()
    {
        var res = WordNinja.Split("thequickbrownfoxjumpsover1978thelazydog");
        Assert.IsNotNull(res);
        Assert.AreEqual(string.Join(" ", res), "the quick brown fox jumps over 1978 the lazy dog");
        Console.WriteLine(string.Join(" ", res));
    }

    [TestMethod]
    public void TestPerformance()
    {
        var sw = Stopwatch.StartNew();
        var res = WordNinja.Split("denythyfatherandrefusethyname");
        Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
        Console.WriteLine(string.Join(" ", res));
    }

}