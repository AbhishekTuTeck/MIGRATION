namespace Migration.Models
{
    public class Schedule10_3_Block3_Model
    {
        public int Item1 { get; set; } // Serial No
        public string Item2 { get; set; } = default!; //Name_of_household_member 
        public string Item3 { get; set; } = default!; // Relation_To_Head_Code 
        public string Item4 { get; set; } = default!; // Gender_Code
        public string Item5 { get; set; } = default!; // Age_Years
        public string Item6 { get; set; } = default!; // MaritalStatus_Code
        public string Item7 { get; set; } = default!; // Highest_Level_Of_Education_Completed_Successfully_Code 
        public string Item8 { get; set; } = default!; // Number_Of_Years_In_Formal_Education
        public string? Item9 { get; set; } // For persons age 0 to 29 years, status of current attendance(code)
        public string Item10 { get; set; } = default!; // Principal activity status (code)
        public string? Item11 { get; set; } // Industry division (2-digit NIC 2025)
        public string? Item12 { get; set; } // Occupation(3-digit NCO-2015)

    }
}