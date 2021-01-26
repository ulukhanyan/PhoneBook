
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace 	PhoneBook.Models{
public class Email{
    public int EmailId{get;set;}
    public int PersonEmile{get;set;}
    public string EmailAddress {get;set;}
    
    public Person Person {get;set;}
}

}