using System;
using System.Collections.Generic;

namespace Celeste.Mod.GoldenETA.Path;

public class PathsLoader
{
    public Dictionary<String, RunPath> Paths;

    public bool HasError;
    public String Error = "";

    public PathsLoader()
    {
        UpdatePaths();
    }

    public RunPath LoadPath(String path)
    {
        if (HasError) return null;

        if (Paths.TryGetValue(path, out RunPath runPath)) return runPath;

        HasError = true;
        Error = "Could not find run path in loaded paths";
        return null;
    }

    public void UpdatePaths()
    {
        Paths = new Dictionary<string, RunPath>();

        try
        {
            HasError = false;
            Error = "";
        }
        catch (Exception)
        {
            HasError = true;
            Error = "error";
        }
    }
}