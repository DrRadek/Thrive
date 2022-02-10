﻿using System.Collections.Generic;
using System.Linq;

/// <summary>
///   Speed information of a process in specific patch. Used in the
///   editor to show info to the player.
/// </summary>
public class ProcessSpeedInformation : IProcessDisplayInfo
{
    public ProcessSpeedInformation(BioProcess process)
    {
        Process = process;
    }

    public BioProcess Process { get; }

    public string Name => Process.Name;

    public Dictionary<Compound, float> WritableInputs { get; } = new();
    public Dictionary<Compound, float> WritableOutputs { get; } = new();
    public List<Compound> WritableLimitingCompounds { get; } = new();

    public Dictionary<Compound, float> WritableFullSpeedRequiredEnvironmentalInputs { get; } = new();

    public Dictionary<Compound, float> AvailableAmounts { get; } = new();

    // ReSharper disable once CollectionNeverQueried.Global
    public Dictionary<Compound, float> AvailableRates { get; } = new();

    public IEnumerable<KeyValuePair<Compound, float>> Inputs =>
        WritableInputs.Where(p => !p.Key.IsEnvironmental);

    public IEnumerable<KeyValuePair<Compound, float>> EnvironmentalInputs =>
        AvailableAmounts.Where(p => p.Key.IsEnvironmental);

    public IReadOnlyDictionary<Compound, float> FullSpeedRequiredEnvironmentalInputs =>
        WritableFullSpeedRequiredEnvironmentalInputs;

    public IEnumerable<KeyValuePair<Compound, float>> Outputs =>
        WritableOutputs.Where(p => !p.Key.IsEnvironmental);

    public IEnumerable<KeyValuePair<Compound, float>> EnvironmentalOutputs =>
        WritableOutputs.Where(p => p.Key.IsEnvironmental);

    public float CurrentSpeed { get; set; }

    public IReadOnlyList<Compound> LimitingCompounds => WritableLimitingCompounds;
}
