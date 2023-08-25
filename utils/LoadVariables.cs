// Write a script to load the variables from a file and use them in the tests.

using System;
using System.IO;

namespace SeleniumCSharp.utils;

public static class DotEnv
{
    public static void Load() {
        var baseDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        DotEnv.Load(Path.Combine(baseDir, ".env"));
    }

    public static void Load(string filePath) {
        if (!File.Exists(filePath))
            return;

        foreach (var line in File.ReadAllLines(filePath)) {
            var parts = line.Split(
                '=',
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                continue;

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}