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
            Console.WriteLine("Pleas enter VAT number");
            var vatInput = Console.ReadLine();

            try
            {
                var checkerDAL = new CheckerDAL(_iconfiguration);
                var listCountryModel = checkerDAL.GetList();
                var checkVatInput=listCountryModel.Find(item=>
                   item.VatNumber.Contains(vatInput)
                );

            }
            catch (Exception ex)
            {

                throw ex;
            }

            Console.WriteLine("Pleas enter Country Code");
            var countryInput = Console.ReadLine();


            try
            {
                var checkerDAL = new CheckerDAL(_iconfiguration);
                var listCountryModel = checkerDAL.GetList();
                var checkCountryInput = listCountryModel.Find(item =>
                     item.CountryCode.Contains(countryInput)
                );

            }
            catch (Exception ex)
            {

                throw ex;
            }

            if ()
            {
                Console.WriteLine("info..");
            }
            else
            {
                Console.WriteLine("incorrect input");
            }
            GetAppSettingsFile();
                PrintCountries();
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
                Console.WriteLine(item.Country[i]);
            });
            Console.WriteLine("Press any key to stop.");
                Console.ReadKey();
            }
        }
    }
    



