using Ekip.Framework.Core.Caching;
using Ekip.Framework.Data;
using Ekip.Framework.Data.Model;
using Ekip.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RedisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IRedisCacheManager cacheManager = new RedisCacheManager();

            var clients = DataRepository.ClientProvider.GetAll().OrderByDescending(p => p.ClientId).ToList();

            clients.ForEach(delegate (Client client)
            {
                DataRepository.ClientProvider.DeepLoad(client, false, DeepLoadType.IncludeChildren,
                    typeof(ClientMother), typeof(ClientFather));

                ClientModel model = new ClientModel();
                model.ClientId = client.ClientId;
                model.FileNumber = client.FileNumber;
                model.FirstContactDate = client.FirstContactDate;
                model.FirstContactAge = client.FirstContactAge;
                model.CurrentAge = client.CurrentAge;
                model.BirthDate = client.BirthDate;
                model.CalendarAgeId = client.CalendarAgeId;
                model.FullName = client.FullName;
                model.MiddleName = client.MiddleName;
                model.Referance = client.Reference;
                model.MotherId = client.MotherId;
                model.FatherId = client.FatherId;
                model.AddressId = client.AddressId;
                model.IdCard = client.IdCard;
                model.Gender = client.Gender;
                model.Blood = client.Blood;
                model.Pediatrician = client.Pediatrician;
                model.CountOfChild = client.CountOfChild;
                model.FamilyStatus = client.FamilyStatus;
                model.Notes = client.Notes;
                model.CreateDate = client.CreateDate;
                model.CreateUserId = client.CreateUserId;
                model.UpdateDate = client.UpdateDate;
                model.UpdateUserId = client.UpdateUserId;
                model.Active = client.Active;
                model.Deleted = client.Deleted;

                var mother = client.MotherIdSource;

                if (mother != null)
                {
                    model.Mother = new MotherModel()
                    {
                        MotherId = mother.MotherId,
                        FullName = mother.FullName,
                        Title = mother.Title,
                        Email = mother.Email,
                        Fax = mother.Fax,
                        HomePhone = mother.HomePhone,
                        BusinessPhone = mother.BusinessPhone,
                        MobilePhone = mother.MobilePhone,
                        OtherPhone = mother.OtherPhone,
                        JobId = mother.JobId,
                        Notes = mother.Notes,
                        MotherStatusId = mother.MotherStatusId,
                        CreateDate = mother.CreateDate,
                        UpdateDate = mother.UpdateDate,
                        CreateUserId = mother.CreateUserId,
                        UpdateUserId = mother.UpdateUserId,
                        Active = mother.Active,
                        Deleted = mother.Deleted
                    };
                }


                var father = client.FatherIdSource;

                if (father != null)
                {
                    model.Father = new FatherModel()
                    {
                        FatherId = mother.MotherId,
                        FullName = mother.FullName,
                        Title = mother.Title,
                        Email = mother.Email,
                        Fax = mother.Fax,
                        HomePhone = mother.HomePhone,
                        BusinessPhone = mother.BusinessPhone,
                        MobilePhone = mother.MobilePhone,
                        OtherPhone = mother.OtherPhone,
                        JobId = mother.JobId,
                        Notes = mother.Notes,
                        FatherStatusId = mother.MotherStatusId,
                        CreateDate = mother.CreateDate,
                        UpdateDate = mother.UpdateDate,
                        CreateUserId = mother.CreateUserId,
                        UpdateUserId = mother.UpdateUserId,
                        Active = mother.Active,
                        Deleted = mother.Deleted
                    };
                }
                
                cacheManager.Set<ClientModel>(client.ClientId.ToString(), model);

                Console.WriteLine(model.FileNumber);
            });



            Console.ReadLine();
        }
    }
}
