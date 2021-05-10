using ViesChecker.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
namespace ViesChecker
{
    class Program
    {

     
            private static IConfiguration _iconfiguration;
            static void Main(string[] args)
            {

            GetAppSettingsFile();
            Console.WriteLine("Pleas enter VAT number");
            var vatInput = Console.ReadLine();

            try
            {
                var checkerDAL = new CheckerDAL(_iconfiguration);
                var listCountryModel = checkerDAL.GetList();
                var checkVatInput=listCountryModel.Find(item=>
                   item.VatNumber.Contains(vatInput)
                );
                if(checkVatInput==null)
                {
                    Console.WriteLine("the vat nr isn't corret.");
                }
                else
                {
                    Console.WriteLine("Pleas enter Country Code");
                    var countryInput = Console.ReadLine();
                   
                    var checkCountryInput = listCountryModel.Find(item =>
                         item.CountryCode.Contains(countryInput)
                    );
                    if (checkCountryInput == null)
                    {
                        Console.WriteLine("the country code isn't corret.");
                    }
                    else
                    {
                        Console.WriteLine($"{checkCountryInput.Name}");
                        Console.WriteLine($"{checkCountryInput.Address}");
                        Console.WriteLine($"{checkCountryInput.VatNumber}");
                        Console.WriteLine($"{checkCountryInput.City}");
                        Console.WriteLine($"{checkCountryInput.Country}");
                        Console.WriteLine($"{checkCountryInput.RequestDate}");
                    }

                }
               

            }
            catch (Exception ex)
            {

                throw ex;
                
            }

           


         

           

            //from csharp corner demo
          
                //PrintCountries();
            }
            static void GetAppSettingsFile()
            {
                var builder = new ConfigurationBuilder()
                                     .SetBasePath(Directory.GetCurrentDirectory())
                                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                _iconfiguration = builder.Build();
            }
            static void PrintCountries()
            {
                var checkerDAL = new CheckerDAL(_iconfiguration);
                var listCountryModel = checkerDAL.GetList();

            listCountryModel.ForEach(item =>
            {
                //Console.WriteLine(item.Country[i]);
            });
            Console.WriteLine("Press any key to stop.");
                Console.ReadKey();
            }
        }
    }
    



