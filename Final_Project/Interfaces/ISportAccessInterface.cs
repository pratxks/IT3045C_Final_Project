using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Interfaces
{
    public interface ISportAccessInterface
    {
        List<Sport> GetAllSportRecords();
        List<Sport> GetSportRecordByID(int id);
        int? RemoveSportRecordById(int id);
        int? UpdateSportRecord(Sport existingSportRecord);
        int? AddSportRecord(Sport newSportRecord);
    }
}
