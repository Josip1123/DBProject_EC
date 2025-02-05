using NanoidDotNet;

namespace Business.Helpers;

public static class NanoIdGenerator
{
    public static string GenerateId(int idSize)
    {
        return Nanoid.Generate(size: idSize);
    }
    
}