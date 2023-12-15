using System.ComponentModel;

namespace BloodDonation.Stock.Core.Models.Enuns
{
    public enum BloodType
    {
        [Description("A")]
        A,
        [Description("B")]
        B,
        [Description("AB")]
        AB,
        [Description("O")]
        O
    }
}
