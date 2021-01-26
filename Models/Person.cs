
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace 	PhoneBook.Models{
    
public class Person{
    
  
    public int PersonId{get;set;}
    public string Name {get;set;}
    public string Surname{get;set;}
    public string Patronymic{get;set;}
    public string State {get;set;}
    public string City {get;set;}
    public string Street {get;set;}
    public int Department {get;set;}


    public ICollection<Phone> Phone {get;set;}
    public ICollection<Email> Email {get;set;}

}

}
