using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnetwebapiproject.Models
{
    [Table("customer", Schema ="dbo")]

    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
public int CustomerId {get;set;}
[Column("customer_name")]
public string CustomerName {get;set;}
[Column("customer_mobilenumber")]
public string MobileNumber {get;set;}
[Column("customer_email")]
public string Email {get;set;}
    }

}