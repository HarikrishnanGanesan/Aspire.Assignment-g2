
using Microsoft.AspNetCore.Http;
namespace Assignment.Contracts.DTO;
public class UserProfileDTO{
public  string? Email{get;set;}
public string? Name{get;set;}
public string? ContactNumber{get;set;}
public string? Password{get;set;}
public string? Address{get;set;}
public  IFormFile? ProfileImageFile{get;set;}
public  byte[]? ProfileImage{get;set;}
public  IFormFile? LicenseFrontFile{get;set;}
public  byte[]? LicenseFront{get;set;}
public  IFormFile? LicenseBackFile{get;set;}
public  byte[]? LicenseBack{get;set;}

}