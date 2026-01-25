namespace Museum_Domain.Models;

public class Visitor
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Last_Name { get; set; }
    public int Phone_Number { get; set; }
    public int Age { get; set; }
    public string? Email_Address { get; set; }
    public string? Nationality { get; set; }


    public bool IsTurkish { get; set; }
    public bool IsTurkish_Soldier { get; set; }


   // public bool IsForeign { get; set; }
   // public bool IsForeign_Soldier { get; set; }

}
