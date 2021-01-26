
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace 	PhoneBook.Models{
public class Phone{
    public int PhoneId{get;set;}
    public int PersonPhone{get;set;}
    public string PhoneNumber {get;set;}
    
    public Person Person {get;set;}


  
}

}