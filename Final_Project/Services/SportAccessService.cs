using Final_Project.Data;
using Final_Project.Interfaces;
using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Services
{
    public class SportAccessService : ISportAccessInterface
    {
        private SportAccessContext _sportAccessContext;

        //Pratik Chaudhari
        public SportAccessService(SportAccessContext sportAccessContext)
        {
            _sportAccessContext = sportAccessContext;
        }

        //Pratik Chaudhari
        public List<Sport> GetAllSportRecords()
        {
            return _sportAccessContext.SportRecords.ToList();
        }

        //Pratik Chaudhari
        private Sport SportByID(int id)
        {
            return _sportAccessContext.SportRecords.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        //Pratik Chaudhari
        public List<Sport> GetSportRecordByID(int id)
        {
            List<Sport> sportList = _sportAccessContext.SportRecords.ToList();

            Sport sportById = SportByID(id);

            if (sportById == null)
            {
                return sportList.Take(5).ToList();
            }
            else
            {
                return sportList.Where(x => x.Id.Equals(id)).ToList();
            }
        }

        //Pratik Chaudhari
        public int? RemoveSportRecordById(int id)
        {
            var sportRecToDelete = this.SportByID(id);

            if (sportRecToDelete == null) return null;
            try
            {
                _sportAccessContext.SportRecords.Remove(sportRecToDelete);
                _sportAccessContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Pratik Chaudhari
        public int? UpdateSportRecord(Sport existingSportRecord)
        {
            var sportRecordToUpdate = this.SportByID(existingSportRecord.Id);

            if (sportRecordToUpdate == null)
                return null;

            sportRecordToUpdate.fullName = existingSportRecord.fullName;
            sportRecordToUpdate.favoriteSport = existingSportRecord.favoriteSport;
            sportRecordToUpdate.favoriteTeam = existingSportRecord.favoriteTeam;
            sportRecordToUpdate.favoritePlayer = existingSportRecord.favoritePlayer;

            try
            {
                _sportAccessContext.SportRecords.Update(sportRecordToUpdate);
                _sportAccessContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Pratik Chaudhari
        public int? AddSportRecord(Sport newSportRecord)
        {
            var sportRecordExist = _sportAccessContext.SportRecords.Where(x => x.fullName.Equals(newSportRecord.fullName)).FirstOrDefault();
            if (sportRecordExist != null)
            {
                return null;
            }
            try
            {
                _sportAccessContext.SportRecords.Add(newSportRecord);
                _sportAccessContext.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
