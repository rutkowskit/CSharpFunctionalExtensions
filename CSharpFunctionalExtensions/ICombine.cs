namespace CSharpFunctionalExtensions;

public interface ICombine
{
    ICombine Combine(ICombine value);
}


internal class Testing
{
    //lang=regex
    const string TestRegex = """
        ^\s*?(?<TjoId>\d{6})\s*?[;|]\s*?(?<TjoNazwa>.*?[^;|])\s*?[;|]\s*?(?<NazwiskoUb>.*?[^;|])\s*?[;|]\s*?(?<ImieUb>.*?[^;|])\s*?[;|]\s*?(?<PeselUb>\d*?[^;|])\s*?[;|]\s*?(?<KsiIdUb>\d*?[^;|])\s*?[;|]\s*?(?<DataZgonu>\d{4}-\d{2}-\d{2})\s*?[;|]\s*?(?<Zrodlo>\w{1})\s*?$
        """;
}
