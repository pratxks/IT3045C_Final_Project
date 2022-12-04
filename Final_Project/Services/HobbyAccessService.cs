using Final_Project.Data;
using Final_Project.Interfaces;
using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Services
{
    public class HobbyAccessService : IHobbyAccessInterface
    {
        private HobbyAccessContext _hobbyAccessContext;

        //Pratik Chaudhari
        public HobbyAccessService(HobbyAccessContext hobbyAccessContext)
        {
            _hobbyAccessContext = hobbyAccessContext;
        }

        //Pratik Chaudhari
        public List<Hobby> GetAllHobbyRecords()
        {
            return _hobbyAccessContext.HobbyRecords.ToList();
        }

        //Pratik Chaudhari
        private Hobby HobbyByID(int id)
        {
            return _hobbyAccessContext.HobbyRecords.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        //Pratik Chaudhari
        public List<Hobby> GetHobbyRecordByID(int id)
        {
            List<Hobby> hobbyList = _hobbyAccessContext.HobbyRecords.ToList();

            Hobby hobbyById = HobbyByID(id);

            if (hobbyById == null)
            {
                return hobbyList.Take(5).ToList();
            }
            else
            {
                return hobbyList.Where(x => x.Id.Equals(id)).ToList();
            }
        }

        //Pratik Chaudhari
        public int? RemoveHobbyRecordById(int id)
        {
            var hobbyToDelete = this.HobbyByID(id);

            if (hobbyToDelete == null) return null;
            try
            {
                _hobbyAccessContext.HobbyRecords.Remove(hobbyToDelete);
                _hobbyAccessContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Pratik Chaudhari
        public int? UpdateHobbyRecord(Hobby existingHobbyRecord)
        {
            var hobbyRecordToUpdate = this.HobbyByID(existingHobbyRecord.Id);

            if (hobbyRecordToUpdate == null)
                return null;

            hobbyRecordToUpdate.fullName = existingHobbyRecord.fullName;
            hobbyRecordToUpdate.hobby = existingHobbyRecord.hobby;
            hobbyRecordToUpdate.favoriteVideoGame = existingHobbyRecord.favoriteVideoGame;
            hobbyRecordToUpdate.favoriteBoardGame = existingHobbyRecord.favoriteBoardGame;

            try
            {
                _hobbyAccessContext.HobbyRecords.Update(hobbyRecordToUpdate);
                _hobbyAccessContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Pratik Chaudhari
        public int? AddHobbyRecord(Hobby newHobbyRecord)
        {
            var hobbyExist = _hobbyAccessContext.HobbyRecords.Where(x => x.fullName.Equals(newHobbyRecord.fullName)).FirstOrDefault();
            if (hobbyExist != null)
            {
                return null;
            }
            try
            {
                _hobbyAccessContext.HobbyRecords.Add(newHobbyRecord);
                _hobbyAccessContext.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
