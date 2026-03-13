namespace Migration.Models
{
    public class Schedule10_3_Block4_Model
    {
        public string? Item1 { get; set; } // Household size 
        public string? Item2 { get; set; } // Household Religion 
        public string? Item3 { get; set; } // Household Social group 
        public string? Item4 { get; set; } // Area type in which the dwelling unit is located (code) 
        public string? Item5 { get; set; } // whether the household migrated to the village/town of enumeration during the last 365 days.
        public string? Item6 { get; set; } // location of last usual place of residence (code) 
        public string? Item7 { get; set; } // pattern of migration (code) 
        public string? Item8 { get; set; } // reason for migration (code) 
        public string? Item9 { get; set; } // whether any former member of the household migrated out any time in the past  
        public string? Item10 { get; set; } // number of male members who migrated out  
        public string? Item11 { get; set; } // number of female members who migrated out  
        public string? Item12 { get; set; } // number of transgender members who migrated out  
        public string? Item13 { get; set; } // whether received remittances at least once during the last 365 days from the members who migrated out (yes - 1, no - 2) "


        public string? Item14A { get; set; } // If 1 in item 13, use of remittances (maximum five codes in descending order of amount used) "
        public string? Item14B { get; set; } // If 1 in item 13, use of remittances (maximum five codes in descending order of amount used) "
        public string? Item14C { get; set; } // If 1 in item 13, use of remittances (maximum five codes in descending order of amount used) "
        public string? Item14D { get; set; } // If 1 in item 13, use of remittances (maximum five codes in descending order of amount used) "
        public string? Item14E { get; set; } // If 1 in item 13, use of remittances (maximum five codes in descending order of amount used) "
    }


}