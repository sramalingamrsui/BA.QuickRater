using System;

namespace RSUI.BA.Rating.API.Models
{
    public class ClaimInfo
    {
        public string ClaimNumber { get; set; }
        public string InsuredName { get; set; }
        public DateTime DateOfLoss { get; set; }
        public string DisplayName => $"{ClaimNumber} - {InsuredName} | {DateOfLoss:d}"; 
    }
}