using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class ReprimandSelector
{
    public static Reprimand GetReprimand(string name)
    {
        return Reprimands.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    internal static List<Reprimand> GetAllReprimands()
    {
        return Reprimands;
    }

    private static readonly List<Reprimand> Reprimands = new()
    {
        new Reprimand {
            Name = "Court Martial",
            CostNum = 5,
            Description = "You are arrested and placed on trial for your actions. You have the right to legal counsel in your defense, and the court martial proceedings should be resolved in-game. The court will determine guilt or innocence, and pass sentence, which can include dishonorable discharge from Starfleet and long-term incarceration in a penal facility (which would usually require retiring the character and creating a new one)."},

        new Reprimand {
            Name = "Demotion",
            CostNum = 3,
            Description = "You may accept demotion from your current rank, having proven yourself unworthy of the status you attained. Reduce your rank by one step (i.e., from commander to lieutenant commander, or from lieutenant to lieutenant (junior grade), etc.)."},

        new Reprimand {
            Name = "Detention",
            CostNum = 2,
            Description = "You are stripped of your duties and locked away for a short duration, forced to contemplate your Reprimands in isolation. A character in detention cannot be used: you must use a supporting character instead during the next mission."},

        new Reprimand {
            Name = "Gain Anitpathy",
            VariableCost = true,
            Description = "Poor conduct earns enmity and makes enemies. You may declare an allied NPC you encountered during the adventure regards you poorly. This uses 1 Reprimand normally, but the cost increases by 1 if the NPC commands a starship (or has similar status), or 2 if the NPC is an admiral, general, or other high-ranking figure."},

        new Reprimand {
            Name = "Reduce Reputation",
            VariableCost = true,
            Description = "You may reduce your Reputation by 1, using Reprimands equal to the Reputation you previously held (that is, reducing Reputation from 3 to 2 costs 3 Reprimands). You may only use this once per adventure."},

        new Reprimand {
            Name = "Shame by Association",
            CostNum = 2,
            Description = "If you are the commanding officer, you may stain the reputation of others aboard your ship. This counts as one extra negative influence on each other main character’s reputation roll, and it must be done before those characters roll."},

        new Reprimand {
            Name = "Status",
            CostNum = 3,
            Description = "With the gamemaster’s assistance, create an additional trait for the character, which reflects their dishonor, cowardice, or disgrace, or remove a trait which represents something positive. If the character is a commanding officer, they may add a trait to their ship instead."},

        new Reprimand {
            Name = "Stripped of Award",
            VariableCost = true,
            Description = "If you have one or more awards, you may remove one or more of them to remove Reprimands; each award removed uses Reprimands equal to its cost."},
    };
}
