namespace Migration.Models
{
    public class Schedule10_3_Block6_Model {
        public string? Item1 { get; set; } // srl no (as in Col. 1 of Bl 3) 
        public string? Item2 { get; set; } // name of household member (as in Col 2 of Block 3) 
        public string? Item3 { get; set; } // age (as in Col 5 of Block 3) 
        public string? Item4 { get; set; } // whether stayed away from village/town for 15 days or more but less than 6 months during the last 365 days for employment or in search of employment (yes-1, no-2) 
        public string? Item5 { get; set; } // for 1 in Col 4 : number of spells (of duration 15 days or more) 
        public string? Item6 { get; set; } // destination during longest spell  (code) 
        public string? Item7 { get; set; } // for code 5 to 7 in Col 6, State /UT/ country of destination (code) 
        public string? Item8 { get; set; } // if worked, industry of work for longest duration of 
        public string? Item9 { get; set; } // work (2-digit NIC 2025) 
        public string? Item10 { get; set; } // occupation (3-digit NCO-2015) 
        public string? Item11 { get; set; } // source of information about the job/place of work? (code) 
        public string? Item12 { get; set; } // for code 1 in Col 10, nature of support provided by the contractor/ agent (code)
        public string? Item13 { get; set; } // whether sent remittances during the last 365 days 
        public string? Item14 { get; set; } // frequency of transfer of remittance  
        public string? Item15 { get; set; } // amount of remittances sent during the last 365 days (Rs.) 

    }

}