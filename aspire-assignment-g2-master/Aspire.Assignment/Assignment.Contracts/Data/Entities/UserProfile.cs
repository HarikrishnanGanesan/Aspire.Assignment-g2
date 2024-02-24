using System.ComponentModel.DataAnnotations;

namespace Assignment.Contracts.Data.Entities;
public class UserProfile{
[Key]
public required string Email {get;set;}
public required string Password{get;set;}
public required string Name{get;set;}
public required string ContactNumber{get;set;}
public string? Address{get;set;}
public  byte[]? ProfileImage{get;set;}
public  byte[]? DLImageFront{get;set;}
public  byte[]? DLImageBack{get;set;}

}