using BenchmarkDotNet.Attributes;

namespace CSharpFunctionalExtensions.Benchmarks;

[MemoryDiagnoser(false)]
public partial class ResultBenchmarks
{
    internal Result<string> _sut;
    internal ResultClass<string> _sut2;
    public ResultBenchmarks()
    {
        _sut = Result.Success("Hello billy");
        _sut2 = ResultClass.Success("Hello billy");
    }
    [Benchmark]
    public void Rest_PassAsRef()
    {
        PassAsRef(ref _sut);
    }

    [Benchmark]
    public void Rest_PassAsInterface()
    {
        PassAsInterface(_sut);
    }

    [Benchmark]
    public void ResultClass_PassAsInterface()
    {
        PassAsInterface(_sut2);
    }

    [Benchmark]
    public void Rest_PassAsValue()
    {
        PassAsValue(_sut);
    }

    [Benchmark]
    public async Task StringResultBenchmark()
    {
        await Task.FromResult(Result.Success("This is a nice test"));
    }


    private static Result<string> PassAsRef(ref Result<string> result) => result;
    private static IResult<string> PassAsInterface(IResult<string> result) => result;
    private static Result<string> PassAsValue(Result<string> result) => result;
}
